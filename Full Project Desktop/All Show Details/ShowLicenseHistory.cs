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
       // private int _Release_AppID = -1;

        private int _LocalDrivingLicenseApplicationID = -1;
        private DataTable _Dt = new DataTable();
        private clsPerson _Person;

        /*/*//*//*//*********************************************************//*/*///

        public ShowLicenseHistory(int LocalDrivingLicenseApplicationID,bool Status)
        {
            InitializeComponent();

            _Dt = clsLocalDrivingApplication.GetAllDataToSchedulingTest(LocalDrivingLicenseApplicationID);


            DataRow row = _Dt.Rows[0];

          int  PersonID = (int)row["PersonID"];
            int ApplicationID = (int)row["ApplicationID"];

            _Person = clsPerson.FindByPersonID(PersonID);

            if (_Person != null)
            {

                ctrl2PersonalInfoWithFilter1._LoadDataToForm(_Person);

            }

            ctrlDriverLicense1.FillDataToForm(PersonID);
        }

        /*/*//*//*//*********************************************************//*/*///

        /*/*//*//*//*********************************************************//*/*///

        /*/*//*//*//*********************************************************//*/*///
        public ShowLicenseHistory(int PersonID)
        {
            InitializeComponent();

          
            _Person = clsPerson.FindByPersonID(PersonID);

            if (_Person != null)
            {

                ctrl2PersonalInfoWithFilter1._LoadDataToForm(_Person);

            }

            ctrlDriverLicense1.FillDataToForm(PersonID);
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

        }

        private void CtrlDriverLicense1_Load(object sender, EventArgs e)
        {

        }
    }
}
