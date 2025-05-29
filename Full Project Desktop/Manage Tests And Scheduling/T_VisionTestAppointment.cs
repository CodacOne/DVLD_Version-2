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
    public partial class Schedule_Vision_Test : Form
    {
        private int _LocalDrivingLicenseApplicationID=-1;
        private DataTable _Dt = new DataTable();

        private int _ApplicationID = -1;

        public Schedule_Vision_Test(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            DataTable Dt = new DataTable();

            _Dt = clsLocalDrivingApplication.GetAllDataToSchedulingTest(_LocalDrivingLicenseApplicationID);


            ctrl_T_VisionTestAppointment1.LoadDataToForm(_Dt);

            DataRow row = _Dt.Rows[0];

            _ApplicationID =(int) row["ApplicationID"];
            _RefreshUsersList();
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void Label24_Click(object sender, EventArgs e)
        {

        }


        //*//*/*/*/*/*/*//**************//////////////////////////////////

 
     private bool CheckOfAppointementIfActiveOrNot(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow && Convert.ToInt32(row.Cells["IsLocked"].Value) == 0)
                {
                    return false;   // اذا كان هناك موعد فعال 
                }
            }

            return true;    // اذا كان هناك موعد غير  فعال  
        }
       
        //*//*/*/*/*/*/*//**************//////////////////////////////////

        //*//*/*/*/*/*/*//**************//////////////////////////////////

        //*//*/*/*/*/*/*//**************//////////////////////////////////

        private void PictureBox7_Click(object sender, EventArgs e)
        {


            if (dgvVisionTestAppointement.Rows.Count == 0)
            {
                // إذا كانت فارغة، السماح بإجراء العمليات في الـ PictureBox7
                ScheduleVisionTest frm = new ScheduleVisionTest(_Dt, false, 0); // الرقم 0 يعني لا يوجد موعد حالياً
                frm.Show();
            }
            else
            {
                // إذا كانت تحتوي على بيانات، التحقق من وجود موعد نشط
                if (CheckOfAppointementIfActiveOrNot(dgvVisionTestAppointement))
                {
                    ScheduleVisionTest frm = new ScheduleVisionTest(_Dt, false, (int)dgvVisionTestAppointement.CurrentRow.Cells[0].Value);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Person already have an Active Appointment for this test,you cannot add new Appointment",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Schedule_Vision_Test_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();

           
        }

        /*/*//*/*******************************/////////////////////////////
       
       


        /*/*//*/*******************************/////////////////////////////

        /*/*//*/*******************************/////////////////////////////
       
        public void _RefreshUsersList()
        {
           

            dgvVisionTestAppointement.DataSource = clsLocalDrivingApplication.GetDataVisionTest(_ApplicationID);
            // dgvVisionTestAppointement.Columns["FullName"].FillWeight = 200;
            int realRowCount = dgvVisionTestAppointement.Rows.Cast<DataGridViewRow>()
                .Count(row => !row.IsNewRow);

            lblCountRecords.Text = realRowCount.ToString();
        }


        /*/*//*/*******************************/////////////////////////////
        private void Ctrl_T_VisionTestAppointment1_Load(object sender, EventArgs e)
        {

        }

        private void LblCountRecords_Click(object sender, EventArgs e)
        {

        }

        private void DgvVisionTestAppointement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ScheduleVisionTest frm = new ScheduleVisionTest(_Dt,true, (int)dgvVisionTestAppointement.CurrentRow.Cells[0].Value);
            frm.Show();
            _RefreshUsersList();
        }

        private void TakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResultVisionTest frm = new ResultVisionTest(_Dt, (int)dgvVisionTestAppointement.CurrentRow.Cells[0].Value);
            frm.Show();

        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            _RefreshUsersList();
        }

        private void DgvVisionTestAppointement_Click(object sender, EventArgs e)
        {
            int ResultTest = -1;
            
            ResultTest = clsLocalDrivingApplication.
                GetResultForTest((int)dgvVisionTestAppointement.CurrentRow.Cells[0].Value);

            if (ResultTest == 0 || ResultTest == 1)
            {
                editToolStripMenuItem1.Enabled = false;
            }
            else
                return;
        }

        private void CmsAppointementsTable_Opening(object sender, CancelEventArgs e)
        {

        }

        private void DgvVisionTestAppointement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvVisionTestAppointement.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow selectedRow = dgvVisionTestAppointement.Rows[e.RowIndex];

                // الحصول على قيمة العمود IsLocked والتحقق منها
                var isLockedValue = selectedRow.Cells["IsLocked"].Value;

                if (isLockedValue != null && Convert.ToInt32(isLockedValue) == 1)
                {
                    editToolStripMenuItem1.Enabled = false;
                    takeTestToolStripMenuItem1.Enabled = false;
                }
            }

        }
        /*/*///////////////////////////////////////////////////*//*/*/*/*/////
    }
}
