using BusinessLayer;
using System;
using System.Windows.Forms;

namespace Full_Project_Desktop
{
    public partial class EditTestType : Form
    {
        private int _TestTypeID = -1;
        clsTests _TestsType;
        public EditTestType(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditTestType_Load(object sender, EventArgs e)
        {
            _TestsType = clsTests.Find(_TestTypeID);

            if (_TestsType != null)
            {


                lblID.Text = ((int)_TestTypeID).ToString();
                txtTitle.Text = _TestsType.Title;
                txtDescription.Text = _TestsType.Description;
                txtFees.Text = _TestsType.Fees.ToString();
            }

            else

            {
                MessageBox.Show("Could not find Test Type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }
        }


    }
}
