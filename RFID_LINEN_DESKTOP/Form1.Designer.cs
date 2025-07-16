namespace RFID_LINEN_DESKTOP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvEPC = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.readEpc = new MaterialSkin.Controls.MaterialButton();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.connectBtn = new MaterialSkin.Controls.MaterialButton();
            this.serialPort = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEPC
            // 
            this.dgvEPC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEPC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEPC.Location = new System.Drawing.Point(8, 156);
            this.dgvEPC.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEPC.Name = "dgvEPC";
            this.dgvEPC.RowHeadersWidth = 62;
            this.dgvEPC.RowTemplate.Height = 28;
            this.dgvEPC.Size = new System.Drawing.Size(815, 223);
            this.dgvEPC.TabIndex = 3;
            this.dgvEPC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEPC_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 9;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(15, 76);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(81, 19);
            this.materialLabel1.TabIndex = 10;
            this.materialLabel1.Text = "Obsesiman";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(15, 440);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(32, 19);
            this.materialLabel2.TabIndex = 11;
            this.materialLabel2.Text = "Test";
            this.materialLabel2.Click += new System.EventHandler(this.materialLabel2_Click);
            // 
            // materialTextBox1
            // 
            this.materialTextBox1.AnimateReadOnly = false;
            this.materialTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox1.Depth = 0;
            this.materialTextBox1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox1.LeadingIcon = null;
            this.materialTextBox1.Location = new System.Drawing.Point(8, 462);
            this.materialTextBox1.MaxLength = 50;
            this.materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox1.Multiline = false;
            this.materialTextBox1.Name = "materialTextBox1";
            this.materialTextBox1.Size = new System.Drawing.Size(272, 50);
            this.materialTextBox1.TabIndex = 12;
            this.materialTextBox1.Text = "";
            this.materialTextBox1.TrailingIcon = null;
            this.materialTextBox1.TextChanged += new System.EventHandler(this.materialTextBox1_TextChanged);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(309, 462);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(64, 36);
            this.materialButton1.TabIndex = 13;
            this.materialButton1.Text = "Send";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // readEpc
            // 
            this.readEpc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.readEpc.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.readEpc.Depth = 0;
            this.readEpc.HighEmphasis = true;
            this.readEpc.Icon = null;
            this.readEpc.Location = new System.Drawing.Point(12, 389);
            this.readEpc.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.readEpc.MouseState = MaterialSkin.MouseState.HOVER;
            this.readEpc.Name = "readEpc";
            this.readEpc.NoAccentTextColor = System.Drawing.Color.Empty;
            this.readEpc.Size = new System.Drawing.Size(64, 36);
            this.readEpc.TabIndex = 14;
            this.readEpc.Text = "Read";
            this.readEpc.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.readEpc.UseAccentColor = false;
            this.readEpc.UseVisualStyleBackColor = true;
            this.readEpc.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(99, 389);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(64, 36);
            this.materialButton3.TabIndex = 15;
            this.materialButton3.Text = "Stop";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.connectBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.connectBtn.Depth = 0;
            this.connectBtn.HighEmphasis = true;
            this.connectBtn.Icon = null;
            this.connectBtn.Location = new System.Drawing.Point(201, 111);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.connectBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.connectBtn.Size = new System.Drawing.Size(89, 36);
            this.connectBtn.TabIndex = 16;
            this.connectBtn.Text = "Connect";
            this.connectBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.connectBtn.UseAccentColor = false;
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.materialButton2_Click_1);
            // 
            // serialPort
            // 
            this.serialPort.AutoResize = false;
            this.serialPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.serialPort.Depth = 0;
            this.serialPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.serialPort.DropDownHeight = 174;
            this.serialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialPort.DropDownWidth = 121;
            this.serialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.serialPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.serialPort.FormattingEnabled = true;
            this.serialPort.IntegralHeight = false;
            this.serialPort.ItemHeight = 43;
            this.serialPort.Location = new System.Drawing.Point(8, 98);
            this.serialPort.MaxDropDownItems = 4;
            this.serialPort.MouseState = MaterialSkin.MouseState.OUT;
            this.serialPort.Name = "serialPort";
            this.serialPort.Size = new System.Drawing.Size(172, 49);
            this.serialPort.StartIndex = 0;
            this.serialPort.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 490);
            this.Controls.Add(this.serialPort);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.readEpc);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.materialTextBox1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvEPC);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "RFID LINEN DESKTOP";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEPC;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton readEpc;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton connectBtn;
        private MaterialSkin.Controls.MaterialComboBox serialPort;
    }
}

