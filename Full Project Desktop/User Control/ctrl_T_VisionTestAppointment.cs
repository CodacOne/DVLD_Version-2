using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace Full_Project_Desktop
{
    public partial class ctrl_T_VisionTestAppointment : UserControl

   
    {
        private int _PersonID;

        public ctrl_T_VisionTestAppointment()
        {
            InitializeComponent();
        }



        //***///////////////////////////////////////////////////////////

        public void LoadDataToForm(DataTable Dt)
        {

            if (Dt.Rows.Count == 0)
            {
                MessageBox.Show("No data available to display.");
                return;
            }

            DataRow row = Dt.Rows[0];

            lblDLAppID.Text = row["LocalDrivingLicenseApplicationID"].ToString();
            lblApplicaionID.Text = row["ApplicationID"].ToString();
            lblApplicationDate.Text = Convert.ToDateTime(row["ApplicationDate"]).ToString("yyyy-MM-dd");
            int ApplicationStatus =Convert.ToInt32( row["ApplicationStatus"]);
            lblFees.Text = row["PaidFees"].ToString();

            lblType.Text = row["ApplicationTypeTitle"].ToString();
          

            switch (ApplicationStatus)
            {
                case 1:
                    lblStatus.Text = "New";
                    break;

                case 2:
                    lblStatus.Text = "Cancelled";
                    break;

                case 3:
                    lblStatus.Text = "Completed";
                    break;


            }


            lblAppliedForLicense.Text= row["ClassName"].ToString();

            lblApplicant.Text = row["FirstName"].ToString() + " " + row["SecondName"].ToString() + " " +
                  row["ThirdName"].ToString() + " " + row["LastName"].ToString();
            
            lblStatusDate.Text = Convert.ToDateTime(row["LastStatusDate"]).ToString("yyyy-MM-dd");

           lblCreatedBy.Text = row["UserName"].ToString();

            lblPassedTests.Text = row["PassedTests"].ToString() + "/3";


        _PersonID = Convert.ToInt32(row["PersonID"].ToString());

        }





        //***///////////////////////////////////////////////////////////

        private void Ctrl_T_VisionTestAppointment_Load(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LblID_Click(object sender, EventArgs e)
        {

        }

        private void LblCreatedBy_Click(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowDetails frm = new ShowDetails(_PersonID);
            frm.Show();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
