using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using BusinessLayer;

using System.IO;

namespace Full_Project_Desktop
{

    
    public partial class ctrlAddNewPerson : UserControl
    {

        private clsPerson.enMode _Mode ;

        private clsPerson Person = new clsPerson();


        private int globalID = -1;


    



     public ctrlAddNewPerson()
        {
            InitializeComponent();

           
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////
        ///
        private void RbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbFemale.Checked)
            {

                pbforPerson.Image = Properties.Resources.Female2;
            }

           

        }

        //////////////////////////////////////////////////////////////////////////////////////////
        
        private void BtnClose_Click(object sender, EventArgs e)
        {
           
                // البحث عن الفورم الأب (Parent Form) الذي يحتوي على الـ UserControl
                Form parentForm = this.ParentForm;

                if (parentForm != null)
                {
                    parentForm.Close(); // إغلاق الفورم
                }
            


        }


        //////////////////////////////////////////////////////////////////////////////////////////
        private void RbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {

                pbforPerson.Image = Properties.Resources.male2;
            }

           

        }

        ///////////////////////////////////////////////////////////////////

        private void FillCountriesInComboBox()
        {
            DataTable dt = clsPerson.GetAllCountries();

            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["CountryName"]);

            }


        }

        ///////////////////////////////////////////////////////////////////
       


        private void AddNewUser()
        {
               

            try
            {
               

            //    Person.Mode = clsPerson.enMode.Update;


                Person.FirstName = txtFirstName.Text.Trim();
                Person.SecondName = txtSecondName.Text.Trim();
                Person.ThirdName = txtThirdName.Text.Trim();
                Person.LastName = txtbLastName.Text.Trim();

                ///////


                Person.NationalNo = txtNationalNo.Text.Trim();
                Person.DateOfBirth = dateTimePicker1.Value;
                Person.Phone = txtPhone.Text;
                Person.Email = txtEmail.Text;

             
                    if (rbMale.Checked)
                    {
                        Person.Gendor = 0;


                    }

                    if (rbFemale.Checked)
                    {
                        Person.Gendor = 1;

                    }

                

                if (pictureBox1.Image != null)
                {
                    string imagesFolder = Path.Combine(@"D:\Abu hadhoud\abu hadhoud\Course  19  Full Real Project", "ImagesForDVLD_Project");
                    string imagePath = SaveImageToFolder(pictureBox1.Image, imagesFolder);
                    Person.ImagePath = imagePath;
                }



                int selectedCountry = clsCountries.Find(comboBox1.Text).CountryID;

                if(selectedCountry==null)
                {
                    MessageBox.Show("The specified country does not exist. Please select a correct country.");
                    return;

                }

                Person.NationalityCountryID = selectedCountry;



                Person.Address = txtAddress.Text;

                if (Person.Save())
                {
                   
                    AddNewPerson.RefreshData(Person.PersonID,this);

                   
                    

                    MessageBox.Show("Data Saved Successfully.");
                    
                }
                else
                    MessageBox.Show("Failed to save data.");

            }
           

            catch(Exception ex )
            {
                MessageBox.Show("Failed to save data." + ex.Message);

            }



        }

        ///////////////////////////////////////////////////////////////////
        private string SaveImageToFolder(Image image ,string FolderPath)
        {

            try
            {

                if (!Directory.Exists(FolderPath))
                {

                    Directory.CreateDirectory(FolderPath);
                }

                string FullName =Guid.NewGuid().ToString()+ ".png";

                string FullPath = Path.Combine(FolderPath, FullName);

                image.Save(FullPath, System.Drawing.Imaging.ImageFormat.Png);


                return FullPath;


            }

            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return null;
            }


        }


        ///////////////////////////////////////////////////////////////////
        /// <summary>
        public void _LoadDataFromTable(clsPerson person)
        {


            //   GlobalPersonID = person.PersonID;

            _Mode = clsPerson.enMode.Update;


            globalID=person.PersonID;

            txtFirstName.Text = person.FirstName;
            txtSecondName.Text = person.SecondName;
            txtThirdName.Text = person.ThirdName;
            txtbLastName.Text = person.LastName;
            txtNationalNo.Text = person.NationalNo;
            txtEmail.Text = person.Email;
            txtPhone.Text = person.Phone;
            txtAddress.Text = person.Address;
            dateTimePicker1.Value = person.DateOfBirth;

            if (person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;


            string ImagePath = person.ImagePath;
         


            if (ImagePath != null && System.IO.File.Exists(ImagePath))
            {
                pictureBox1.Image = Image.FromFile(ImagePath);

            }

            else

            {
                if (person.Gendor == 0)
                {
                    pictureBox1.Image = Properties.Resources.male2;
                }

                else
                {
                    pictureBox1.Image = Properties.Resources.Female2;

                }

            }


            clsCountries country = clsCountries.Find(person.NationalityCountryID);
            if (country != null)
            {
                comboBox1.SelectedItem = country.CountryName;
            }
            else
            {
                comboBox1.SelectedIndex = -1;
            }



        }

        ///////////////////////////////////////////////////////////////////
        private void UrclAddNewPerson_Load(object sender, EventArgs e)
        {
            Remove_Visible();

            FillCountriesInComboBox();
            comboBox1.SelectedIndex = 168;

         
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbforPerson.Image = new Bitmap(openFileDialog1.FileName);
            }

            Remove_Visible();
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        private void TxtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {

                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "Should have a Value");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtFirstName, "");
            }

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////

        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;

            try
            {
                var mail = new MailAddress(txt.Text);
                
                errorProvider1.SetError(txt, "");
            }


            catch
            {
                
                errorProvider1.SetError(txt, "Invalid Email Address Format");
                e.Cancel = true; // 
                txt.Focus();
            }


        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TbAddress_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {

                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Should have a Value");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtAddress, "");
            }
        }


        /// <summary>
        /// ////////////////////////////////////////
        private bool FindNationalNumber()
        {
            if (clsPerson.IsNationalNumber(txtNationalNo.Text))
            {
                return true;

            }

            else

                return false;

        }

        ////////////////////////////////////////
        private void TxtNationalNo_TextChanged(object sender, EventArgs e)
        {

        }

        ////////////////////////////////////////
        private void Remove_Visible()
        {
            if (pictureBox1.Image != null)
            {
                llRemove.Visible = true;

            }

            else

                llRemove.Visible = false;
        }


        private void TxtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (FindNationalNumber())
            {

                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtNationalNo, "National No Is Found");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtNationalNo, "");
            }
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }


       
        ///////////////////////////////////////////////



        private void UpdateUser()
        { 
            

            try
            {
              

               Person.Mode = clsPerson.enMode.Update;

                Person.FirstName = txtFirstName.Text.Trim();
                Person.SecondName = txtSecondName.Text.Trim();
                Person.ThirdName = txtThirdName.Text.Trim();
                Person.LastName = txtbLastName.Text.Trim();

                ///////
                Person.PersonID = globalID;

                Person.NationalNo = txtNationalNo.Text.Trim();
                Person.DateOfBirth = dateTimePicker1.Value;
                Person.Phone = txtPhone.Text;
                Person.Email = txtEmail.Text;



                if (rbMale.Checked)
                {
                    Person.Gendor = 0;


                }

                if (rbFemale.Checked)
                {
                    Person.Gendor = 1;

                }



                if (pictureBox1.Image != null)
                {
                    string imagesFolder = Path.Combine(@"D:\Abu hadhoud\abu hadhoud\Course  19  Full Real Project", "ImagesForDVLD_Project");
                    string imagePath = SaveImageToFolder(pictureBox1.Image, imagesFolder);
                    Person.ImagePath = imagePath;
                }




                int selectedCountry = clsCountries.Find(comboBox1.Text).CountryID;

                if (selectedCountry == null)
                {
                    MessageBox.Show("The specified country does not exist. Please select a correct country.");
                    return;

                }

                Person.NationalityCountryID = selectedCountry;



                Person.Address = txtAddress.Text;

                if (Person.Save())
                {


                    MessageBox.Show("Data Saved Successfully.");

                }
                else
                    MessageBox.Show("Failed to save data.");

            }


            catch (Exception ex)
            {
                MessageBox.Show("Failed to save data." + ex.Message);

            }



        }

        ////////////////////////////////////////////



        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {
           


            switch (_Mode)
            {

                case clsPerson.enMode.AddNew:
                    AddNewUser();
                    break;

                case clsPerson.enMode.Update:
                   UpdateUser();
                    break;


                default:

                      MessageBox.Show("Unknown Mode");
                    break;


              }
           

          }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void TxtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
