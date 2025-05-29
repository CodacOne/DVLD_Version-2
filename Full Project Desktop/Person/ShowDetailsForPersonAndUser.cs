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
        private int _PersonID = -1;

        public ShowDetailsForPersonAndUser(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            ctrlPersonAndUserInformation1._LoadUserDataToForm(_PersonID);

        }

        private void ShowDetailsForPersonAndUser_Load(object sender, EventArgs e)
        {

        }
    }
}
