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
using Full_Project_Desktop;



namespace Full_Project_Desktop
{ 
    public partial class AddNewPerson : Form
    {

        public static int ID1=-1;

        private clsPerson _Person;
        clsPerson.enMode Mode;

        public AddNewPerson(int PersonID)
        {
            InitializeComponent();

           // lblPersonID.Text = PersonID.ToString();
        
            try
            {

               
                _Person = clsPerson.FindByPersonID(PersonID);

                

                if (_Person != null)
                {
                    Mode = _Person.Mode;
                    ChangeMode();

                    urclAddNewPerson1._LoadDataFromTable(_Person);

                }

            }
           

            catch(Exception ex)
            {
                MessageBox.Show("Error :"+ ex.Message);
                
            }


        }

        /// ////////////////////////////////////////////////////////////////////////////////////////

        private void ChangeMode()
        {

                    lblPersonID.Text = _Person.PersonID.ToString();
                    lblTitleForm.Text = "Update Person";
                    Mode = clsPerson.enMode.Update;
     
        }




        public AddNewPerson()
        {
            InitializeComponent();

            lblTitleForm.Text = "Add New Person";
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AddNewPerson_Load(object sender, EventArgs e)
        {

        }

        private void UrclAddNewPerson1_Load(object sender, EventArgs e)
        {

        }

        private void LblPersonID_Click(object sender, EventArgs e)
        {
           


        }


        public static void RefreshData(int ID, ctrlAddNewPerson userControl)
        {
            ID1 = ID;
           // userControl.Refresh_AddNewPerson();  // استدعِ الدالة من اليوزر كنترول
        }


        public void Refresh_AddNewPerson()
        {
            lblPersonID.Text = ID1.ToString();
            lblTitleForm.Text = "Update Person";
        }




    }
}
