namespace Full_Project_Desktop
{
    partial class CtrlDriverLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.ctrlDriverInfo1 = new Full_Project_Desktop.CtrlDriverInfo();
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.txtLicenseID);
            this.gbFilters.Controls.Add(this.label45);
            this.gbFilters.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilters.Location = new System.Drawing.Point(3, 7);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(420, 69);
            this.gbFilters.TabIndex = 102;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseID.Location = new System.Drawing.Point(159, 26);
            this.txtLicenseID.Multiline = true;
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(159, 23);
            this.txtLicenseID.TabIndex = 12;
            this.txtLicenseID.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtLicenseID.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicenseID_Validating);
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(18, 26);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(109, 23);
            this.label45.TabIndex = 9;
            this.label45.Text = "License ID :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Oxygen_Icons_org_Oxygen_Apps_krfb1;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(739, 17);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(238, 70);
            this.pictureBox4.TabIndex = 101;
            this.pictureBox4.TabStop = false;
            // 
            // btnFind
            // 
            this.btnFind.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.License_View_324;
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFind.Location = new System.Drawing.Point(324, 16);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 47);
            this.btnFind.TabIndex = 13;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click_1);
            // 
            // ctrlDriverInfo1
            // 
            this.ctrlDriverInfo1.Location = new System.Drawing.Point(3, 82);
            this.ctrlDriverInfo1.Name = "ctrlDriverInfo1";
            this.ctrlDriverInfo1.Size = new System.Drawing.Size(983, 413);
            this.ctrlDriverInfo1.TabIndex = 103;
            this.ctrlDriverInfo1.Load += new System.EventHandler(this.ctrlDriverInfo1_Load);
            // 
            // CtrlDriverLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlDriverInfo1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.gbFilters);
            this.Name = "CtrlDriverLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(987, 518);
            this.Load += new System.EventHandler(this.CtrlDriverLicenseInfoWithFilter_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label label45;
        private CtrlDriverInfo ctrlDriverInfo1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
