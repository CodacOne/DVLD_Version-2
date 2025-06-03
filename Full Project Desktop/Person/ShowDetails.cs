using System;
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
    public partial class ShowDetails : Form
    {
        private int _PersonID=-1;

        public ShowDetails(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            usclPersonDetails1.LoadPersonInfo(_PersonID);
            
        }
        /*/*/////*/*/////*/*/////*/*/////*/*/////*/*/////*/*/////*/*////
        public ShowDetails(string NationalNo)
        {
            InitializeComponent();

            usclPersonDetails1.LoadPersonInfo(NationalNo);

        }
        /*/*/////*/*/////*/*/////*/*/////*/*/////*/*/////*/*/////*/*////
        private void UsclPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void ShowDetails_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
