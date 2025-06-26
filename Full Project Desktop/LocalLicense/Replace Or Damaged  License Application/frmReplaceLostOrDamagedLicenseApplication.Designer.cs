namespace Full_Project_Desktop
{
    partial class frmReplaceLostOrDamagedLicenseApplication
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
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbtnLostLicense = new System.Windows.Forms.RadioButton();
            this.rbtnDamagedLicense = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblLRApplicationID = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlDriverLicenseInfoWithFilter1 = new Full_Project_Desktop.CtrlDriverLicenseInfoWithFilter();
            this.gbReplacementFor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            this.SuspendLayout();
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseInfo.Location = new System.Drawing.Point(357, 780);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(210, 26);
            this.llShowLicenseInfo.TabIndex = 131;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show New  Licenses Info";
            this.llShowLicenseInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseHistory.Location = new System.Drawing.Point(85, 780);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(183, 26);
            this.llShowLicenseHistory.TabIndex = 130;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show Licenses History";
            this.llShowLicenseHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbtnLostLicense);
            this.gbReplacementFor.Controls.Add(this.rbtnDamagedLicense);
            this.gbReplacementFor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacementFor.Location = new System.Drawing.Point(906, 0);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(179, 95);
            this.gbReplacementFor.TabIndex = 128;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Replacement For";
            // 
            // rbtnLostLicense
            // 
            this.rbtnLostLicense.AutoSize = true;
            this.rbtnLostLicense.Location = new System.Drawing.Point(18, 52);
            this.rbtnLostLicense.Name = "rbtnLostLicense";
            this.rbtnLostLicense.Size = new System.Drawing.Size(112, 23);
            this.rbtnLostLicense.TabIndex = 1;
            this.rbtnLostLicense.TabStop = true;
            this.rbtnLostLicense.Text = "Lost License";
            this.rbtnLostLicense.UseVisualStyleBackColor = true;
            this.rbtnLostLicense.CheckedChanged += new System.EventHandler(this.rbtnLostLicense_CheckedChanged);
            // 
            // rbtnDamagedLicense
            // 
            this.rbtnDamagedLicense.AutoSize = true;
            this.rbtnDamagedLicense.Location = new System.Drawing.Point(18, 26);
            this.rbtnDamagedLicense.Name = "rbtnDamagedLicense";
            this.rbtnDamagedLicense.Size = new System.Drawing.Size(150, 23);
            this.rbtnDamagedLicense.TabIndex = 0;
            this.rbtnDamagedLicense.TabStop = true;
            this.rbtnDamagedLicense.Text = "Damaged License";
            this.rbtnDamagedLicense.UseVisualStyleBackColor = true;
            this.rbtnDamagedLicense.CheckedChanged += new System.EventHandler(this.rbtnDamagedLicense_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(283, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(565, 60);
            this.lblTitle.TabIndex = 127;
            this.lblTitle.Text = "Replacement For Damaged License";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.label44_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox24);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox22);
            this.groupBox2.Controls.Add(this.lblOldLicenseID);
            this.groupBox2.Controls.Add(this.lblReplacedLicenseID);
            this.groupBox2.Controls.Add(this.pictureBox7);
            this.groupBox2.Controls.Add(this.lblApplicationDate);
            this.groupBox2.Controls.Add(this.lblApplicationFees);
            this.groupBox2.Controls.Add(this.lblCreatedBy);
            this.groupBox2.Controls.Add(this.lblLRApplicationID);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.pictureBox14);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.pictureBox21);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(98, 617);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(978, 146);
            this.groupBox2.TabIndex = 126;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info For License Replacement";
            // 
            // pictureBox24
            // 
            this.pictureBox24.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Calendar_32;
            this.pictureBox24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox24.Location = new System.Drawing.Point(187, 65);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(37, 18);
            this.pictureBox24.TabIndex = 76;
            this.pictureBox24.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.LocalDriving_License1;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(769, 67);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(37, 18);
            this.pictureBox4.TabIndex = 74;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox22
            // 
            this.pictureBox22.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.User_32__21;
            this.pictureBox22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox22.Location = new System.Drawing.Point(769, 105);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(37, 18);
            this.pictureBox22.TabIndex = 50;
            this.pictureBox22.TabStop = false;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(832, 68);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(100, 23);
            this.lblOldLicenseID.TabIndex = 72;
            this.lblOldLicenseID.Text = "??";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacedLicenseID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(832, 31);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(100, 23);
            this.lblReplacedLicenseID.TabIndex = 71;
            this.lblReplacedLicenseID.Text = "??";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Number_32;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(187, 32);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(37, 18);
            this.pictureBox7.TabIndex = 70;
            this.pictureBox7.TabStop = false;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(241, 65);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(136, 23);
            this.lblApplicationDate.TabIndex = 65;
            this.lblApplicationDate.Text = "??";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblApplicationFees.Location = new System.Drawing.Point(242, 100);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(100, 23);
            this.lblApplicationFees.TabIndex = 67;
            this.lblApplicationFees.Text = "??";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Red;
            this.lblCreatedBy.Location = new System.Drawing.Point(832, 103);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(100, 23);
            this.lblCreatedBy.TabIndex = 68;
            this.lblCreatedBy.Text = "??";
            // 
            // lblLRApplicationID
            // 
            this.lblLRApplicationID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLRApplicationID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLRApplicationID.Location = new System.Drawing.Point(241, 32);
            this.lblLRApplicationID.Name = "lblLRApplicationID";
            this.lblLRApplicationID.Size = new System.Drawing.Size(100, 23);
            this.lblLRApplicationID.TabIndex = 69;
            this.lblLRApplicationID.Text = "??";
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(6, 65);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(160, 23);
            this.label36.TabIndex = 32;
            this.label36.Text = "Application Date :";
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(6, 100);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(174, 23);
            this.label38.TabIndex = 34;
            this.label38.Text = "Application Fees : ";
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.money_322;
            this.pictureBox14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox14.Location = new System.Drawing.Point(186, 100);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(37, 18);
            this.pictureBox14.TabIndex = 39;
            this.pictureBox14.TabStop = false;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(510, 31);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(231, 23);
            this.label40.TabIndex = 45;
            this.label40.Text = "Replaced License ID :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(6, 32);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(175, 23);
            this.label41.TabIndex = 53;
            this.label41.Text = "L.R.Application ID :";
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(510, 65);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(187, 23);
            this.label42.TabIndex = 46;
            this.label42.Text = "Old License ID :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(514, 100);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(147, 23);
            this.label43.TabIndex = 47;
            this.label43.Text = "Created By:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox21
            // 
            this.pictureBox21.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Renew_Driving_License_323;
            this.pictureBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox21.Location = new System.Drawing.Point(769, 31);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(37, 18);
            this.pictureBox21.TabIndex = 48;
            this.pictureBox21.TabStop = false;
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacement.Image = global::Full_Project_Desktop.Properties.Resources.Renew_Driving_License_324;
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(915, 780);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(165, 40);
            this.btnIssueReplacement.TabIndex = 132;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssueReplacement.UseMnemonic = false;
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(784, 780);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 129;
            this.button1.Text = "Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(98, 81);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(987, 530);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 133;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            this.ctrlDriverLicenseInfoWithFilter1.Load += new System.EventHandler(this.ctrlDriverLicenseInfoWithFilter1_Load);
            // 
            // frmReplaceLostOrDamagedLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 881);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmReplaceLostOrDamagedLicenseApplication";
            this.Text = "frmReplaceLostOrDamagedLicenseApplication";
            this.Load += new System.EventHandler(this.frmReplaceLostOrDamagedLicenseApplication_Load);
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbtnLostLicense;
        private System.Windows.Forms.RadioButton rbtnDamagedLicense;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox24;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblLRApplicationID;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.PictureBox pictureBox21;
    }
}