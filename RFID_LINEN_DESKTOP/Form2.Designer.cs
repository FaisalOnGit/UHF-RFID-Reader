namespace RFID_LINEN_DESKTOP
{
    partial class UsbForm
    {
        private System.ComponentModel.IContainer components = null;

        private MaterialSkin.Controls.MaterialButton btnConnect;
        private MaterialSkin.Controls.MaterialButton btnStartReading;
        private MaterialSkin.Controls.MaterialButton btnStopReading;
        private MaterialSkin.Controls.MaterialButton btnClearGrid;
        private MaterialSkin.Controls.MaterialButton btnLoadParticipants;
        private System.Windows.Forms.DataGridView dgvEPC;
        private MaterialSkin.Controls.MaterialLabel lblEventId;
        private MaterialSkin.Controls.MaterialLabel lblParticipant;
        private System.Windows.Forms.NumericUpDown numEventId;
        private System.Windows.Forms.ComboBox cmbParticipants;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnConnect = new MaterialSkin.Controls.MaterialButton();
            this.btnStartReading = new MaterialSkin.Controls.MaterialButton();
            this.btnStopReading = new MaterialSkin.Controls.MaterialButton();
            this.btnClearGrid = new MaterialSkin.Controls.MaterialButton();
            this.btnLoadParticipants = new MaterialSkin.Controls.MaterialButton();
            this.dgvEPC = new System.Windows.Forms.DataGridView();
            this.lblEventId = new MaterialSkin.Controls.MaterialLabel();
            this.lblParticipant = new MaterialSkin.Controls.MaterialLabel();
            this.numEventId = new System.Windows.Forms.NumericUpDown();
            this.cmbParticipants = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEventId)).BeginInit();
            this.SuspendLayout();

            // 
            // lblEventId
            // 
            this.lblEventId.AutoSize = true;
            this.lblEventId.Depth = 0;
            this.lblEventId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblEventId.Location = new System.Drawing.Point(30, 100);
            this.lblEventId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEventId.Name = "lblEventId";
            this.lblEventId.Size = new System.Drawing.Size(61, 19);
            this.lblEventId.TabIndex = 4;
            this.lblEventId.Text = "Event ID:";

            // 
            // numEventId
            // 
            this.numEventId.Location = new System.Drawing.Point(120, 100);
            this.numEventId.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numEventId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEventId.Name = "numEventId";
            this.numEventId.Size = new System.Drawing.Size(120, 26);
            this.numEventId.TabIndex = 6;
            this.numEventId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});

            // 
            // lblParticipant
            // 
            this.lblParticipant.AutoSize = true;
            this.lblParticipant.Depth = 0;
            this.lblParticipant.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblParticipant.Location = new System.Drawing.Point(280, 100);
            this.lblParticipant.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblParticipant.Name = "lblParticipant";
            this.lblParticipant.Size = new System.Drawing.Size(78, 19);
            this.lblParticipant.TabIndex = 5;
            this.lblParticipant.Text = "Participant:";

            // 
            // cmbParticipants
            // 
            this.cmbParticipants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParticipants.FormattingEnabled = true;
            this.cmbParticipants.Location = new System.Drawing.Point(380, 100);
            this.cmbParticipants.Name = "cmbParticipants";
            this.cmbParticipants.Size = new System.Drawing.Size(350, 28);
            this.cmbParticipants.TabIndex = 8;
            this.cmbParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // btnConnect
            // 
            this.btnConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConnect.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConnect.Depth = 0;
            this.btnConnect.HighEmphasis = true;
            this.btnConnect.Icon = null;
            this.btnConnect.Location = new System.Drawing.Point(50, 160);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.btnConnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConnect.Size = new System.Drawing.Size(140, 45);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConnect.UseAccentColor = false;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            // 
            // btnStartReading
            // 
            this.btnStartReading.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartReading.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStartReading.Depth = 0;
            this.btnStartReading.HighEmphasis = true;
            this.btnStartReading.Icon = null;
            this.btnStartReading.Location = new System.Drawing.Point(220, 160);
            this.btnStartReading.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.btnStartReading.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartReading.Name = "btnStartReading";
            this.btnStartReading.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStartReading.Size = new System.Drawing.Size(160, 45);
            this.btnStartReading.TabIndex = 1;
            this.btnStartReading.Text = "Start Reading";
            this.btnStartReading.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStartReading.UseAccentColor = false;
            this.btnStartReading.UseVisualStyleBackColor = true;
            this.btnStartReading.Click += new System.EventHandler(this.btnStartReading_Click);

            // 
            // btnStopReading
            // 
            this.btnStopReading.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStopReading.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStopReading.Depth = 0;
            this.btnStopReading.HighEmphasis = true;
            this.btnStopReading.Icon = null;
            this.btnStopReading.Location = new System.Drawing.Point(410, 160);
            this.btnStopReading.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.btnStopReading.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStopReading.Name = "btnStopReading";
            this.btnStopReading.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStopReading.Size = new System.Drawing.Size(160, 45);
            this.btnStopReading.TabIndex = 2;
            this.btnStopReading.Text = "Stop Reading";
            this.btnStopReading.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStopReading.UseAccentColor = false;
            this.btnStopReading.UseVisualStyleBackColor = true;
            this.btnStopReading.Click += new System.EventHandler(this.btnStopReading_Click);

            // 
            // btnClearGrid
            // 
            this.btnClearGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearGrid.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClearGrid.Depth = 0;
            this.btnClearGrid.HighEmphasis = true;
            this.btnClearGrid.Icon = null;
            this.btnClearGrid.Location = new System.Drawing.Point(600, 160);
            this.btnClearGrid.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.btnClearGrid.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClearGrid.Size = new System.Drawing.Size(140, 45);
            this.btnClearGrid.TabIndex = 7;
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClearGrid.UseAccentColor = false;
            this.btnClearGrid.UseVisualStyleBackColor = true;
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);

            // 
            // btnLoadParticipants
            // 
            this.btnLoadParticipants.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadParticipants.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLoadParticipants.Depth = 0;
            this.btnLoadParticipants.HighEmphasis = true;
            this.btnLoadParticipants.Icon = null;
            this.btnLoadParticipants.Location = new System.Drawing.Point(770, 160);
            this.btnLoadParticipants.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.btnLoadParticipants.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoadParticipants.Name = "btnLoadParticipants";
            this.btnLoadParticipants.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLoadParticipants.Size = new System.Drawing.Size(180, 45);
            this.btnLoadParticipants.TabIndex = 9;
            this.btnLoadParticipants.Text = "Load Participants";
            this.btnLoadParticipants.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLoadParticipants.UseAccentColor = false;
            this.btnLoadParticipants.UseVisualStyleBackColor = true;
            this.btnLoadParticipants.Click += new System.EventHandler(this.btnLoadParticipants_Click);
            this.btnLoadParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // dgvEPC
            // 
            this.dgvEPC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEPC.Location = new System.Drawing.Point(30, 230);
            this.dgvEPC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvEPC.Name = "dgvEPC";
            this.dgvEPC.RowHeadersWidth = 51;
            this.dgvEPC.RowTemplate.Height = 24;
            this.dgvEPC.Size = new System.Drawing.Size(900, 400);
            this.dgvEPC.TabIndex = 3;
            this.dgvEPC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // UsbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Controls.Add(this.cmbParticipants);
            this.Controls.Add(this.btnLoadParticipants);
            this.Controls.Add(this.btnClearGrid);
            this.Controls.Add(this.numEventId);
            this.Controls.Add(this.lblParticipant);
            this.Controls.Add(this.lblEventId);
            this.Controls.Add(this.dgvEPC);
            this.Controls.Add(this.btnStopReading);
            this.Controls.Add(this.btnStartReading);
            this.Controls.Add(this.btnConnect);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UsbForm";
            this.Padding = new System.Windows.Forms.Padding(3, 80, 3, 4);
            this.Text = "USB Reader Form - RFID to API";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Load += new System.EventHandler(this.UsbForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEventId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}