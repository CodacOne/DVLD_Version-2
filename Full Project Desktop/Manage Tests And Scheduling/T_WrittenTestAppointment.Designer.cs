namespace Full_Project_Desktop
{
    partial class T_WrittenTestAppointment
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
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.pbFotAddNewTest = new System.Windows.Forms.PictureBox();
            this.dgvForWrittenTest = new System.Windows.Forms.DataGridView();
            this.cmsWrittenTest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_T_VisionTestAppointment1 = new Full_Project_Desktop.ctrl_T_VisionTestAppointment();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotAddNewTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForWrittenTest)).BeginInit();
            this.cmsWrittenTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecords.ForeColor = System.Drawing.Color.Red;
            this.lblCountRecords.Location = new System.Drawing.Point(222, 789);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(111, 23);
            this.lblCountRecords.TabIndex = 83;
            this.lblCountRecords.Text = "??";
            this.lblCountRecords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(105, 791);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 23);
            this.label27.TabIndex = 81;
            this.label27.Text = "# Records :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(420, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 56);
            this.label1.TabIndex = 79;
            this.label1.Text = "Written Test Appointments";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Written_Test_512;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(378, 12);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(420, 135);
            this.pictureBox7.TabIndex = 85;
            this.pictureBox7.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(991, 803);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 82;
            this.button1.Text = "   Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Vision_Test_Schdule;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox10.Location = new System.Drawing.Point(418, -122);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(309, 114);
            this.pictureBox10.TabIndex = 80;
            this.pictureBox10.TabStop = false;
            // 
            // pbRefresh
            // 
            this.pbRefresh.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Graphicloads_Colorful_Long_Shadow_Arrow_reload_2_64;
            this.pbRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbRefresh.Location = new System.Drawing.Point(930, 612);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(59, 44);
            this.pbRefresh.TabIndex = 89;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.PbRefresh_Click);
            // 
            // pbFotAddNewTest
            // 
            this.pbFotAddNewTest.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Custom_Icon_Design_Pretty_Office_5_Schedule_128;
            this.pbFotAddNewTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbFotAddNewTest.Location = new System.Drawing.Point(1018, 612);
            this.pbFotAddNewTest.Name = "pbFotAddNewTest";
            this.pbFotAddNewTest.Size = new System.Drawing.Size(59, 44);
            this.pbFotAddNewTest.TabIndex = 88;
            this.pbFotAddNewTest.TabStop = false;
            this.pbFotAddNewTest.Click += new System.EventHandler(this.PbFotAddNewTest_Click);
            // 
            // dgvForWrittenTest
            // 
            this.dgvForWrittenTest.AllowUserToAddRows = false;
            this.dgvForWrittenTest.AllowUserToDeleteRows = false;
            this.dgvForWrittenTest.AllowUserToOrderColumns = true;
            this.dgvForWrittenTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvForWrittenTest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvForWrittenTest.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvForWrittenTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvForWrittenTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForWrittenTest.ContextMenuStrip = this.cmsWrittenTest;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvForWrittenTest.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvForWrittenTest.Location = new System.Drawing.Point(87, 669);
            this.dgvForWrittenTest.Name = "dgvForWrittenTest";
            this.dgvForWrittenTest.ReadOnly = true;
            this.dgvForWrittenTest.Size = new System.Drawing.Size(990, 117);
            this.dgvForWrittenTest.TabIndex = 90;
            this.dgvForWrittenTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvForWrittenTest_CellClick);
            this.dgvForWrittenTest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvForWrittenTest_CellContentClick);
            this.dgvForWrittenTest.Click += new System.EventHandler(this.DgvForWrittenTest_Click);
            // 
            // cmsWrittenTest
            // 
            this.cmsWrittenTest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1,
            this.takeTestToolStripMenuItem1});
            this.cmsWrittenTest.Name = "cmsAppointementsTable";
            this.cmsWrittenTest.Size = new System.Drawing.Size(121, 48);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Image = global::Full_Project_Desktop.Properties.Resources.icons8_test_results_50;
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.editToolStripMenuItem1.Text = "Edit ";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.EditToolStripMenuItem1_Click);
            // 
            // takeTestToolStripMenuItem1
            // 
            this.takeTestToolStripMenuItem1.Image = global::Full_Project_Desktop.Properties.Resources.Test_321;
            this.takeTestToolStripMenuItem1.Name = "takeTestToolStripMenuItem1";
            this.takeTestToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.takeTestToolStripMenuItem1.Text = "Take Test";
            this.takeTestToolStripMenuItem1.Click += new System.EventHandler(this.TakeTestToolStripMenuItem1_Click);
            // 
            // ctrl_T_VisionTestAppointment1
            // 
            this.ctrl_T_VisionTestAppointment1.Location = new System.Drawing.Point(100, 199);
            this.ctrl_T_VisionTestAppointment1.Name = "ctrl_T_VisionTestAppointment1";
            this.ctrl_T_VisionTestAppointment1.Size = new System.Drawing.Size(988, 425);
            this.ctrl_T_VisionTestAppointment1.TabIndex = 87;
            this.ctrl_T_VisionTestAppointment1.Load += new System.EventHandler(this.Ctrl_T_VisionTestAppointment1_Load);
            // 
            // T_WrittenTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1152, 881);
            this.Controls.Add(this.dgvForWrittenTest);
            this.Controls.Add(this.pbRefresh);
            this.Controls.Add(this.pbFotAddNewTest);
            this.Controls.Add(this.ctrl_T_VisionTestAppointment1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.label1);
            this.Name = "T_WrittenTestAppointment";
            this.Text = "WrittenTestAppointment";
            this.Load += new System.EventHandler(this.T_WrittenTestAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotAddNewTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForWrittenTest)).EndInit();
            this.cmsWrittenTest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblCountRecords;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private ctrl_T_VisionTestAppointment ctrl_T_VisionTestAppointment1;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.PictureBox pbFotAddNewTest;
        private System.Windows.Forms.DataGridView dgvForWrittenTest;
        private System.Windows.Forms.ContextMenuStrip cmsWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem1;
    }
}