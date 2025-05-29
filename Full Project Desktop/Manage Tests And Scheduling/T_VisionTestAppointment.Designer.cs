namespace Full_Project_Desktop
{
    partial class Schedule_Vision_Test
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.dgvVisionTestAppointement = new System.Windows.Forms.DataGridView();
            this.cmsAppointementsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.ctrl_T_VisionTestAppointment1 = new Full_Project_Desktop.ctrl_T_VisionTestAppointment();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisionTestAppointement)).BeginInit();
            this.cmsAppointementsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(430, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 44);
            this.label1.TabIndex = 67;
            this.label1.Text = "Vision Test Appointments";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecords.ForeColor = System.Drawing.Color.Red;
            this.lblCountRecords.Location = new System.Drawing.Point(222, 796);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(111, 23);
            this.lblCountRecords.TabIndex = 71;
            this.lblCountRecords.Text = "??";
            this.lblCountRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCountRecords.Click += new System.EventHandler(this.LblCountRecords_Click);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(92, 796);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 23);
            this.label27.TabIndex = 69;
            this.label27.Text = "# Records :";
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(109, 646);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(144, 23);
            this.label28.TabIndex = 72;
            this.label28.Text = "Appointments:";
            // 
            // dgvVisionTestAppointement
            // 
            this.dgvVisionTestAppointement.AllowUserToAddRows = false;
            this.dgvVisionTestAppointement.AllowUserToDeleteRows = false;
            this.dgvVisionTestAppointement.AllowUserToOrderColumns = true;
            this.dgvVisionTestAppointement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisionTestAppointement.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVisionTestAppointement.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVisionTestAppointement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVisionTestAppointement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisionTestAppointement.ContextMenuStrip = this.cmsAppointementsTable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVisionTestAppointement.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVisionTestAppointement.Location = new System.Drawing.Point(96, 672);
            this.dgvVisionTestAppointement.Name = "dgvVisionTestAppointement";
            this.dgvVisionTestAppointement.ReadOnly = true;
            this.dgvVisionTestAppointement.Size = new System.Drawing.Size(990, 117);
            this.dgvVisionTestAppointement.TabIndex = 78;
            this.dgvVisionTestAppointement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVisionTestAppointement_CellClick);
            this.dgvVisionTestAppointement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVisionTestAppointement_CellContentClick);
            this.dgvVisionTestAppointement.Click += new System.EventHandler(this.DgvVisionTestAppointement_Click);
            // 
            // cmsAppointementsTable
            // 
            this.cmsAppointementsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1,
            this.takeTestToolStripMenuItem1});
            this.cmsAppointementsTable.Name = "cmsAppointementsTable";
            this.cmsAppointementsTable.Size = new System.Drawing.Size(121, 48);
            this.cmsAppointementsTable.Opening += new System.ComponentModel.CancelEventHandler(this.CmsAppointementsTable_Opening);
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 79;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Custom_Icon_Design_Pretty_Office_5_Schedule_128;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(1022, 625);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(59, 44);
            this.pictureBox7.TabIndex = 75;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.PictureBox7_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(984, 795);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 70;
            this.button1.Text = "   Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Microsoft_Fluentui_Emoji_Flat_Eye_Flat_512;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox10.Location = new System.Drawing.Point(435, 12);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(309, 135);
            this.pictureBox10.TabIndex = 68;
            this.pictureBox10.TabStop = false;
            // 
            // pbRefresh
            // 
            this.pbRefresh.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Graphicloads_Colorful_Long_Shadow_Arrow_reload_2_64;
            this.pbRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbRefresh.Location = new System.Drawing.Point(929, 625);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(59, 44);
            this.pbRefresh.TabIndex = 80;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.PbRefresh_Click);
            // 
            // ctrl_T_VisionTestAppointment1
            // 
            this.ctrl_T_VisionTestAppointment1.Location = new System.Drawing.Point(109, 204);
            this.ctrl_T_VisionTestAppointment1.Name = "ctrl_T_VisionTestAppointment1";
            this.ctrl_T_VisionTestAppointment1.Size = new System.Drawing.Size(988, 415);
            this.ctrl_T_VisionTestAppointment1.TabIndex = 77;
            this.ctrl_T_VisionTestAppointment1.Load += new System.EventHandler(this.Ctrl_T_VisionTestAppointment1_Load);
            // 
            // Schedule_Vision_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 881);
            this.Controls.Add(this.pbRefresh);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgvVisionTestAppointement);
            this.Controls.Add(this.ctrl_T_VisionTestAppointment1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.label1);
            this.Name = "Schedule_Vision_Test";
            this.Text = "Schedule_Vision_Test";
            this.Load += new System.EventHandler(this.Schedule_Vision_Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisionTestAppointement)).EndInit();
            this.cmsAppointementsTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label lblCountRecords;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.PictureBox pictureBox7;
        private ctrl_T_VisionTestAppointment ctrl_T_VisionTestAppointment1;
        private System.Windows.Forms.DataGridView dgvVisionTestAppointement;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ContextMenuStrip cmsAppointementsTable;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pbRefresh;
    }
}