using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace Full_Project_Desktop
{
    public partial class CtrlPeronDetailsWithFilterNew : UserControl
    {

        private string _InputTextBox = "";
        private int    _InputNumber = 0;

        public int __PersonID = -1;

        public int _PersonID
        {
            get; set;
        }


        public CtrlPeronDetailsWithFilterNew()
        {
            InitializeComponent();
        }

        /*/*//*/*//*/*//// <summary>
        public void _LoadDataToForm(clsPerson Person)
        {

            if (Person != null)
            {

                _PersonID = Person.PersonID;
                cbFilter.SelectedIndex = 2;
                ctrlPersonDetails1.LoadPersonInfo(_PersonID);
                //////////////////////////////////////////////////////////////////////
            }

            else
            {
                MessageBox.Show("$No Person With PersonID Or National No =" + _InputTextBox, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        private void TxtBySearch_TextChanged(object sender, EventArgs e)
        {
            _InputTextBox = txtBySearch.Text;
            _InputNumber = cbFilter.SelectedIndex;
        }

        public void FilterFocus()
        {
            txtBySearch.Focus();
        }


        public int PersonID
        {
            get { return ctrlPersonDetails1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonDetails1.SelectedPersonInfo; }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            // Folter By personID or National Number
            switch (_InputNumber)
            {
                //  person=new clsPerson();

                case 2:    // Folter By National Number 
                    clsPerson person = clsPerson.FindByNationalNo(_InputTextBox);
                    _LoadDataToForm(person);
                    break;

                case 1:    // Folter By personID 
                    person = clsPerson.FindByPersonID(Convert.ToInt32(_InputTextBox));
                    _LoadDataToForm(person);
                    break;

                default:
                    MessageBox.Show("Error");
                    cbFilter.Focus();
                    break;
            }
        }

        private void TxtBySearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtBySearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBySearch.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBySearch, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtBySearch, null);
            }
        }

        private void CtrlPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        public void ChangeModeToUpdate()
        {
            gbFilter.Enabled = false;
        }
        private void CtrlPeronDetailsWithFilterNew_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 2;
        }
    }
}
