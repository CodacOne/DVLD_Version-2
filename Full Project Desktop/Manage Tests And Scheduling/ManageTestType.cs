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
    public partial class ManageTestType : Form
    {
        public ManageTestType()
        {
            InitializeComponent();
        }

        private void _RefreshTestTypeList()
        {
            dgvTestType.DataSource = clsTestTypes.GetAllTestTypes();

        }


        private void EditTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestTypeID= (int)dgvTestType.CurrentRow.Cells[0].Value;
            EditTestType frm = new EditTestType(TestTypeID);
            frm.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageTestType_Load(object sender, EventArgs e)
        {
            _RefreshTestTypeList();
            lblCountRecords.Text = clsTestTypes.GetTestTypesCount().ToString();
        }



    }
}
