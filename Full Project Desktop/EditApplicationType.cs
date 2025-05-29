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
    public partial class EditApplicationType : Form
    {
        public EditApplicationType()
        {
            InitializeComponent();
        }




        /*using DVLDBussinsLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Issue_Driving_License_For_The_First_Time: Form
    {
        private DataTable _GetTestAppointment;


        clsApplicationType _applicationType;

        clsLocalDrivingLicenseApplications_View _applications_View;

        clsLocalDrivingLicenseFullApplications_View _application;
        clsLicens licens;
        clsDriver Driver;
        private int _applicationID;


        public Issue_Driving_License_For_The_First_Time(clsLocalDrivingLicenseApplications_View application)
        {
            InitializeComponent();

            _applications_View = application;
        }


        public Issue_Driving_License_For_The_First_Time(int ApplicationID)
        {
            InitializeComponent();

            _applicationID = ApplicationID;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            licens = clsLicens.GetLicens(_applicationID);
```
            clsLicens Licens = new clsLicens
            {
               Licens.DriverID = licens.DriverID,
               Licens.IsActive = licens.IsActive,
               Licens.ApplicationID = licens.ApplicationID,```



                PaidFees=licens.PaidFees,
                IssueDate=licens.IssueDate,
                ExpirationDate=licens.ExpirationDate,
                CreatedByUserID=licens.CreatedByUserID,
                LicenseID=licens.LicenseID
                
            };
            ```
            Driver=clsDriver.GetDriver(_applicationID);

            clsDriver driver = new clsDriver
            {
                DriverID = Driver.DriverID,
                PersonID = Driver.PersonID,
                CreatedDate = Driver.CreatedDate,
                CreatedByUserID = Driver.CreatedByUserID

            };
            ```
            if (licens.Save())
            {
                MessageBox.Show("License Saved Successfully","Licens Saved");
            }
            else
            {
                MessageBox.Show("License Saved Faild", "Licens Saved");

            }

            if (driver.Save())
            {
                MessageBox.Show("Driver Saved Successfully", "Driver Saved");
            }
            else
            {
                MessageBox.Show("Driver Saved Faild", "Driver Saved");
            }

        }

        private void Issue_Driving_License_For_The_First_Time_Load(object sender, EventArgs e)
        {
            _applicationType = clsApplicationType.GetApplicationType(_applicationID);

            application_Info1._LoadApplication(_applicationType);



            if (_applications_View == null && _applicationID != -1)
            {
                _applications_View = clsLocalDrivingLicenseApplications_View.GetNotDefined(_applicationID);
            }

            if (_applications_View != null)
            {
                application_Info1._LoadApplicationView(_applications_View);
            }
            else
            {
                MessageBox.Show("Driver License Application Not Found");

            }

            if (_applicationID <= 0)
            {
                MessageBox.Show("Invalid Application ID");
                return;
            }
            else
            {
                _application = clsLocalDrivingLicenseFullApplications_View.GetLocalDrivingLicenseFullApplications_View(_applicationID);
                if (_application != null)
                {
                    application_Info1._LoadInfo(_application);

                }
                else
                {

                    MessageBox.Show($"No application found with ID: {_applicationID}");
                    return;
                }
            }

        }
    }
}
*/
        private void EditApplicationType_Load(object sender, EventArgs e)
        {

        }
    }
}
