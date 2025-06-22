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

        
        private DataTable _DtDrivingLicenseApplicationInfo = new DataTable();

        public ManageLocalDivingLicenseApplication()
        {
            InitializeComponent();


        }

        string InputTextBox = "";
        int InputNumber = 0;


        private void PictureBox2_Click(object sender, EventArgs e)
        {
            AddUpdateNewLocalDrivingAppl frm = new AddUpdateNewLocalDrivingAppl();
            frm.Show();
        }

        private void SchedulingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void _ScheduleTest(clsTestTypes.enTestType TestType)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            frmListTestAppointement frm = new frmListTestAppointement(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();


            //refresh
            LocalDivingLicenseApplication_Load(null, null);

        }


        private void SchduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.VisionTest);
        }

        private void ScheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.WrittenTest);
        }

        private void IssueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueDriverLicenseForFirstTime frm = new IssueDriverLicenseForFirstTime((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.Show();

            // To refresh
            LocalDivingLicenseApplication_Load(null, null);

        }

        private void ShowLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID(
               LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                ShowDetailsLicense frm = new ShowDetailsLicense(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //int LicenseID = clsLocalDrivingApplication.
            //     GetLicenseIDByLocalDrivingID((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            // ShowDetailsLicense frm = new ShowDetailsLicense(LicenseID);
            // frm.Show();
        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            clsLocalDrivingApplication localDrivingLicenseApplication = clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            ShowLicenseHistory frm = new ShowLicenseHistory(localDrivingLicenseApplication.ApplicantPersonID);
            frm.ShowDialog();

            //int PersonID = clsInternationalLicense.GetPersonIDByLocalDrivingID((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            //ShowLicenseHistory frm = new ShowLicenseHistory(PersonID);
            //frm.Show();
                
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

       
        ///*/*/*/**//////////////////////////*/*//////////////////*
        private void _RefreshContactList()
        {
            _DtDrivingLicenseApplicationInfo = clsLocalDrivingApplication.LicenseApplicationsFilter(InputNumber, InputTextBox);
            dgvLocalDrivingLicenseApplication.DataSource = _DtDrivingLicenseApplicationInfo;

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
			if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

			clsLocalDrivingApplication LocalDrivingLicenseApplication =
				clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

			if (LocalDrivingLicenseApplication != null)
			{
				if (LocalDrivingLicenseApplication.Cancel())
				{
					MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//refresh the form again.
					LocalDivingLicenseApplication_Load(null, null);
				}
				else
				{
					MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		
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
			int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

			clsLocalDrivingApplication LocalDrivingLicenseApplication =
				clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);


			if (MessageBox.Show("Are you want to delete Local Driving [" + dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value + "]",
                 "Delete Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Local Driving Deleted Successfully.");

                    LocalDivingLicenseApplication_Load(null, null);

                }

                else

                    MessageBox.Show("Local Driving is not deleted Because it has data Linked to it.");
            }

            
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            AddUpdateNewLocalDrivingAppl frm = new AddUpdateNewLocalDrivingAppl(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            // TO refresh Aftr Update
            LocalDivingLicenseApplication_Load(null, null);
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            ShowDrivingLicenseApplicationInfo frm = new ShowDrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
             
        }

        private void ScheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.StreetTest);

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
            //switch(CountPassingOfResult)
            //{
            //    case 3:
            //        toolStripMenuItemForAllTests.Enabled = false;

                 

            //        break;

            //    case 2:
            //        toolStripMenuItemForAllTests.Enabled = true;

            //        schduleVisionTestChoice.Enabled = false;
            //        scheduleWrittenTestChoice.Enabled = false;

            //        scheduleStreetTestChoice.Enabled = true;
            //        break;

            //    case 1:
            //        toolStripMenuItemForAllTests.Enabled = true;

            //        schduleVisionTestChoice.Enabled = false;

            //        scheduleWrittenTestChoice.Enabled = true;

            //        scheduleStreetTestChoice.Enabled = false;
            //        break;


            //    default:

            //        toolStripMenuItemForAllTests.Enabled = true;

            //        schduleVisionTestChoice.Enabled = true;

            //        scheduleWrittenTestChoice.Enabled = false;

            //        scheduleStreetTestChoice.Enabled = false;

            //        break;


            //}

           
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
            
            //if (dgvLocalDrivingLicenseApplication.CurrentRow == null)
            //    return;

            //int LocalDrivingID = Convert.ToInt32(dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            //int applicationStatus = Convert.ToInt32(dgvLocalDrivingLicenseApplication.CurrentRow.Cells[5].Value);

            //// شرط السماح بإصدار الرخصة:
            //// يجب أن تكون الحالة = 3 والرخصة غير موجودة مسبقًا
            //bool licenseExists = clsDriver.ValidationIFLicenseExistOrNot(LocalDrivingID);

            //if (applicationStatus == 3 && !licenseExists)
            //{
            //    issueDrivingLicenseForFirstTimeToolStripMenuItem.Enabled = true;
               

            //}
            //else
            //{
            //    issueDrivingLicenseForFirstTimeToolStripMenuItem.Enabled = false;

               
            //}

           // UpdateContextMenuOptions(applicationStatus, licenseExists);

        }

        private void cmsLocalDriving_Opening(object sender, CancelEventArgs e)
        {
            //
         int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;
         clsLocalDrivingApplication LocalDrivingLicenseApplication =
                 clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID
                                                 (LocalDrivingLicenseApplicationID);
       
         int TotalPassedTests = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[5].Value;
       
         bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            issueDrivingLicenseForFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            toolStripMenuItemForAllTests.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            cancelApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);


            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteToolStripMenuItem.Enabled =
                (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest); ;
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.StreetTest);

            toolStripMenuItemForAllTests.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            
            if (toolStripMenuItemForAllTests.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                schduleVisionTestChoice.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                scheduleWrittenTestChoice.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                scheduleStreetTestChoice.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }


        }

        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////
        //**/*/**/*//*////*/*////////////////////////*/////////////////////////////////////////////

    }
}
