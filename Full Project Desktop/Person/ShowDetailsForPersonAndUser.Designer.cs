namespace Full_Project_Desktop
{
    partial class ShowDetailsForPersonAndUser
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
            this.ctrlPersonAndUserInformation1 = new Full_Project_Desktop.ctrlPersonAndUserInformation();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlPersonAndUserInformation1
            // 
            this.ctrlPersonAndUserInformation1.Location = new System.Drawing.Point(46, 86);
            this.ctrlPersonAndUserInformation1.Name = "ctrlPersonAndUserInformation1";
            this.ctrlPersonAndUserInformation1.Size = new System.Drawing.Size(1065, 477);
            this.ctrlPersonAndUserInformation1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(388, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 55);
            this.label1.TabIndex = 36;
            this.label1.Text = "Person And User Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowDetailsForPersonAndUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1164, 591);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonAndUserInformation1);
            this.Name = "ShowDetailsForPersonAndUser";
            this.Text = "Show Details For Person And User";
            this.Load += new System.EventHandler(this.ShowDetailsForPersonAndUser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonAndUserInformation ctrlPersonAndUserInformation1;
        private System.Windows.Forms.Label label1;
    }
}