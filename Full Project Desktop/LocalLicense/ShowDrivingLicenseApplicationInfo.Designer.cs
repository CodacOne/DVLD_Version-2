namespace Full_Project_Desktop
{
    partial class ShowDrivingLicenseApplicationInfo
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
            this.ctrl_T_VisionTestAppointment1 = new Full_Project_Desktop.ctrl_T_VisionTestAppointment();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrl_T_VisionTestAppointment1
            // 
            this.ctrl_T_VisionTestAppointment1.Location = new System.Drawing.Point(22, 12);
            this.ctrl_T_VisionTestAppointment1.Name = "ctrl_T_VisionTestAppointment1";
            this.ctrl_T_VisionTestAppointment1.Size = new System.Drawing.Size(988, 425);
            this.ctrl_T_VisionTestAppointment1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(879, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 18;
            this.button1.Text = "   Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ShowDrivingLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrl_T_VisionTestAppointment1);
            this.Name = "ShowDrivingLicenseApplicationInfo";
            this.Text = "ShowDrivingLicenseApplicationInfo";
            this.Load += new System.EventHandler(this.ShowDrivingLicenseApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrl_T_VisionTestAppointment ctrl_T_VisionTestAppointment1;
        private System.Windows.Forms.Button button1;
    }
}