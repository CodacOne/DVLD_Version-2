﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;


namespace Full_Project_Desktop
{
    public partial class Manage_Aplication_Types : Form
    {
        public Manage_Aplication_Types()
        {
            InitializeComponent();
        }

        private void Ss_Click(object sender, EventArgs e)
        {

        }

        private void EditApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           int ApplicaionTypeID= (int)dgvApplicaionType.CurrentRow.Cells[0].Value;
            EditApplicationType frm = new EditApplicationType(ApplicaionTypeID);
            frm.Show();
        }


        /***//*/*//*//*////////////////////////////*/// <summary>
        private void  _RefreshApplicationList()
        {
         dgvApplicaionType.DataSource = clsLocalDrivingApplication.LocalDrivingApplictionType();
            lblCountRecords.Text = dgvApplicaionType.Rows.Count.ToString();
        }

        /// ////////////////////////////////

        private void Manage_Aplication_Types_Load(object sender, EventArgs e)
        {
            _RefreshApplicationList();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////


    }
}
