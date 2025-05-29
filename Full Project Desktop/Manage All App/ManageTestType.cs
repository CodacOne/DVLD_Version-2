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
            dgvTestType.DataSource = clsManageTestTypes.GetAllTestTypes();

        }


        private void EditTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTestType frm = new UpdateTestType();
            frm.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageTestType_Load(object sender, EventArgs e)
        {
            _RefreshTestTypeList();
            lblCountRecords.Text = clsManageTestTypes.GetTestTypesCount().ToString();
        }



    }
}
