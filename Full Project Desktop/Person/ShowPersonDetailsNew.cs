using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Project_Desktop
{
    public partial class ShowPersonDetailsNew : Form
    {
        public ShowPersonDetailsNew(int PersonID)
        {
            InitializeComponent();
            ctrlPersonDetails1.LoadPersonInfo(PersonID);
        }

        public ShowPersonDetailsNew(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonDetails1.LoadPersonInfo(NationalNo);
        }


      

        private void ShowPersonDetailsNew_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
