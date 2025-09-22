using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;

namespace RFID_LINEN_DESKTOP
{
    // Models untuk API Response
    public class ParticipantResponse
    {
        public bool success { get; set; }
        public List<ParticipantData> data { get; set; }
    }

    public class ParticipantData
    {
        public int parsId { get; set; }
        public int eventId { get; set; }
        public string eventName { get; set; }
        public int catId { get; set; }
        public string catName { get; set; }
        public string bibNumber { get; set; }
        public string bibName { get; set; }
        public string parsName { get; set; }
        public string parsBirth { get; set; }
        public string parsAddress { get; set; }
        public bool parsGender { get; set; }
        public bool parsChildren { get; set; }
        public string racePack { get; set; }
        public string golonganDarah { get; set; }
        public bool isActive { get; set; }
    }

    public class ComboBoxItem
    {
        public int ParsId { get; set; }
        public string DisplayText { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }

    public partial class UsbForm : MaterialForm
    {
        private UHFAPI uhf = new UHFAPI();
        private bool connected = false;
        private UHFAPI.OnDataReceived tagCallback;
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_URL = "http://45.64.1.117:1717/api/Master/participant_rfid";
        private const string PARTICIPANT_API_URL = "http://45.64.1.117:1717/api/Master/participant/unregistered";

        public UsbForm()
        {
            InitializeComponent();
            dgvEPC.Columns.Add("epcColumn", "EPC");
            dgvEPC.Columns.Add("statusColumn", "Status");

            // Add form closing event to cleanup HttpClient
            this.FormClosing += UsbForm_FormClosing;

            // Load participants data when form is created
            LoadParticipants();
        }

        private async void LoadParticipants()
        {
            try
            {
                btnLoadParticipants.Enabled = false;
                btnLoadParticipants.Text = "Loading...";

                HttpResponseMessage response = await httpClient.GetAsync(PARTICIPANT_API_URL);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var participantResponse = JsonConvert.DeserializeObject<ParticipantResponse>(jsonResponse);

                    if (participantResponse.success && participantResponse.data != null)
                    {
                        cmbParticipants.Items.Clear();

                        foreach (var participant in participantResponse.data)
                        {
                            var displayText = $"{participant.bibNumber} - {participant.parsName}";
                            var item = new ComboBoxItem
                            {
                                ParsId = participant.parsId,
                                DisplayText = displayText
                            };
                            cmbParticipants.Items.Add(item);
                        }

                        if (cmbParticipants.Items.Count > 0)
                        {
                            cmbParticipants.SelectedIndex = 0;
                        }

                        MessageBox.Show($"Loaded {participantResponse.data.Count} participants", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No participants data found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Failed to load participants: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading participants: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadParticipants.Enabled = true;
                btnLoadParticipants.Text = "Reload Participants";
            }
        }

        private void btnLoadParticipants_Click(object sender, EventArgs e)
        {
            LoadParticipants();
        }

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

        private async void OnTagReceived(IntPtr epcPtr, short recvLen)
        {
            if (recvLen <= 0)
                return;

            byte[] buffer = new byte[recvLen];
            Marshal.Copy(epcPtr, buffer, 0, recvLen);
            string epc = ParseEpcFromBuffer(buffer);

            if (!string.IsNullOrEmpty(epc))
            {
                BeginInvoke(new Action(async () =>
                {
                    // Check if EPC already exists
                    foreach (DataGridViewRow row in dgvEPC.Rows)
                    {
                        if (row.Cells[0].Value?.ToString() == epc)
                            return;
                    }

                    // Add to grid first
                    int rowIndex = dgvEPC.Rows.Add(epc, "Sending...");

                    // Send to API
                    await SendRfidToApi(epc, rowIndex);
                }));
            }
        }

        private async Task SendRfidToApi(string rfid, int gridRowIndex)
        {
            try
            {
                // Get eventId and parsId from input fields
                int eventId = (int)numEventId.Value;
                int parsId = 0;

                // Get parsId from selected participant
                if (cmbParticipants.SelectedItem is ComboBoxItem selectedItem)
                {
                    parsId = selectedItem.ParsId;
                }
                else
                {
                    dgvEPC.Rows[gridRowIndex].Cells[1].Value = "No participant selected";
                    dgvEPC.Rows[gridRowIndex].Cells[1].Style.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                var requestData = new
                {
                    rfid = rfid,
                    tid = rfid, // Same as RFID as requested
                    eventId = eventId,
                    parsId = parsId
                };

                string jsonContent = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(API_URL, content);

                // Update status in grid
                if (response.IsSuccessStatusCode)
                {
                    dgvEPC.Rows[gridRowIndex].Cells[1].Value = "Success";
                    dgvEPC.Rows[gridRowIndex].Cells[1].Style.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    dgvEPC.Rows[gridRowIndex].Cells[1].Value = $"Failed ({response.StatusCode})";
                    dgvEPC.Rows[gridRowIndex].Cells[1].Style.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                dgvEPC.Rows[gridRowIndex].Cells[1].Value = $"Error: {ex.Message}";
                dgvEPC.Rows[gridRowIndex].Cells[1].Style.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                // Pakai USB Mode
                bool result = uhf.OpenUsb();
                if (result)
                {
                    connected = true;
                    btnConnect.Text = "Disconnect";
                    MessageBox.Show("Connected via USB");
                }
                else
                {
                    MessageBox.Show("Failed to connect via USB");
                }
            }
            else
            {
                bool resultClose = uhf.Close();
                if (resultClose)
                {
                    connected = false;
                    btnConnect.Text = "Connect";
                    MessageBox.Show("Disconnected");
                }
            }
        }

        private void btnStartReading_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                MessageBox.Show("Not Connected");
                return;
            }

            // Validate input values
            if (numEventId.Value == 0)
            {
                MessageBox.Show("Please enter valid Event ID");
                return;
            }

            if (cmbParticipants.SelectedItem == null)
            {
                MessageBox.Show("Please select a participant");
                return;
            }

            tagCallback = new UHFAPI.OnDataReceived(OnTagReceived);
            UHFAPI.setOnDataReceived(tagCallback);
            bool success = uhf.StartInventory();
            if (!success)
            {
                MessageBox.Show("Failed to start Reader.");
                return;
            }
            MessageBox.Show("Reader started...");
        }

        private void btnStopReading_Click(object sender, EventArgs e)
        {
            uhf.StopInventory();
            UHFAPI.setOnDataReceived(null);
            MessageBox.Show("Reader Stopped.");
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            dgvEPC.Rows.Clear();
        }

        private void UsbForm_Load(object sender, EventArgs e)
        {
            // Set default values
            numEventId.Value = 1;
        }

        private void UsbForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cleanup HttpClient when form is closing
            httpClient?.Dispose();
        }
    }
}