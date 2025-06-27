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
    public partial class ShowLicenseHistory : Form
    {
       
        private int _PersonID = -1;
      
        public ShowLicenseHistory(int PersonID )
        {
            InitializeComponent();

            _PersonID = PersonID;
        }

        
        private void Ctrl2PersonalInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void ShowLicenseHistory_Load(object sender, EventArgs e)
        {

            if (_PersonID != -1)
            {
                
                ctrlPeronDetailsWithFilterNew1._LoadDataToForm(_PersonID);
              ctrlPeronDetailsWithFilterNew1.FilterEnabled = false;
                ctrlDriverLicense1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctrlPeronDetailsWithFilterNew1.Enabled = true;
                ctrlPeronDetailsWithFilterNew1.FilterFocus();
            }


        }

        private void CtrlDriverLicense1_Load(object sender, EventArgs e)
        {

        }
    }
}
