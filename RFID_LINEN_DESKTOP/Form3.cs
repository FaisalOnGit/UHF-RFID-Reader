using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;

namespace RFID_LINEN_DESKTOP
{
    public partial class Register : MaterialForm
    {
        private readonly HttpClient httpClient;
        private readonly MaterialSkinManager materialSkinManager;

        // RFID Reader components
        private UHFAPI uhf = new UHFAPI();
        private bool connected = false;
        private UHFAPI.OnDataReceived tagCallback;

        // Participant data from API
        private List<Participant> unregisteredParticipants = new List<Participant>();
        private bool participantsLoaded = false;

        public Register()
        {
            InitializeComponent();

            // Initialize Material Design
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            // Initialize HttpClient
            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        // Parse EPC from buffer (copied from UsbForm)
        private string ParseEpcFromBuffer(byte[] data)
        {
            int index = 0;
            while (index < data.Length)
            {
                byte type = data[index++];
                if (index >= data.Length) break;
                byte length = data[index++];
                if (type == UHFAPI.CELL_UHF_EPC)
                {
                    if (index + length > data.Length) break;
                    byte[] epcBytes = new byte[length];
                    Array.Copy(data, index, epcBytes, 0, length);
                    return BitConverter.ToString(epcBytes).Replace("-", "");
                }
                index += length;
            }
            return null;
        }

        // Callback when tag is received
        private void OnTagReceived(IntPtr epcPtr, short recvLen)
        {
            if (recvLen <= 0)
                return;

            byte[] buffer = new byte[recvLen];
            Marshal.Copy(epcPtr, buffer, 0, recvLen);
            string epc = ParseEpcFromBuffer(buffer);

            if (!string.IsNullOrEmpty(epc))
            {
                BeginInvoke(new Action(() =>
                {
                    // Auto-fill RFID and TID fields
                    txtRfid.Text = epc;
                    txtTid.Text = epc; // Same as RFID as in original code

                    // Update status
                    lblStatus.Text = "Tag detected and filled automatically";
                    lblStatus.ForeColor = System.Drawing.Color.Green;

                    // Stop reading after getting one tag
                    StopReading();
                }));
            }
        }

        // Connect/Disconnect RFID Reader
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "CONNECT READER")
            {
                // Connect using USB Mode
                bool result = uhf.OpenUsb();
                if (result)
                {
                    connected = true;
                    btnConnect.Text = "DISCONNECT";
                    btnConnect.BackColor = System.Drawing.Color.FromArgb(244, 67, 54); // Red color
                    lblReaderStatus.Text = "Reader: Connected";
                    lblReaderStatus.ForeColor = System.Drawing.Color.Green;
                    MaterialMessageBox.Show("RFID Reader connected successfully!", "Connection Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblReaderStatus.Text = "Reader: Connection Failed";
                    lblReaderStatus.ForeColor = System.Drawing.Color.Red;
                    MaterialMessageBox.Show("Failed to connect RFID Reader. Please check USB connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Disconnect
                StopReading(); // Stop reading first
                bool resultClose = uhf.Close();
                if (resultClose)
                {
                    connected = false;
                    btnConnect.Text = "CONNECT READER";
                    btnConnect.BackColor = System.Drawing.Color.FromArgb(33, 150, 243); // Blue color
                    lblReaderStatus.Text = "Reader: Disconnected";
                    lblReaderStatus.ForeColor = System.Drawing.Color.Gray;
                    MaterialMessageBox.Show("RFID Reader disconnected successfully!", "Disconnection Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Start Reading RFID Tags
        private void btnStartReading_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                MaterialMessageBox.Show("RFID Reader not connected!", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Setup callback for receiving tag data
                tagCallback = new UHFAPI.OnDataReceived(OnTagReceived);
                UHFAPI.setOnDataReceived(tagCallback);

                // Start inventory
                bool success = uhf.StartInventory();
                if (success)
                {
                    btnStartReading.Enabled = false;
                    btnStopReading.Enabled = true;
                    lblStatus.Text = "Scanning for RFID tags...";
                    lblStatus.ForeColor = System.Drawing.Color.Orange;
                    progressBarReading.Visible = true;
                }
                else
                {
                    MaterialMessageBox.Show("Failed to start RFID reader!", "Reader Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"Error starting RFID reader: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Stop Reading RFID Tags
        private void btnStopReading_Click(object sender, EventArgs e)
        {
            StopReading();
        }

        private void StopReading()
        {
            try
            {
                uhf.StopInventory();
                UHFAPI.setOnDataReceived(null);

                btnStartReading.Enabled = true;
                btnStopReading.Enabled = false;
                progressBarReading.Visible = false;

                if (string.IsNullOrEmpty(txtRfid.Text))
                {
                    lblStatus.Text = "Reading stopped - No tag detected";
                    lblStatus.ForeColor = System.Drawing.Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"Error stopping RFID reader: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtRfid.Text))
                {
                    MaterialMessageBox.Show("RFID tidak boleh kosong!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRfid.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTid.Text))
                {
                    MaterialMessageBox.Show("TID tidak boleh kosong!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTid.Focus();
                    return;
                }

                if (!int.TryParse(txtEventId.Text, out int eventId))
                {
                    MaterialMessageBox.Show("Event ID harus berupa angka!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEventId.Focus();
                    return;
                }

                if (cmbParsId.SelectedItem == null || !int.TryParse(txtParsId.Text, out int parsId))
                {
                    MaterialMessageBox.Show("Silakan pilih peserta dari daftar!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbParsId.Focus();
                    return;
                }

                // Show loading
                btnRegister.Enabled = false;
                progressBar.Visible = true;
                lblStatus.Text = "Mengirim data...";
                lblStatus.ForeColor = System.Drawing.Color.Orange;

                // Create request body
                var requestBody = new
                {
                    rfid = txtRfid.Text.Trim(),
                    tid = txtTid.Text.Trim(),
                    eventId = eventId,
                    parsId = parsId
                };

                string jsonContent = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send POST request
                var response = await httpClient.PostAsync("http://45.64.1.117:1717/api/Master/participant_rfid", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    lblStatus.Text = "Registrasi berhasil!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;

                    MaterialMessageBox.Show("Registrasi RFID berhasil!\n\nResponse: " + responseContent, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form after success
                    ClearForm();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    lblStatus.Text = $"Error: {response.StatusCode}";
                    lblStatus.ForeColor = System.Drawing.Color.Red;

                    MaterialMessageBox.Show($"Registrasi gagal!\n\nStatus: {response.StatusCode}\nError: {errorContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                lblStatus.Text = "Connection error";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MaterialMessageBox.Show($"Koneksi error!\n\nDetail: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException ex)
            {
                lblStatus.Text = "Request timeout";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MaterialMessageBox.Show("Request timeout! Periksa koneksi internet Anda.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Unexpected error";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MaterialMessageBox.Show($"Terjadi kesalahan!\n\nDetail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Hide loading
                btnRegister.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtRfid.Clear();
            txtTid.Clear();
            txtEventId.Clear();
            if (cmbParsId.Items.Count > 0)
                cmbParsId.SelectedIndex = -1;
            lblStatus.Text = "Siap untuk registrasi";
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            txtRfid.Focus();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Cleanup RFID reader connection
            if (connected)
            {
                StopReading();
                uhf.Close();
            }

            httpClient?.Dispose();
            base.OnFormClosed(e);
        }

        private async void Register_Load(object sender, EventArgs e)
        {
            // Set initial states
            btnStopReading.Enabled = false;
            progressBarReading.Visible = false;
            lblReaderStatus.Text = "Reader: Disconnected";
            lblReaderStatus.ForeColor = System.Drawing.Color.Gray;

            // Load unregistered participants from API
            await LoadUnregisteredParticipants();
        }

        // Load unregistered participants from API
        private async Task LoadUnregisteredParticipants()
        {
            try
            {
                lblStatus.Text = "Memuat data peserta...";
                lblStatus.ForeColor = System.Drawing.Color.Orange;

                var response = await httpClient.GetAsync("http://45.64.1.117:1717/api/Master/participant/unregistered");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ParticipantApiResponse>(responseContent);

                    if (apiResponse != null && apiResponse.success && apiResponse.data != null && apiResponse.data.Count > 0)
                    {
                        unregisteredParticipants = apiResponse.data;

                        // Clear and populate dropdown
                        cmbParsId.Items.Clear();
                        foreach (var participant in apiResponse.data)
                        {
                            cmbParsId.Items.Add(new ParticipantComboBoxItem
                            {
                                Value = participant.parsId.ToString(),
                                Display = $"{participant.parsId} - {participant.parsName ?? "Unknown"}"
                            });
                        }

                        participantsLoaded = true;
                        lblStatus.Text = $"Data peserta berhasil dimuat: {apiResponse.data.Count} peserta";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        if (apiResponse != null && !apiResponse.success)
                        {
                            lblStatus.Text = $"API Error: {apiResponse.message}";
                            lblStatus.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            lblStatus.Text = "Tidak ada peserta yang belum terdaftar";
                            lblStatus.ForeColor = System.Drawing.Color.Orange;
                        }
                    }
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    lblStatus.Text = "Gagal memuat data peserta";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    MaterialMessageBox.Show($"Gagal memuat data peserta!\n\nStatus: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                lblStatus.Text = "Koneksi error saat memuat data";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MaterialMessageBox.Show($"Koneksi error saat memuat data peserta!\n\nDetail: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException ex)
            {
                lblStatus.Text = "Request timeout saat memuat data";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MaterialMessageBox.Show("Request timeout saat memuat data peserta!", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error saat memuat data peserta";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MaterialMessageBox.Show($"Terjadi kesalahan saat memuat data peserta!\n\nDetail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle combo box selection change
        private void cmbParsId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParsId.SelectedItem != null)
            {
                var selectedItem = (ParticipantComboBoxItem)cmbParsId.SelectedItem;
                txtParsId.Text = selectedItem.Value;
            }
        }

        // Handle refresh button click
        private async void btnRefreshParticipants_Click(object sender, EventArgs e)
        {
            await LoadUnregisteredParticipants();
        }
    }

    // API response model class
    public class ParticipantApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Participant> data { get; set; }
    }

    // Participant model class
    public class Participant
    {
        public int parsId { get; set; }
        public string parsName { get; set; }
        public string parsEmail { get; set; }
        public string parsPhone { get; set; }
        // Add other properties as needed based on API response
    }

    // ComboBox item helper class for participants
    public class ParticipantComboBoxItem
    {
        public string Value { get; set; }
        public string Display { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }

    // Request model class
    public class ParticipantRfidRequest
    {
        public string rfid { get; set; }
        public string tid { get; set; }
        public int eventId { get; set; }
        public int parsId { get; set; }
    }
}