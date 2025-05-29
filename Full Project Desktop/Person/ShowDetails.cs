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
    public partial class ShowDetails : Form
    {
        private int _PersonID=-1;

        private clsPerson _Person;



        public ShowDetails(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            try
            {


                _Person = clsPerson.FindByPersonID(PersonID);



                if (_Person != null)
                {

                    usclPersonDetails1._LoadDataFromTable(_Person);

                }

            }


            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);

            }
        }



        private void UsclPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void ShowDetails_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
