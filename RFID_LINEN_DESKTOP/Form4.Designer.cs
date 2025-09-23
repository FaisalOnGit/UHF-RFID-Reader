using MaterialSkin.Controls;
using System.Windows.Forms;

namespace RFID_LINEN_DESKTOP
{
    partial class cekRfid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Material Design Controls - Simplified UI
        private MaterialCard cardMain;
        private MaterialCard cardRfidReader;
        private MaterialCard cardParticipantInfo;
        private MaterialLabel lblTitle;
        private MaterialTextBox txtRfid;
        private MaterialTextBox txtTid;
        private MaterialLabel lblParticipantName;
        private MaterialLabel lblBibNumber;
        private MaterialLabel lblNameTitle;
        private MaterialLabel lblBibTitle;
        private MaterialButton btnCheckRfid;
        private MaterialButton btnClear;
        private MaterialButton btnConnect;
        private MaterialButton btnStartReading;
        private MaterialButton btnStopReading;
        private MaterialLabel lblStatus;
        private MaterialLabel lblReaderStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ProgressBar progressBarReading;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel buttonLayout;
        private TableLayoutPanel rfidButtonLayout;
        private TableLayoutPanel participantInfoLayout;

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
            this.cardMain = new MaterialSkin.Controls.MaterialCard();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new MaterialSkin.Controls.MaterialLabel();
            this.cardRfidReader = new MaterialSkin.Controls.MaterialCard();
            this.rfidButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnect = new MaterialSkin.Controls.MaterialButton();
            this.btnStartReading = new MaterialSkin.Controls.MaterialButton();
            this.btnStopReading = new MaterialSkin.Controls.MaterialButton();
            this.progressBarReading = new System.Windows.Forms.ProgressBar();
            this.lblReaderStatus = new MaterialSkin.Controls.MaterialLabel();
            this.txtRfid = new MaterialSkin.Controls.MaterialTextBox();
            this.txtTid = new MaterialSkin.Controls.MaterialTextBox();
            this.cardParticipantInfo = new MaterialSkin.Controls.MaterialCard();
            this.participantInfoLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblNameTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblParticipantName = new MaterialSkin.Controls.MaterialLabel();
            this.lblBibTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblBibNumber = new MaterialSkin.Controls.MaterialLabel();
            this.buttonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnCheckRfid = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new MaterialSkin.Controls.MaterialLabel();
            this.cardMain.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.cardRfidReader.SuspendLayout();
            this.rfidButtonLayout.SuspendLayout();
            this.cardParticipantInfo.SuspendLayout();
            this.participantInfoLayout.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            this.SuspendLayout();
            //
            // cardMain
            //
            this.cardMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardMain.Controls.Add(this.mainLayout);
            this.cardMain.Depth = 0;
            this.cardMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardMain.Location = new System.Drawing.Point(30, 120);
            this.cardMain.Margin = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.cardMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardMain.Name = "cardMain";
            this.cardMain.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.cardMain.Size = new System.Drawing.Size(690, 700);
            this.cardMain.TabIndex = 0;
            //
            // mainLayout
            //
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.lblTitle, 0, 0);
            this.mainLayout.Controls.Add(this.cardRfidReader, 0, 1);
            this.mainLayout.Controls.Add(this.txtRfid, 0, 2);
            this.mainLayout.Controls.Add(this.txtTid, 0, 3);
            this.mainLayout.Controls.Add(this.cardParticipantInfo, 0, 4);
            this.mainLayout.Controls.Add(this.buttonLayout, 0, 5);
            this.mainLayout.Controls.Add(this.progressBar, 0, 6);
            this.mainLayout.Controls.Add(this.lblStatus, 0, 7);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(40, 30);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 8;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(610, 640);
            this.mainLayout.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Depth = 0;
            this.lblTitle.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblTitle.Location = new System.Drawing.Point(175, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 20, 4, 30);
            this.lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "RFID BIB Checker";
            //
            // cardRfidReader
            //
            this.cardRfidReader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardRfidReader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.cardRfidReader.Controls.Add(this.rfidButtonLayout);
            this.cardRfidReader.Depth = 0;
            this.cardRfidReader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardRfidReader.Location = new System.Drawing.Point(4, 79);
            this.cardRfidReader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 20);
            this.cardRfidReader.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardRfidReader.Name = "cardRfidReader";
            this.cardRfidReader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.cardRfidReader.Size = new System.Drawing.Size(602, 140);
            this.cardRfidReader.TabIndex = 1;
            //
            // rfidButtonLayout
            //
            this.rfidButtonLayout.ColumnCount = 3;
            this.rfidButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rfidButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rfidButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rfidButtonLayout.Controls.Add(this.btnConnect, 0, 0);
            this.rfidButtonLayout.Controls.Add(this.btnStartReading, 1, 0);
            this.rfidButtonLayout.Controls.Add(this.btnStopReading, 2, 0);
            this.rfidButtonLayout.Controls.Add(this.progressBarReading, 0, 1);
            this.rfidButtonLayout.Controls.Add(this.lblReaderStatus, 0, 2);
            this.rfidButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rfidButtonLayout.Location = new System.Drawing.Point(20, 15);
            this.rfidButtonLayout.Name = "rfidButtonLayout";
            this.rfidButtonLayout.RowCount = 3;
            this.rfidButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.rfidButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.rfidButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rfidButtonLayout.Size = new System.Drawing.Size(562, 110);
            this.rfidButtonLayout.TabIndex = 0;
            //
            // btnConnect
            //
            this.btnConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConnect.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConnect.Depth = 0;
            this.btnConnect.HighEmphasis = true;
            this.btnConnect.Icon = null;
            this.btnConnect.Location = new System.Drawing.Point(6, 6);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6);
            this.btnConnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConnect.Size = new System.Drawing.Size(138, 36);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "CONNECT READER";
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
            this.btnStartReading.HighEmphasis = false;
            this.btnStartReading.Icon = null;
            this.btnStartReading.Location = new System.Drawing.Point(193, 6);
            this.btnStartReading.Margin = new System.Windows.Forms.Padding(6);
            this.btnStartReading.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartReading.Name = "btnStartReading";
            this.btnStartReading.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStartReading.Size = new System.Drawing.Size(110, 36);
            this.btnStartReading.TabIndex = 1;
            this.btnStartReading.Text = "START SCAN";
            this.btnStartReading.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnStartReading.UseAccentColor = false;
            this.btnStartReading.UseVisualStyleBackColor = true;
            this.btnStartReading.Click += new System.EventHandler(this.btnStartReading_Click);
            //
            // btnStopReading
            //
            this.btnStopReading.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStopReading.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStopReading.Depth = 0;
            this.btnStopReading.HighEmphasis = false;
            this.btnStopReading.Icon = null;
            this.btnStopReading.Location = new System.Drawing.Point(380, 6);
            this.btnStopReading.Margin = new System.Windows.Forms.Padding(6);
            this.btnStopReading.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStopReading.Name = "btnStopReading";
            this.btnStopReading.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStopReading.Size = new System.Drawing.Size(103, 36);
            this.btnStopReading.TabIndex = 2;
            this.btnStopReading.Text = "STOP SCAN";
            this.btnStopReading.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnStopReading.UseAccentColor = false;
            this.btnStopReading.UseVisualStyleBackColor = true;
            this.btnStopReading.Click += new System.EventHandler(this.btnStopReading_Click);
            //
            // progressBarReading
            //
            this.progressBarReading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rfidButtonLayout.SetColumnSpan(this.progressBarReading, 3);
            this.progressBarReading.Location = new System.Drawing.Point(4, 53);
            this.progressBarReading.Margin = new System.Windows.Forms.Padding(4, 5, 4, 10);
            this.progressBarReading.MarqueeAnimationSpeed = 30;
            this.progressBarReading.Name = "progressBarReading";
            this.progressBarReading.Size = new System.Drawing.Size(554, 15);
            this.progressBarReading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarReading.TabIndex = 3;
            this.progressBarReading.Visible = false;
            //
            // lblReaderStatus
            //
            this.lblReaderStatus.AutoSize = true;
            this.rfidButtonLayout.SetColumnSpan(this.lblReaderStatus, 3);
            this.lblReaderStatus.Depth = 0;
            this.lblReaderStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblReaderStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblReaderStatus.Location = new System.Drawing.Point(4, 83);
            this.lblReaderStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.lblReaderStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblReaderStatus.Name = "lblReaderStatus";
            this.lblReaderStatus.Size = new System.Drawing.Size(139, 19);
            this.lblReaderStatus.TabIndex = 4;
            this.lblReaderStatus.Text = "Reader: Disconnected";
            //
            // txtRfid
            //
            this.txtRfid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRfid.AnimateReadOnly = false;
            this.txtRfid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRfid.Depth = 0;
            this.txtRfid.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtRfid.Hint = "EPC (akan terisi otomatis saat scan)";
            this.txtRfid.LeadingIcon = null;
            this.txtRfid.Location = new System.Drawing.Point(4, 244);
            this.txtRfid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 20);
            this.txtRfid.MaxLength = 50;
            this.txtRfid.MinimumSize = new System.Drawing.Size(0, 50);
            this.txtRfid.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRfid.Multiline = false;
            this.txtRfid.Name = "txtRfid";
            this.txtRfid.Size = new System.Drawing.Size(602, 50);
            this.txtRfid.TabIndex = 2;
            this.txtRfid.Text = "";
            this.txtRfid.TrailingIcon = null;
            //
            // txtTid
            //
            this.txtTid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTid.AnimateReadOnly = false;
            this.txtTid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTid.Depth = 0;
            this.txtTid.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTid.Hint = "TID (akan terisi otomatis saat scan)";
            this.txtTid.LeadingIcon = null;
            this.txtTid.Location = new System.Drawing.Point(4, 319);
            this.txtTid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 20);
            this.txtTid.MaxLength = 50;
            this.txtTid.MinimumSize = new System.Drawing.Size(0, 50);
            this.txtTid.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTid.Multiline = false;
            this.txtTid.Name = "txtTid";
            this.txtTid.Size = new System.Drawing.Size(602, 50);
            this.txtTid.TabIndex = 3;
            this.txtTid.Text = "";
            this.txtTid.TrailingIcon = null;
            //
            // cardParticipantInfo
            //
            this.cardParticipantInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardParticipantInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cardParticipantInfo.Controls.Add(this.participantInfoLayout);
            this.cardParticipantInfo.Depth = 0;
            this.cardParticipantInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardParticipantInfo.Location = new System.Drawing.Point(4, 394);
            this.cardParticipantInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 20);
            this.cardParticipantInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardParticipantInfo.Name = "cardParticipantInfo";
            this.cardParticipantInfo.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.cardParticipantInfo.Size = new System.Drawing.Size(602, 120);
            this.cardParticipantInfo.TabIndex = 4;
            //
            // participantInfoLayout
            //
            this.participantInfoLayout.ColumnCount = 2;
            this.participantInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.participantInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.participantInfoLayout.Controls.Add(this.lblNameTitle, 0, 0);
            this.participantInfoLayout.Controls.Add(this.lblParticipantName, 1, 0);
            this.participantInfoLayout.Controls.Add(this.lblBibTitle, 0, 1);
            this.participantInfoLayout.Controls.Add(this.lblBibNumber, 1, 1);
            this.participantInfoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.participantInfoLayout.Location = new System.Drawing.Point(20, 20);
            this.participantInfoLayout.Name = "participantInfoLayout";
            this.participantInfoLayout.RowCount = 2;
            this.participantInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.participantInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.participantInfoLayout.Size = new System.Drawing.Size(562, 80);
            this.participantInfoLayout.TabIndex = 0;
            //
            // lblNameTitle
            //
            this.lblNameTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Depth = 0;
            this.lblNameTitle.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblNameTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.lblNameTitle.Location = new System.Drawing.Point(4, 10);
            this.lblNameTitle.Margin = new System.Windows.Forms.Padding(4, 0, 20, 0);
            this.lblNameTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(105, 17);
            this.lblNameTitle.TabIndex = 0;
            this.lblNameTitle.Text = "Nama Peserta:";
            //
            // lblParticipantName
            //
            this.lblParticipantName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblParticipantName.AutoSize = true;
            this.lblParticipantName.Depth = 0;
            this.lblParticipantName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblParticipantName.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblParticipantName.Location = new System.Drawing.Point(133, 9);
            this.lblParticipantName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParticipantName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblParticipantName.Name = "lblParticipantName";
            this.lblParticipantName.Size = new System.Drawing.Size(12, 19);
            this.lblParticipantName.TabIndex = 1;
            this.lblParticipantName.Text = "-";
            //
            // lblBibTitle
            //
            this.lblBibTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBibTitle.AutoSize = true;
            this.lblBibTitle.Depth = 0;
            this.lblBibTitle.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblBibTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.lblBibTitle.Location = new System.Drawing.Point(4, 51);
            this.lblBibTitle.Margin = new System.Windows.Forms.Padding(4, 0, 20, 0);
            this.lblBibTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBibTitle.Name = "lblBibTitle";
            this.lblBibTitle.Size = new System.Drawing.Size(88, 17);
            this.lblBibTitle.TabIndex = 2;
            this.lblBibTitle.Text = "BIB Number:";
            //
            // lblBibNumber
            //
            this.lblBibNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBibNumber.AutoSize = true;
            this.lblBibNumber.Depth = 0;
            this.lblBibNumber.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBibNumber.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblBibNumber.Location = new System.Drawing.Point(133, 50);
            this.lblBibNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBibNumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBibNumber.Name = "lblBibNumber";
            this.lblBibNumber.Size = new System.Drawing.Size(12, 19);
            this.lblBibNumber.TabIndex = 3;
            this.lblBibNumber.Text = "-";
            //
            // buttonLayout
            //
            this.buttonLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLayout.AutoSize = true;
            this.buttonLayout.ColumnCount = 3;
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonLayout.Controls.Add(this.btnCheckRfid, 0, 0);
            this.buttonLayout.Controls.Add(this.btnClear, 1, 0);
            this.buttonLayout.Location = new System.Drawing.Point(0, 539);
            this.buttonLayout.Margin = new System.Windows.Forms.Padding(0, 5, 0, 30);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.RowCount = 1;
            this.buttonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonLayout.Size = new System.Drawing.Size(610, 48);
            this.buttonLayout.TabIndex = 5;
            //
            // btnCheckRfid
            //
            this.btnCheckRfid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCheckRfid.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCheckRfid.Depth = 0;
            this.btnCheckRfid.HighEmphasis = true;
            this.btnCheckRfid.Icon = null;
            this.btnCheckRfid.Location = new System.Drawing.Point(6, 6);
            this.btnCheckRfid.Margin = new System.Windows.Forms.Padding(6);
            this.btnCheckRfid.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCheckRfid.Name = "btnCheckRfid";
            this.btnCheckRfid.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCheckRfid.Size = new System.Drawing.Size(109, 36);
            this.btnCheckRfid.TabIndex = 0;
            this.btnCheckRfid.Text = "CHECK BIB";
            this.btnCheckRfid.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCheckRfid.UseAccentColor = false;
            this.btnCheckRfid.UseVisualStyleBackColor = true;
            this.btnCheckRfid.Click += new System.EventHandler(this.btnCheckRfid_Click);
            //
            // btnClear
            //
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClear.Depth = 0;
            this.btnClear.HighEmphasis = false;
            this.btnClear.Icon = null;
            this.btnClear.Location = new System.Drawing.Point(127, 6);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(66, 36);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "CLEAR";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // progressBar
            //
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(4, 622);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 15);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(602, 15);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            //
            // lblStatus
            //
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Depth = 0;
            this.lblStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(4, 657);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(146, 19);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Siap untuk memeriksa BIB";
            //
            // cekRfid
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 850);
            this.Controls.Add(this.cardMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(600, 700);
            this.Name = "cekRfid";
            this.Padding = new System.Windows.Forms.Padding(4, 98, 4, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFID BIB Checker";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.cekRfid_Load);
            this.cardMain.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.cardRfidReader.ResumeLayout(false);
            this.rfidButtonLayout.ResumeLayout(false);
            this.rfidButtonLayout.PerformLayout();
            this.cardParticipantInfo.ResumeLayout(false);
            this.participantInfoLayout.ResumeLayout(false);
            this.participantInfoLayout.PerformLayout();
            this.buttonLayout.ResumeLayout(false);
            this.buttonLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}