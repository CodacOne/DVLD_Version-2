using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Project_Desktop
{
    public partial class ShowDetailsForPersonAndUser : Form
    {
        private int _UserID = -1;

        public ShowDetailsForPersonAndUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

        }

        private void ShowDetailsForPersonAndUser_Load(object sender, EventArgs e)
        {
            ctrlShowPersonAndUserInformation1._LoadUserDataToForm(_UserID);

           
        }

        private void CtrlPersonAndUserInformation1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
