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
    public partial class T_StreetTestAppointment : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private DataTable _Dt = new DataTable();

        private int _ApplicationID = -1;


        public T_StreetTestAppointment(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            DataTable Dt = new DataTable();

            _Dt = clsLocalDrivingApplication.GetAllDataToSchedulingTest(_LocalDrivingLicenseApplicationID);


            ctrl_T_VisionTestAppointment1.LoadDataToForm(_Dt);

            DataRow row = _Dt.Rows[0];

            _ApplicationID = (int)row["ApplicationID"];
            _RefreshUsersList();

        }

        //*//*/*/*/*/*/*//**************//////////////////////////////////
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
        /*/*//*/*******************************/////////////////////////////

        public void _RefreshUsersList()
        {
          

         

            dgvTestStreetAppointement.DataSource = clsLocalDrivingApplication.GetDataVisionTest(_ApplicationID);
            // dgvVisionTestAppointement.Columns["FullName"].FillWeight = 200;
            int realRowCount = dgvTestStreetAppointement.Rows.Cast<DataGridViewRow>()
          .Count(row => !row.IsNewRow);

            lblCountRecords.Text = realRowCount.ToString();
        }


        private void PictureBox15_Click(object sender, EventArgs e)
        {
            ScheduleStreetTest frm = new ScheduleStreetTest(_Dt, false, (int)dgvTestStreetAppointement.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultStreetTest frm = new ResultStreetTest(_Dt, (int)dgvTestStreetAppointement.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void T_StreetTestAppointment_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        //*//*/*/*/*/*/*//**************//////////////////////////////////

        //*//*/*/*/*/*/*//**************//////////////////////////////////
        private void PictureBox10_Click(object sender, EventArgs e)
        {

            if (dgvTestStreetAppointement.Rows.Count == 0)
            {
                // إذا كانت فارغة، السماح بإجراء العمليات في الـ PictureBox7
                ScheduleVisionTest frm = new ScheduleVisionTest(_Dt, false, 0); // الرقم 0 يعني لا يوجد موعد حالياً
                frm.Show();
            }
            else
            {
                // إذا كانت تحتوي على بيانات، التحقق من وجود موعد نشط
                if (CheckOfAppointementIfActiveOrNot(dgvTestStreetAppointement))
                {
                    ScheduleVisionTest frm = new ScheduleVisionTest(_Dt, false, (int)dgvTestStreetAppointement.CurrentRow.Cells[0].Value);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Person already have an Active Appointment for this test,you cannot add new Appointment",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void DgvTestStreetAppointement_Click(object sender, EventArgs e)
        {
            int ResultTest = -1;

            ResultTest = clsLocalDrivingApplication.
                GetResultForTest((int)dgvTestStreetAppointement.CurrentRow.Cells[0].Value);

            if (ResultTest == 0 || ResultTest == 1)
            {
                editToolStripMenuItem1.Enabled = false;
            }
            else
                return;

        }

        private void Ctrl_T_VisionTestAppointment1_Load(object sender, EventArgs e)
        {

        }

        private void DgvTestStreetAppointement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            _RefreshUsersList();
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ScheduleStreetTest frm = new ScheduleStreetTest(_Dt, true, (int)dgvTestStreetAppointement.CurrentRow.Cells[0].Value);
            frm.Show();
            _RefreshUsersList();
        }

        private void DgvTestStreetAppointement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvTestStreetAppointement.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow selectedRow = dgvTestStreetAppointement.Rows[e.RowIndex];

                // الحصول على قيمة العمود IsLocked والتحقق منها
                var isLockedValue = selectedRow.Cells["IsLocked"].Value;

                if (isLockedValue != null && Convert.ToInt32(isLockedValue) == 1)
                {
                    editToolStripMenuItem1.Enabled = false;
                    takeTestToolStripMenuItem.Enabled = false;
                }
            }
        }

        //*//*/*/*/*/*/*//**************//////////////////////////////////

        //*//*/*/*/*/*/*//**************//////////////////////////////////
        //*//*/*/*/*/*/*//**************//////////////////////////////////

    }
}
