﻿namespace Full_Project_Desktop
{
    partial class ShowLicenseHistory
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ctrlPeronDetailsWithFilterNew1 = new Full_Project_Desktop.CtrlPeronDetailsWithFilterNew();
            this.ctrlDriverLicense1 = new Full_Project_Desktop.ctrlDriverLicense();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.Location = new System.Drawing.Point(1001, 772);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 40);
            this.btnClose.TabIndex = 130;
            this.btnClose.Text = "   Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseMnemonic = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox10.Location = new System.Drawing.Point(12, 243);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(141, 223);
            this.pictureBox10.TabIndex = 66;
            this.pictureBox10.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(371, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(337, 41);
            this.label8.TabIndex = 131;
            this.label8.Text = " License History";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlPeronDetailsWithFilterNew1
            // 
            this.ctrlPeronDetailsWithFilterNew1._PersonID = 0;
            this.ctrlPeronDetailsWithFilterNew1.Location = new System.Drawing.Point(159, 53);
            this.ctrlPeronDetailsWithFilterNew1.Name = "ctrlPeronDetailsWithFilterNew1";
            this.ctrlPeronDetailsWithFilterNew1.Size = new System.Drawing.Size(984, 444);
            this.ctrlPeronDetailsWithFilterNew1.TabIndex = 133;
            // 
            // ctrlDriverLicense1
            // 
            this.ctrlDriverLicense1.Location = new System.Drawing.Point(128, 503);
            this.ctrlDriverLicense1.Name = "ctrlDriverLicense1";
            this.ctrlDriverLicense1.Size = new System.Drawing.Size(1015, 272);
            this.ctrlDriverLicense1.TabIndex = 134;
            // 
            // ShowLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1215, 881);
            this.Controls.Add(this.ctrlDriverLicense1);
            this.Controls.Add(this.ctrlPeronDetailsWithFilterNew1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox10);
            this.Name = "ShowLicenseHistory";
            this.Text = "ShowLicenseHistory";
            this.Load += new System.EventHandler(this.ShowLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox10;
     
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private CtrlPeronDetailsWithFilterNew ctrlPeronDetailsWithFilterNew1;
        private ctrlDriverLicense ctrlDriverLicense1;
    }
}