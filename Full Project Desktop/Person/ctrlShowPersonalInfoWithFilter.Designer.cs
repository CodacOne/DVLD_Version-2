namespace Full_Project_Desktop
{
    partial class ctrlShowPersonalInfoWithFilter
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtBySearch = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlPersonDetails1 = new Full_Project_Desktop.ctrlPersonDetails();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.btnAdd);
            this.gbFilter.Controls.Add(this.txtBySearch);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.Controls.Add(this.label9);
            this.gbFilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(29, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(877, 97);
            this.gbFilter.TabIndex = 66;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            this.gbFilter.Enter += new System.EventHandler(this.GroupBox2_Enter);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Oxygen_Icons_org_Oxygen_Apps_preferences_desktop_user2;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Location = new System.Drawing.Point(631, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 32);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::Full_Project_Desktop.Properties.Resources.Custom_Icon_Design_Flatastic_4_Male_user_add1;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Location = new System.Drawing.Point(704, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(43, 32);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // txtBySearch
            // 
            this.txtBySearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBySearch.Location = new System.Drawing.Point(329, 41);
            this.txtBySearch.Multiline = true;
            this.txtBySearch.Name = "txtBySearch";
            this.txtBySearch.Size = new System.Drawing.Size(216, 23);
            this.txtBySearch.TabIndex = 12;
            this.txtBySearch.TextChanged += new System.EventHandler(this.TxtBySearch_TextChanged);
            this.txtBySearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBySearch_KeyPress);
            this.txtBySearch.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBySearch_Validating);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo"});
            this.cbFilter.Location = new System.Drawing.Point(84, 40);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(221, 27);
            this.cbFilter.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "Find By :";
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(17, 106);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(1057, 358);
            this.ctrlPersonDetails1.TabIndex = 67;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlShowPersonalInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrlShowPersonalInfoWithFilter";
            this.Size = new System.Drawing.Size(1077, 470);
            this.Load += new System.EventHandler(this.Ctrl2PersonalInfoWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txtBySearch;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
