namespace Full_Project_Desktop
{
    partial class IssueDriverLicenseForFirstTime
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
            this.btnIssuingSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrl_T_VisionTestAppointment1 = new Full_Project_Desktop.ctrl_T_VisionTestAppointment();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIssuingSave
            // 
            this.btnIssuingSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssuingSave.Image = global::Full_Project_Desktop.Properties.Resources.IssueDrivingLicense_321;
            this.btnIssuingSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIssuingSave.Location = new System.Drawing.Point(925, 601);
            this.btnIssuingSave.Name = "btnIssuingSave";
            this.btnIssuingSave.Size = new System.Drawing.Size(97, 40);
            this.btnIssuingSave.TabIndex = 94;
            this.btnIssuingSave.Text = "   Issue";
            this.btnIssuingSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssuingSave.UseMnemonic = false;
            this.btnIssuingSave.UseVisualStyleBackColor = true;
            this.btnIssuingSave.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(925, 665);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 90;
            this.button1.Text = "   Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ctrl_T_VisionTestAppointment1
            // 
            this.ctrl_T_VisionTestAppointment1.Location = new System.Drawing.Point(43, 160);
            this.ctrl_T_VisionTestAppointment1.Name = "ctrl_T_VisionTestAppointment1";
            this.ctrl_T_VisionTestAppointment1.Size = new System.Drawing.Size(988, 425);
            this.ctrl_T_VisionTestAppointment1.TabIndex = 95;
            this.ctrl_T_VisionTestAppointment1.Load += new System.EventHandler(this.Ctrl_T_VisionTestAppointment1_Load);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Graphicloads_Flat_Finance_Certificate_256;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(234, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(538, 149);
            this.pictureBox1.TabIndex = 96;
            this.pictureBox1.TabStop = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(43, 601);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(865, 104);
            this.txtNotes.TabIndex = 97;
            // 
            // IssueDriverLicenseForFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1054, 881);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrl_T_VisionTestAppointment1);
            this.Controls.Add(this.btnIssuingSave);
            this.Controls.Add(this.button1);
            this.Name = "IssueDriverLicenseForFirstTime";
            this.Text = "IssueDriverLicenseForFirstTime";
            this.Load += new System.EventHandler(this.IssueDriverLicenseForFirstTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIssuingSave;
        private ctrl_T_VisionTestAppointment ctrl_T_VisionTestAppointment1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNotes;
    }
}