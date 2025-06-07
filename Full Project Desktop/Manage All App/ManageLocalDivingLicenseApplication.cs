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
    public partial class ManageLocalDivingLicenseApplication : Form
    {

       // private DataTable _DtInfoDetainTable = new DataTable();

        public ManageLocalDivingLicenseApplication()
        {
            InitializeComponent();


        }

        string InputTextBox = "";
        int InputNumber = 0;


        private void PictureBox2_Click(object sender, EventArgs e)
        {
            LocalLicense frm = new LocalLicense();
            frm.Show();
        }

        private void SchedulingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SchduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Schedule_Vision_Test frm = new Schedule_Vision_Test((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);

            frm.Show();
        }

        private void ScheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T_WrittenTestAppointment frm = new T_WrittenTestAppointment((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void IssueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueDriverLicenseForFirstTime frm = new IssueDriverLicenseForFirstTime((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void ShowLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           int LicenseID = clsLocalDrivingApplication.
                GetLicenseIDByLocalDrivingID((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            ShowDetailsLicense frm = new ShowDetailsLicense(LicenseID);
            frm.Show();
        }
        
        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsInternationalLicense.GetPersonIDByLocalDrivingID((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            ShowLicenseHistory frm = new ShowLicenseHistory(PersonID);
            frm.Show();
                
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

       
        ///*/*/*/**//////////////////////////*/*//////////////////*
        private void _RefreshContactList()
        {
            dgvLocalDrivingLicenseApplication.DataSource = clsLocalDrivingApplication.LicenseApplicationsFilter(InputNumber, InputTextBox);
           
            dgvLocalDrivingLicenseApplication.Columns["FullName"].FillWeight = 150;
            dgvLocalDrivingLicenseApplication.Columns["L.D.L AppID"].FillWeight =30;
            dgvLocalDrivingLicenseApplication.Columns["NationalNo"].FillWeight =50;
           dgvLocalDrivingLicenseApplication.Columns["Passed Tests"].FillWeight = 50;
            dgvLocalDrivingLicenseApplication.Columns["Driving Class"].FillWeight = 140;
            dgvLocalDrivingLicenseApplication.Columns["Status"].FillWeight = 40;

            int realRowCount = dgvLocalDrivingLicenseApplication.Rows.Cast<DataGridViewRow>()
              .Count(row => !row.IsNewRow);

            lblCountRecords.Text = realRowCount.ToString();
        }
        ///*/*/*/**//////////////////////////*/*//////////////////*

        private void LocalDivingLicenseApplication_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _RefreshContactList();
            
            scheduleWrittenTestChoice.Enabled = false;
            scheduleStreetTestChoice.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
           


            InputTextBox = txtFilter.Text;
            InputNumber = cbFilter.SelectedIndex;

         

            dgvLocalDrivingLicenseApplication.DataSource = clsLocalDrivingApplication.LicenseApplicationsFilter(InputNumber, InputTextBox);
        }

        private void CancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelApplication((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
        }


        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////
        private void CancelApplication(int LocalDrivingLicenseApplicationID)
        {



            if (MessageBox.Show("Are you Sure to want to Cancelled this Application ?",
                "Confirm", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLocalDrivingApplication.CancelApplication(LocalDrivingLicenseApplicationID))
                {
                    MessageBox.Show("Application Cancelled Successfully.","Canceled",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _RefreshContactList();

                }

                else

                    MessageBox.Show("Application Cancelled Failed.");
            }



        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            _RefreshContactList();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to delete Local Driving [" + dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value + "]",
                 "Delete Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsPerson.DeleteOnePersonFromTable((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Local Driving Deleted Successfully.");
                    _RefreshContactList();

                }

                else

                    MessageBox.Show("Local Driving is not deleted Because it has data Linked to it.");
            }


        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ScheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T_StreetTestAppointment frm = new T_StreetTestAppointment((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.Show();

        }

        private void DgvLocalDrivingLicenseApplication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void LblCountRecords_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            
             


        }


        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////

        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////
        private void EnabledChoiceForTestOrDisabled(int CountPassingOfResult)
        {
            switch(CountPassingOfResult)
            {
                case 3:
                    toolStripMenuItemForAllTests.Enabled = false;

                 

                    break;

                case 2:
                    toolStripMenuItemForAllTests.Enabled = true;

                    schduleVisionTestToolStripMenuItemVisionTest.Enabled = false;
                    scheduleWrittenTestChoice.Enabled = false;

                    scheduleStreetTestChoice.Enabled = true;
                    break;

                case 1:
                    toolStripMenuItemForAllTests.Enabled = true;

                    schduleVisionTestToolStripMenuItemVisionTest.Enabled = false;

                    scheduleWrittenTestChoice.Enabled = true;

                    scheduleStreetTestChoice.Enabled = false;
                    break;


                default:

                    toolStripMenuItemForAllTests.Enabled = true;

                    schduleVisionTestToolStripMenuItemVisionTest.Enabled = true;

                    scheduleWrittenTestChoice.Enabled = false;

                    scheduleStreetTestChoice.Enabled = false;

                    break;


            }

           
        }

        private void DgvLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            EnabledChoiceForTestOrDisabled((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[5].Value);
        }

        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////

        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////
        private void UpdateContextMenuOptions(int applicationStatus, bool licenseExists)
        {
           if(applicationStatus ==3 && licenseExists==true)
            {
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;

                showLicenseToolStripMenuItem.Enabled = true;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = true;

            }


            else if (applicationStatus == 3 && licenseExists == false)
            {
                editToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;

                showLicenseToolStripMenuItem.Enabled = false;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = false;

            }


            else

            {
                editToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;

                showLicenseToolStripMenuItem.Enabled = false;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = false;

            }
                




        }


        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////

        private void DgvLocalDrivingLicenseApplication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvLocalDrivingLicenseApplication.CurrentRow == null)
                return;

            int LocalDrivingID = Convert.ToInt32(dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            int applicationStatus = Convert.ToInt32(dgvLocalDrivingLicenseApplication.CurrentRow.Cells[5].Value);

            // شرط السماح بإصدار الرخصة:
            // يجب أن تكون الحالة = 3 والرخصة غير موجودة مسبقًا
            bool licenseExists = clsDrivers.ValidationIFLicenseExistOrNot(LocalDrivingID);

            if (applicationStatus == 3 && !licenseExists)
            {
                issueDrivingLicenseToolStripMenuItem.Enabled = true;
               

            }
            else
            {
                issueDrivingLicenseToolStripMenuItem.Enabled = false;

               
            }

            UpdateContextMenuOptions(applicationStatus, licenseExists);

        }

        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////
        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////

    }
}
