namespace Full_Project_Desktop
{
    partial class LocalLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrl2PersonalInfoWithFilter1 = new Full_Project_Desktop.ctrl2PersonalInfoWithFilter();
            this.button1 = new System.Windows.Forms.Button();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblLocalDrivingApplication = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btnSaveurcl = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(357, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 60);
            this.label1.TabIndex = 15;
            this.label1.Text = "New Local Driving License Application";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPersonalInfo);
            this.tabControl1.Controls.Add(this.tpLoginInfo);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(34, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1137, 734);
            this.tabControl1.TabIndex = 85;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.AutoScroll = true;
            this.tpPersonalInfo.Controls.Add(this.ctrl2PersonalInfoWithFilter1);
            this.tpPersonalInfo.Controls.Add(this.button1);
            this.tpPersonalInfo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 32);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(1129, 698);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            this.tpPersonalInfo.UseVisualStyleBackColor = true;
            this.tpPersonalInfo.Click += new System.EventHandler(this.TpPersonalInfo_Click);
            // 
            // ctrl2PersonalInfoWithFilter1
            // 
            this.ctrl2PersonalInfoWithFilter1._PersonID = 0;
            this.ctrl2PersonalInfoWithFilter1.Location = new System.Drawing.Point(7, 33);
            this.ctrl2PersonalInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl2PersonalInfoWithFilter1.Name = "ctrl2PersonalInfoWithFilter1";
            this.ctrl2PersonalInfoWithFilter1.Size = new System.Drawing.Size(1159, 594);
            this.ctrl2PersonalInfoWithFilter1.TabIndex = 68;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Full_Project_Desktop.Properties.Resources.Next_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.button1.Location = new System.Drawing.Point(945, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 40);
            this.button1.TabIndex = 67;
            this.button1.Text = " Next ";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.Controls.Add(this.lblApplicationFees);
            this.tpLoginInfo.Controls.Add(this.lblCreatedBy);
            this.tpLoginInfo.Controls.Add(this.lblApplicationDate);
            this.tpLoginInfo.Controls.Add(this.cbLicenseClass);
            this.tpLoginInfo.Controls.Add(this.label18);
            this.tpLoginInfo.Controls.Add(this.lblLocalDrivingApplication);
            this.tpLoginInfo.Controls.Add(this.label16);
            this.tpLoginInfo.Controls.Add(this.label15);
            this.tpLoginInfo.Controls.Add(this.label10);
            this.tpLoginInfo.Controls.Add(this.label14);
            this.tpLoginInfo.Controls.Add(this.pictureBox10);
            this.tpLoginInfo.Controls.Add(this.pictureBox15);
            this.tpLoginInfo.Controls.Add(this.pictureBox14);
            this.tpLoginInfo.Controls.Add(this.pictureBox13);
            this.tpLoginInfo.Controls.Add(this.pictureBox11);
            this.tpLoginInfo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 32);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(1129, 698);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "LoginInfo";
            this.tpLoginInfo.UseVisualStyleBackColor = true;
            this.tpLoginInfo.Click += new System.EventHandler(this.TpLoginInfo_Click);
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Location = new System.Drawing.Point(320, 287);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(151, 29);
            this.lblApplicationFees.TabIndex = 37;
            this.lblApplicationFees.Text = "15";
            this.lblApplicationFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Red;
            this.lblCreatedBy.Location = new System.Drawing.Point(320, 353);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(151, 29);
            this.lblCreatedBy.TabIndex = 36;
            this.lblCreatedBy.Text = "???";
            this.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCreatedBy.Click += new System.EventHandler(this.Label3_Click);
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblApplicationDate.Location = new System.Drawing.Point(317, 153);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(151, 29);
            this.lblApplicationDate.TabIndex = 35;
            this.lblApplicationDate.Text = "???";
            this.lblApplicationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApplicationDate.Click += new System.EventHandler(this.Label2_Click);
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Items.AddRange(new object[] {
            "Class 1-Small Motorcycle License",
            "Class 2-Heavy Motorcycle License",
            "Class 3-Ordinary Driving License",
            "Class 4-Commercial",
            "Class 5-Agricultural",
            "Class 6-Small And Medium Bus",
            "Class 7-Truck And Heavy Vehicle"});
            this.cbLicenseClass.Location = new System.Drawing.Point(317, 219);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(304, 31);
            this.cbLicenseClass.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(35, 343);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(198, 41);
            this.label18.TabIndex = 31;
            this.label18.Text = "Created By:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocalDrivingApplication
            // 
            this.lblLocalDrivingApplication.Location = new System.Drawing.Point(317, 87);
            this.lblLocalDrivingApplication.Name = "lblLocalDrivingApplication";
            this.lblLocalDrivingApplication.Size = new System.Drawing.Size(151, 29);
            this.lblLocalDrivingApplication.TabIndex = 27;
            this.lblLocalDrivingApplication.Text = "???";
            this.lblLocalDrivingApplication.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLocalDrivingApplication.Click += new System.EventHandler(this.Label17_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(35, 278);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(198, 41);
            this.label16.TabIndex = 23;
            this.label16.Text = "Application Fees:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(31, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(202, 52);
            this.label15.TabIndex = 22;
            this.label15.Text = "D.L ApplicationID:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(35, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 41);
            this.label10.TabIndex = 17;
            this.label10.Text = "License Class:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(35, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(198, 51);
            this.label14.TabIndex = 16;
            this.label14.Text = "Application Date:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.User_32__2;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox10.Location = new System.Drawing.Point(259, 353);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(28, 32);
            this.pictureBox10.TabIndex = 33;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Renew_Driving_License_321;
            this.pictureBox15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox15.Location = new System.Drawing.Point(259, 220);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(28, 32);
            this.pictureBox15.TabIndex = 29;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.money_321;
            this.pictureBox14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox14.Location = new System.Drawing.Point(259, 288);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(28, 32);
            this.pictureBox14.TabIndex = 28;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Number_32;
            this.pictureBox13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox13.Location = new System.Drawing.Point(259, 84);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(28, 32);
            this.pictureBox13.TabIndex = 26;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Calendar_321;
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox11.Location = new System.Drawing.Point(259, 152);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(28, 32);
            this.pictureBox11.TabIndex = 18;
            this.pictureBox11.TabStop = false;
            // 
            // btnSaveurcl
            // 
            this.btnSaveurcl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveurcl.Image = global::Full_Project_Desktop.Properties.Resources.Save_32;
            this.btnSaveurcl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSaveurcl.Location = new System.Drawing.Point(1051, 798);
            this.btnSaveurcl.Name = "btnSaveurcl";
            this.btnSaveurcl.Size = new System.Drawing.Size(97, 40);
            this.btnSaveurcl.TabIndex = 84;
            this.btnSaveurcl.Text = "  Save";
            this.btnSaveurcl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveurcl.UseMnemonic = false;
            this.btnSaveurcl.UseVisualStyleBackColor = true;
            this.btnSaveurcl.Click += new System.EventHandler(this.BtnSaveurcl_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.Location = new System.Drawing.Point(918, 798);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 40);
            this.btnClose.TabIndex = 83;
            this.btnClose.Text = "   Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseMnemonic = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LocalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1156, 881);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSaveurcl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Name = "LocalLicense";
            this.Text = "LocalLicense";
            this.Load += new System.EventHandler(this.LocalLicense_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveurcl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.Label lblLocalDrivingApplication;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private ctrl2PersonalInfoWithFilter ctrl2PersonalInfoWithFilter1;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationDate;
    }
}