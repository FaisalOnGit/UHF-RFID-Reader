using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MaterialSkin;
using MaterialSkin.Controls;

namespace RFID_LINEN_DESKTOP
{
    public partial class Form1 : MaterialForm
    {
        private UHFAPI uhf = new UHFAPI();
        private Thread epcThread;
        private bool isReading = false;
        private UHFAPI.OnDataReceived tagCallback;
        private bool connected = false;

        public Form1()
        {
            InitializeComponent();
            dgvEPC.Columns.Add("epcColumn", "EPC");
            LoadSerialPorts();
        }

        private void LoadSerialPorts()
        {
            serialPort.Items.AddRange(SerialPort.GetPortNames());
            if (serialPort.Items.Count > 0)
                serialPort.SelectedIndex = 0;
        }

        private string ParseEpcFromBuffer(byte[] data)
        {
            int index = 0;
            while (index < data.Length)
            {
                byte type = data[index++];
                byte length = data[index++];

                if (type == UHFAPI.CELL_UHF_EPC)
                {
                    byte[] epcBytes = new byte[length];
                    Array.Copy(data, index, epcBytes, 0, length); // copy entire EPC block including PC
                    return BitConverter.ToString(epcBytes).Replace("-", "");
                }

                index += length;
            }
            return null;
        }

        private void OnTagReceived(IntPtr epcPtr, short recvLen)
        {
            if (recvLen <= 0)
                return;

            byte[] buffer = new byte[recvLen];
            Marshal.Copy(epcPtr, buffer, 0, recvLen);

            // Decode EPC from buffer — EPC type is `0x06` in Hopeland’s SDK
            string epc = ParseEpcFromBuffer(buffer);

            if (!string.IsNullOrEmpty(epc))
            {
                BeginInvoke(new Action(() =>
                {
                    foreach (DataGridViewRow row in dgvEPC.Rows)
                    {
                        if (row.Cells[0].Value?.ToString() == epc)
                            return;
                    }
                    dgvEPC.Rows.Add(epc);
                }));
            }
        }

        private void btnReadEPC_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                MessageBox.Show("Not Connected");
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

        private void OnTagReceived(string epc)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnTagReceived(epc)));
                return;
            }

            // Avoid duplicates
            foreach (DataGridViewRow row in dgvEPC.Rows)
            {
                if (row.Cells[0].Value?.ToString() == epc)
                    return;
            }

            dgvEPC.Rows.Add(epc);
        }

        private void btnStopReading_Click(object sender, EventArgs e)
        {
            // Stop the inventory process
            uhf.StopInventory();

            // Optionally remove callback to prevent new EPCs
            UHFAPI.setOnDataReceived(null);

            MessageBox.Show("Reader Stopped.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dgvEPC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string pesan = materialTextBox1.Text;
            MessageBox.Show(pesan);
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            uhf.StopInventory();

            UHFAPI.setOnDataReceived(null);

            MessageBox.Show("Reader Stopped.");
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                MessageBox.Show("Not Connected");
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

        private void materialButton2_Click_1(object sender, EventArgs e)
        {
            if (serialPort.SelectedItem == null)
            {
                MessageBox.Show("Please select a COM port.");
                return;
            }

            string selectedPort = serialPort.SelectedItem.ToString(); // e.g., "COM3"
            int portNumber = int.Parse(selectedPort.Replace("COM", ""));

            if (connectBtn.Text == "Connect")
            {
                bool result = uhf.Open(portNumber);

                if (result)
                {
                    connected = true;
                    connectBtn.Text = "Disconnect";
                    MessageBox.Show("Connected to " + selectedPort);
                }
                else
                {
                    MessageBox.Show("Failed to connect to " + selectedPort);
                }
            }
            else
            {
                bool resultClose = uhf.Close();

                if (resultClose)
                {
                    connected = false;
                    connectBtn.Text = "Connect";
                    MessageBox.Show("Disconnected");
                }
            }
        }
    }
}