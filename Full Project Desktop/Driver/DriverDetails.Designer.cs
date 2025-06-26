namespace Full_Project_Desktop
{
    partial class DriverDetails
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
            this.label8 = new System.Windows.Forms.Label();
            this.ctrlDriverInfo1 = new Full_Project_Desktop.CtrlDriverInfo();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(313, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(337, 63);
            this.label8.TabIndex = 101;
            this.label8.Text = "Driver License Info";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlDriverInfo1
            // 
            this.ctrlDriverInfo1.Location = new System.Drawing.Point(29, 199);
            this.ctrlDriverInfo1.Name = "ctrlDriverInfo1";
            this.ctrlDriverInfo1.Size = new System.Drawing.Size(983, 399);
            this.ctrlDriverInfo1.TabIndex = 102;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(876, 604);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 103;
            this.button1.Text = "   Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.LicenseView_400;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox10.Location = new System.Drawing.Point(329, 12);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(309, 118);
            this.pictureBox10.TabIndex = 100;
            this.pictureBox10.TabStop = false;
            // 
            // DriverDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 648);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlDriverInfo1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox10);
            this.Name = "DriverDetails";
            this.Text = "DriverDetails";
            this.Load += new System.EventHandler(this.DriverDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox10;
        private CtrlDriverInfo ctrlDriverInfo1;
        private System.Windows.Forms.Button button1;
    }
}