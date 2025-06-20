namespace Full_Project_Desktop
{
    partial class frmSchedueTest
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
            this.ctrlSchedueTest1 = new Full_Project_Desktop.CtrlSchedueTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlSchedueTest1
            // 
            this.ctrlSchedueTest1.Location = new System.Drawing.Point(28, 12);
            this.ctrlSchedueTest1.Name = "ctrlSchedueTest1";
            this.ctrlSchedueTest1.Size = new System.Drawing.Size(780, 808);
            this.ctrlSchedueTest1.TabIndex = 0;
            this.ctrlSchedueTest1.TestTypeID = BusinessLayer.clsTestTypes.enTestType.WrittenTest;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Full_Project_Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.Location = new System.Drawing.Point(486, 826);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 40);
            this.btnClose.TabIndex = 110;
            this.btnClose.Text = "   Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseMnemonic = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSchedueTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 881);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlSchedueTest1);
            this.Name = "frmSchedueTest";
            this.Text = "frmSchedueTest";
            this.Load += new System.EventHandler(this.frmSchedueTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlSchedueTest ctrlSchedueTest1;
        private System.Windows.Forms.Button btnClose;
    }
}