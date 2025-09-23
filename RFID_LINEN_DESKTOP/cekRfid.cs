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
    public partial class cekRfid : MaterialForm
    {
        private readonly HttpClient httpClient;
        private readonly MaterialSkinManager materialSkinManager;

        // RFID Reader components
        private UHFAPI uhf = new UHFAPI();
        private bool connected = false;
        private UHFAPI.OnDataReceived tagCallback;

        public cekRfid()
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
                    // Auto-fill RFID field
                    txtRfid.Text = epc;

                    // Update status
                    lblStatus.Text = "Tag detected and filled automatically";
                    lblStatus.ForeColor = System.Drawing.Color.Green;

                    // Auto-check RFID
                    btnCheckRfid_Click(null, null);

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

        private async void btnCheckRfid_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate RFID input
                if (string.IsNullOrWhiteSpace(txtRfid.Text))
                {
                    MaterialMessageBox.Show("RFID tidak boleh kosong!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRfid.Focus();
                    return;
                }

                // Show loading
                btnCheckRfid.Enabled = false;
                progressBar.Visible = true;
                lblStatus.Text = "Memeriksa RFID...";
                lblStatus.ForeColor = System.Drawing.Color.Orange;

                // Send GET request to check RFID
                string rfid = txtRfid.Text.Trim();
                var response = await httpClient.GetAsync($"http://45.64.1.117:1717/api/Master/participant_rfid/{rfid}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<RfidCheckResponse>(responseContent);

                    if (apiResponse != null && apiResponse.success && apiResponse.data != null)
                    {
                        // Display participant information
                        var participant = apiResponse.data;
                        txtParsId.Text = participant.parsId.ToString();
                        txtParsName.Text = participant.parsName ?? "Unknown";
                        txtParsEmail.Text = participant.parsEmail ?? "Not available";
                        txtParsPhone.Text = participant.parsPhone ?? "Not available";
                        txtEventId.Text = participant.eventId?.ToString() ?? "Not available";

                        lblStatus.Text = "RFID ditemukan!";
                        lblStatus.ForeColor = System.Drawing.Color.Green;

                        MaterialMessageBox.Show($"Data peserta ditemukan!\n\nNama: {participant.parsName}\nEmail: {participant.parsEmail}\nPhone: {participant.parsPhone}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ClearParticipantInfo();
                        lblStatus.Text = "RFID tidak terdaftar";
                        lblStatus.ForeColor = System.Drawing.Color.Orange;

                        MaterialMessageBox.Show("RFID tidak terdaftar dalam sistem!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ClearParticipantInfo();
                    lblStatus.Text = "RFID tidak ditemukan";
                    lblStatus.ForeColor = System.Drawing.Color.Orange;

                    MaterialMessageBox.Show("RFID tidak ditemukan dalam sistem!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    lblStatus.Text = $"Error: {response.StatusCode}";
                    lblStatus.ForeColor = System.Drawing.Color.Red;

                    MaterialMessageBox.Show($"Gagal memeriksa RFID!\n\nStatus: {response.StatusCode}\nError: {errorContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                btnCheckRfid.Enabled = true;
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
            ClearParticipantInfo();
            lblStatus.Text = "Siap untuk memeriksa RFID";
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            txtRfid.Focus();
        }

        private void ClearParticipantInfo()
        {
            txtParsId.Clear();
            txtParsName.Clear();
            txtParsEmail.Clear();
            txtParsPhone.Clear();
            txtEventId.Clear();
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

        private void cekRfid_Load(object sender, EventArgs e)
        {
            // Set initial states
            btnStopReading.Enabled = false;
            progressBarReading.Visible = false;
            progressBar.Visible = false;
            lblReaderStatus.Text = "Reader: Disconnected";
            lblReaderStatus.ForeColor = System.Drawing.Color.Gray;
            lblStatus.Text = "Siap untuk memeriksa RFID";
            lblStatus.ForeColor = System.Drawing.Color.Gray;

            // Make participant info fields read-only
            txtParsId.ReadOnly = true;
            txtParsName.ReadOnly = true;
            txtParsEmail.ReadOnly = true;
            txtParsPhone.ReadOnly = true;
            txtEventId.ReadOnly = true;
        }
    }

    // API response model class for RFID check
    public class RfidCheckResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public RfidParticipantData data { get; set; }
    }

    // Participant data model for RFID check
    public class RfidParticipantData
    {
        public int parsId { get; set; }
        public string parsName { get; set; }
        public string parsEmail { get; set; }
        public string parsPhone { get; set; }
        public int? eventId { get; set; }
        public string rfid { get; set; }
        public string tid { get; set; }
    }
}