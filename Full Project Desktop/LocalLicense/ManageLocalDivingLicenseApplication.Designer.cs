namespace Full_Project_Desktop
{
    partial class ManageLocalDivingLicenseApplication
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsLocalDriving = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemForAllTests = new System.Windows.Forms.ToolStripMenuItem();
            this.schduleVisionTestToolStripMenuItemVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestChoice = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestChoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLocalDrivingLicenseApplication = new System.Windows.Forms.DataGridView();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedulingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.cmsLocalDriving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(548, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 43);
            this.label4.TabIndex = 37;
            this.label4.Text = "Local Driving License Application";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(296, 276);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(173, 23);
            this.txtFilter.TabIndex = 34;
            this.txtFilter.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 585);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 33;
            this.label3.Text = "# Records :";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "L D L AppID",
            "National No",
            "FullName",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(85, 275);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(166, 27);
            this.cbFilter.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Filter By :";
            // 
            // cmsLocalDriving
            // 
            this.cmsLocalDriving.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLocalDriving.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItemForAllTests,
            this.toolStripMenuItem3,
            this.issueDrivingLicenseToolStripMenuItem,
            this.toolStripMenuItem4,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsLocalDriving.Name = "contextMenuStrip1";
            this.cmsLocalDriving.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsLocalDriving.Size = new System.Drawing.Size(293, 226);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::Full_Project_Desktop.Properties.Resources.PersonDetails_321;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.showDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(289, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Full_Project_Desktop.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.editToolStripMenuItem.Text = "Edit Application";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Full_Project_Desktop.Properties.Resources.Delete_32_2;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.deleteToolStripMenuItem.Text = "Delete Application";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::Full_Project_Desktop.Properties.Resources.Delete_321;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.CancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(289, 6);
            // 
            // toolStripMenuItemForAllTests
            // 
            this.toolStripMenuItemForAllTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schduleVisionTestToolStripMenuItemVisionTest,
            this.scheduleWrittenTestChoice,
            this.scheduleStreetTestChoice});
            this.toolStripMenuItemForAllTests.Image = global::Full_Project_Desktop.Properties.Resources.Schedule_Test_32;
            this.toolStripMenuItemForAllTests.Name = "toolStripMenuItemForAllTests";
            this.toolStripMenuItemForAllTests.Size = new System.Drawing.Size(292, 24);
            this.toolStripMenuItemForAllTests.Text = "Schedule Tests";
            this.toolStripMenuItemForAllTests.Click += new System.EventHandler(this.ToolStripMenuItem6_Click);
            // 
            // schduleVisionTestToolStripMenuItemVisionTest
            // 
            this.schduleVisionTestToolStripMenuItemVisionTest.Image = global::Full_Project_Desktop.Properties.Resources.Microsoft_Fluentui_Emoji_Flat_Eye_Flat_96;
            this.schduleVisionTestToolStripMenuItemVisionTest.Name = "schduleVisionTestToolStripMenuItemVisionTest";
            this.schduleVisionTestToolStripMenuItemVisionTest.Size = new System.Drawing.Size(221, 24);
            this.schduleVisionTestToolStripMenuItemVisionTest.Text = "Schedule Vision Test";
            this.schduleVisionTestToolStripMenuItemVisionTest.Click += new System.EventHandler(this.SchduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestChoice
            // 
            this.scheduleWrittenTestChoice.Image = global::Full_Project_Desktop.Properties.Resources.Schedule_Test_321;
            this.scheduleWrittenTestChoice.Name = "scheduleWrittenTestChoice";
            this.scheduleWrittenTestChoice.Size = new System.Drawing.Size(221, 24);
            this.scheduleWrittenTestChoice.Text = "Schedule Written Test";
            this.scheduleWrittenTestChoice.Click += new System.EventHandler(this.ScheduleWrittenTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestChoice
            // 
            this.scheduleStreetTestChoice.Image = global::Full_Project_Desktop.Properties.Resources.Street_Test_32;
            this.scheduleStreetTestChoice.Name = "scheduleStreetTestChoice";
            this.scheduleStreetTestChoice.Size = new System.Drawing.Size(221, 24);
            this.scheduleStreetTestChoice.Text = "Schedule Street Test";
            this.scheduleStreetTestChoice.Click += new System.EventHandler(this.ScheduleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(289, 6);
            // 
            // issueDrivingLicenseToolStripMenuItem
            // 
            this.issueDrivingLicenseToolStripMenuItem.Image = global::Full_Project_Desktop.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseToolStripMenuItem.Name = "issueDrivingLicenseToolStripMenuItem";
            this.issueDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.issueDrivingLicenseToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.issueDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.IssueDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(289, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::Full_Project_Desktop.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.ShowLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(289, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::Full_Project_Desktop.Properties.Resources.Paomedia_Small_N_Flat_User_id1;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.ShowPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // dgvLocalDrivingLicenseApplication
            // 
            this.dgvLocalDrivingLicenseApplication.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplication.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplication.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseApplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalDrivingLicenseApplication.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLocalDrivingLicenseApplication.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLocalDrivingLicenseApplication.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDrivingLicenseApplication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDrivingLicenseApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplication.ContextMenuStrip = this.cmsLocalDriving;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDrivingLicenseApplication.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalDrivingLicenseApplication.Location = new System.Drawing.Point(13, 302);
            this.dgvLocalDrivingLicenseApplication.Name = "dgvLocalDrivingLicenseApplication";
            this.dgvLocalDrivingLicenseApplication.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplication.Size = new System.Drawing.Size(1294, 239);
            this.dgvLocalDrivingLicenseApplication.TabIndex = 38;
            this.dgvLocalDrivingLicenseApplication.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLocalDrivingLicenseApplication_CellClick);
            this.dgvLocalDrivingLicenseApplication.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLocalDrivingLicenseApplication_CellContentClick);
            this.dgvLocalDrivingLicenseApplication.Click += new System.EventHandler(this.DgvLocalDrivingLicenseApplication_Click);
            // 
            // pbRefresh
            // 
            this.pbRefresh.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Graphicloads_Colorful_Long_Shadow_Arrow_reload_2_64;
            this.pbRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbRefresh.Location = new System.Drawing.Point(1092, 241);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(79, 55);
            this.pbRefresh.TabIndex = 40;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.PbRefresh_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Elegantthemes_Beautiful_Flat_News_512;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(527, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 216);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(1198, 576);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 35;
            this.button1.Text = "   Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.New_Application_641;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(1216, 241);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(79, 55);
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(79, 22);
            this.sToolStripMenuItem.Text = "s";
            // 
            // schedulingToolStripMenuItem
            // 
            this.schedulingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sToolStripMenuItem});
            this.schedulingToolStripMenuItem.Image = global::Full_Project_Desktop.Properties.Resources.Schedule_Test_512;
            this.schedulingToolStripMenuItem.Name = "schedulingToolStripMenuItem";
            this.schedulingToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.schedulingToolStripMenuItem.Text = "Schedule Tests";
            this.schedulingToolStripMenuItem.Click += new System.EventHandler(this.SchedulingToolStripMenuItem_Click);
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecords.ForeColor = System.Drawing.Color.Red;
            this.lblCountRecords.Location = new System.Drawing.Point(127, 585);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(112, 23);
            this.lblCountRecords.TabIndex = 41;
            this.lblCountRecords.Text = "??";
            this.lblCountRecords.Click += new System.EventHandler(this.LblCountRecords_Click);
            // 
            // ManageLocalDivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1350, 830);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.pbRefresh);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplication);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Name = "ManageLocalDivingLicenseApplication";
            this.Text = "Manage Local Diving License Application";
            this.Load += new System.EventHandler(this.LocalDivingLicenseApplication_Load);
            this.cmsLocalDriving.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsLocalDriving;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemForAllTests;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedulingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schduleVisionTestToolStripMenuItemVisionTest;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestChoice;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestChoice;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplication;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.Label lblCountRecords;
    }
}