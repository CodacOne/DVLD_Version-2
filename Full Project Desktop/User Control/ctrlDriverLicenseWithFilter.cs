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
    public partial class ctrlDriverLicenseWithFilter : UserControl
    {
        private bool _isReady = false;
        private DataTable _Dt = new DataTable();
        private string _lastInputChecked = "";
        private bool _RenewStatus = false;

        private int _licenseID = -1;

        // ربط الاحداث لتفعيل وتعطيل الازرار عند الحفظ 
        public event EventHandler SaveEnabled;
        public event EventHandler SaveDisabled;
        public event EventHandler<bool> RenewDisabled;
        public event EventHandler<bool> ReplacementDisabled;

        public event EventHandler<bool> DetainSaveStateChanged;
        public event EventHandler<bool> ReleaseSaveStateChanged;



        // دوال استدعاء الأحداث:
        private void OnDetainSaveStateChanged(bool status) => DetainSaveStateChanged?.Invoke(this, status);
        private void OnReleaseSaveStateChanged(bool status) => ReleaseSaveStateChanged?.Invoke(this, status);

        private void OnSaveEnabled() => SaveEnabled?.Invoke(this, EventArgs.Empty);
        private void OnSaveDisabled() => SaveDisabled?.Invoke(this, EventArgs.Empty);

        public delegate void LicenseIDSelectedForReplacementEventHandler(object sender, int licenseID);

        // تعريف الحدث نفسه
        public event LicenseIDSelectedForReplacementEventHandler LicenseIDSelectedForReplacement;

        // دالة لاستدعاء الحدث عند اختيار رخصة
        protected virtual void OnLicenseIDSelectedForReplacement(int licenseID)
        {
            LicenseIDSelectedForReplacement?.Invoke(this, licenseID);
        }
        private void OnRenewDisabled(bool status) => RenewDisabled?.Invoke(this, status);
        private void OnReplacementDisabled(bool status) => ReplacementDisabled?.Invoke(this, status);



        public enum FormMode
        {
            Renew,
            International,
          ReplacementForLostOrDamagedLicense,
            Detain,  
            Release
        }

        public ctrlDriverLicenseWithFilter( )
        {
            InitializeComponent();
           // _RenewStatus = RenewStatus;
        }


        private FormMode _currentMode = FormMode.International; // الوضع الافتراضي

        public FormMode CurrentMode
        {
            get => _currentMode;
            set => _currentMode = value;
        }


       


        private void SomeMethod()
        {
            // بدلاً من استدعاء دالة في الفورم، نطلق الحدث
            OnSaveEnabled();       // لتفعيل زر الحفظ
            OnSaveDisabled();      // لتعطيله
            OnRenewDisabled(true); // لتعطيل التجديد
            OnReplacementDisabled(true);
        }

        
        /*/*//*/*******************************************/
        public void LoadDataToForm(int LicenseID)
        {
            _Dt= clsDrivers.GetDataForInternationalLicenseApplication(LicenseID);
           
            if (_Dt.Rows.Count > 0)
            {
                DataRow row = _Dt.Rows[0];

                // نصوص السائق
                lblClass.Text = row["ClassName"].ToString();
                lblName.Text = $"{row["FirstName"]} {row["SecondName"]} {row["ThirdName"]} {row["LastName"]}";
                lblLicenseID.Text = row["LicID"].ToString();

                lblNationalNo.Text = row["NationalNo"].ToString();
                lblGender.Text = (Convert.ToBoolean(row["Gendor"])) ? "Female" : "Male";


                lblDateBirth.Text = Convert.ToDateTime(row["DateOfBirth"]).ToString("dd/MM/yyyy");
                lblDriverID.Text = row["DriverID"].ToString();


                // التواريخ
                lblIssueDate.Text = Convert.ToDateTime(row["IssueDate"]).ToString("dd/MM/yyyy");
                lblExpirationDate.Text = Convert.ToDateTime(row["ExpirationDate"]).ToString("dd/MM/yyyy");

                // الحالة
                lblIsActive.Text = (Convert.ToBoolean(row["IsActive"])) ? "Yes" : "No";

                if (clsIssuedLicense.IsLicenseDetainedOrNotDetained(LicenseID))
                {
                    lblIsDetained.Text = "Yes";
                }

                else
                {
                    lblIsDetained.Text = "No";
                }

           
                // التفاصيل
                int IssueReason = Convert.ToInt32(row["IssueReason"]);

                switch (IssueReason)
                {
                    case 1: lblIssueReason.Text = "FirstTime"; break;
                    case 2: lblIssueReason.Text = "New"; break;
                    case 3: lblIssueReason.Text = "Replacement for Damaged"; break;
                    case 4: lblIssueReason.Text = "Replacement for Lost"; break;

                }



                lblNotes.Text = row["Notes"].ToString();

                // تحميل الصورة
                if (System.IO.File.Exists(row["ImagePath"].ToString()))
                {
                    pictureBox1.Image = Image.FromFile(row["ImagePath"].ToString());
                }
                else
                {
                    pictureBox1.Image = null;
                }

               
            }



            else
            {
                MessageBox.Show("No data found for the given License ID.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }

            /**//*/*//*/*//*/**//*/*//***//*****//*****//***//*/////*/
           
            

        }

        /*/*//*/*******************************************/



        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            
          //  if (!_isReady) return;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string input = txtSearch.Text.Trim();

                // التحقق من أن الحقل ليس فارغًا
                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Please enter a value.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearch.Focus();
                    return;
                }

                // محاولة تحويل القيمة إلى عدد صحيح
                if (!int.TryParse(input, out int LicenseID))
                {
                    MessageBox.Show("Please enter a valid integer value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearch.Focus();
                    return;
                }

                try
                {
                    switch (_currentMode)
                    {
                        case FormMode.Renew:
                            ValidateOfFormRenewLicense(LicenseID);
                            break;
                        case FormMode.ReplacementForLostOrDamagedLicense:
                            ValidateOfFormReplacementForLostOrDamagedLicense(LicenseID);
                            break;
                        case FormMode.International:
                            ValidateOfFormInternationalLicense(LicenseID);
                            break;
                        case FormMode.Detain:
                            ValidateOfFormDetainLicense(LicenseID);
                            break;
                        case FormMode.Release:
                            ValidateOfFormReleaseLicense(LicenseID);
                            break;
                    }



                }

                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading data:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
   }


        /*/*//*/*******************************************/
        private void ValidateOfFormDetainLicense(int licenseID)
        {
            // مثال: التأكد من أن الرخصة نشطة وغير محجوزة

            bool isLicenseDetained = clsIssuedLicense.IsLicenseDetainedOrNotDetained(licenseID);
            bool isLicenseActive = clsIssuedLicense.IsLicenseDisactivatedOrNotDisactivated(licenseID);

            // مثال: التأكد من أن الرخصة محجوزة  isLicenseDetained = true  معناه ان الرخصة محجوزة

            if (isLicenseDetained || !isLicenseActive)
            {   // اذا كانت 
                MessageBox.Show("Selected license  already detained.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnDetainSaveStateChanged(false);
               

            }

            else
            {
                OnDetainSaveStateChanged(true);
            }
         
            LoadDataToForm(licenseID);
            SendLicenseIDToDetainForm(licenseID, _Dt);
            txtSearch.Clear();
            txtSearch.Focus();
        }

        /*/*//*/*******************************************/

        /*/*//*/*******************************************/


        private void ValidateOfFormReleaseLicense(int licenseID)
        {
            bool isLicenseDetained = clsIssuedLicense.IsLicenseDetainedOrNotDetained(licenseID);
            // مثال: التأكد من أن الرخصة محجوزة  isLicenseDetained = true  معناه ان الرخصة محجوزة
            if (!isLicenseDetained)
            {
                MessageBox.Show("The license is not currently detained.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OnReleaseSaveStateChanged(false);


            }
            else
            {
                OnReleaseSaveStateChanged(true);
            }


            LoadDataToForm(licenseID);
            SendLicenseIDToReleaseForm(licenseID, _Dt);

            txtSearch.Clear();
            txtSearch.Focus();
        }

        /*/*//*/*******************************************/
        /*/*//*/*******************************************/

        private void ValidateOfFormReplacementForLostOrDamagedLicense(int LicenseID)
        {
           
                // مثال: التحقق من ان الرخصة فعالة ام لا 
        if (clsIssuedLicense.ValidationIfLicenseActiveOrNotActive(LicenseID)!=1)
            {
                MessageBox.Show("The selected license is currently inactive. Kindly choose an appropriate and active license.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OnReplacementDisabled(true); // أو أي منطق تريده
                LoadDataToForm(LicenseID);
                txtSearch.Clear();
                txtSearch.Focus();
                return;
            }

            // مثال: تحميل البيانات
            LoadDataToForm(LicenseID);

            // إرسال البيانات للفورم الآخر
            SendLicenseIDToReplacementForm(LicenseID, _Dt);  // تنشئ هذه الدالة إذا لم تكن موجودة

            // تفعيل الحفظ أو أي عملية مطلوبة
            OnReplacementDisabled(false);

            txtSearch.Clear();
            txtSearch.Focus();


        }


            /*/*//*/*******************************************/

            /*/*//*/*******************************************/
            private void ValidateOfFormInternationalLicense(int LicenseID)
        {
            // التحقق من إذا كانت الرخصة من الفئة الثالثة
            if (!clsInternationalLicense.CheckIfLocalLicenseExistsAndAndLicenseClassWorth_3(LicenseID))
            {
                MessageBox.Show("License does exist but there is no ordinary license!", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OnSaveDisabled();
                txtSearch.Clear();
                txtSearch.Focus();
                return;
            }

            // التحقق من الرخصة الدولية إذا كانت مضافة قبل ذلك 
            if (clsInternationalLicense.LicenseExistOrNotInInternationalTable(LicenseID))
            {
                MessageBox.Show("This License ID already exists in the International License table.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDataToForm(LicenseID);
                SendLicenseIDToInternationalForm(LicenseID);
                OnSaveDisabled();
                txtSearch.Clear();
                txtSearch.Focus();
                return;
            }

            LoadDataToForm(LicenseID);
            SendLicenseIDToInternationalForm(LicenseID);
            OnSaveEnabled();
            txtSearch.Clear();
            txtSearch.Focus();

        }

        /*/*//*/*******************************************/

        /*/*//*/*******************************************/
        private void ValidateOfFormRenewLicense(int LicenseID)
        {

            // فقط تحقق من صلاحية الرخصة هنا
            if (clsInternationalLicense.IsLicenseValid(LicenseID))
            {
                // صلاحية الرخصة لم تنته بعد 
                MessageBox.Show("The license has not expired and cannot be renewed.", "Expired License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDataToForm(LicenseID);
                SendLicenseIDToRenewForm(LicenseID, _Dt);
                OnRenewDisabled(true);
            }
            else
            {
                // صلاحية الرخصة منتهية وسأحمل البيانات لتجديدها  
                LoadDataToForm(LicenseID);
                SendLicenseIDToRenewForm(LicenseID, _Dt);
                OnRenewDisabled(false);
            }

            txtSearch.Clear();
            txtSearch.Focus();

        }
        /*/*//*/*******************************************/
             /*/*//*/*******************************************/
        private void CtrlDriverLicenseWithFilter_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }


        /*/*//*/*******************************************/
        private void SendLicenseIDToReplacementForm(int licenseID, DataTable _Dt)
        {


            // الوصول إلى الفورم الرئيسي
            Form parentForm = this.FindForm();

            if (parentForm is ReplacementForLostOrDamagedLicense main)
            {
                main.LoadDataToReplacementForm(licenseID, _Dt);  // استدعاء التابع الموجود داخل الفورم الرئيسي
            }
            else
            {
                MessageBox.Show("Unable to find main form.");
            }
        }

        /*/*//*/*******************************************/

        private void SendLicenseIDToDetainForm(int licenseID, DataTable _Dt)
        {


            // الوصول إلى الفورم الرئيسي
            Form parentForm = this.FindForm();

            if (parentForm is DetainLicense main)
            {
                main.LoadDataToDetainForm(licenseID, _Dt);  // استدعاء التابع الموجود داخل الفورم الرئيسي
            }
            else
            {
                MessageBox.Show("Unable to find main form.");
            }
        }


        /*/*//*/*******************************************/
        private void SendLicenseIDToReleaseForm(int licenseID, DataTable _Dt)
        {


            // الوصول إلى الفورم الرئيسي
            Form parentForm = this.FindForm();

            if (parentForm is ReleaseDetainedLicense main)
            {
              main.LoadDataToReleaseForm(licenseID, _Dt);  // استدعاء التابع الموجود داخل الفورم الرئيسي
            }
            else
            {
                MessageBox.Show("Unable to find main form.");
            }
        }


        /*/*//*/*******************************************/
        private void SendLicenseIDToRenewForm(int licenseID,DataTable _Dt)
        {


            // الوصول إلى الفورم الرئيسي
            Form parentForm = this.FindForm();

            if (parentForm is RenewLicenseApplication main)
            {
                main.LoadDataToRenewForm(licenseID, _Dt);  // استدعاء التابع الموجود داخل الفورم الرئيسي
            }  
            else
            {
                MessageBox.Show("Unable to find main form.");
            }
        }

        /*/*//*/*******************************************/

        /*/*//*/*******************************************/

        private void SendLicenseIDToInternationalForm(int licenseID)
        {

           
            // الوصول إلى الفورم الرئيسي
            Form parentForm = this.FindForm();

            if (parentForm is InternationalLicense main)
            {
                main.LoadDataToInternationalLicenseForm(licenseID, _Dt);  // استدعاء التابع الموجود داخل الفورم الرئيسي
            }
            else
            {
                MessageBox.Show("Unable to find main form.");
            }
        }

        private void LblClass_Click(object sender, EventArgs e)
        {

        }

        private void LblIsDetained_Click(object sender, EventArgs e)
        {

        }



        /*/*//*/*******************************************/

        /*/*//*/*******************************************/

    }
}
