﻿using System;
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
    public partial class CtrlPersonAndUserDeteils : UserControl
    {
        private clsUsers _User;
        private int _UserID = -1;
        private string _Password = "";
        public int UserID
        {
            get { return _UserID; }
        }


        public CtrlPersonAndUserDeteils()
        {
            InitializeComponent();
        }

        private void _ResetPersonInfo()
        {

            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }

        public void LoadUserDataToForm(int UserID)
        {
            _UserID = UserID;
            _User = clsUsers.FindByUserID(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();

        }

        private void _FillUserInfo()
        {
            int _PersonID = clsUsers.GetPersonIDByUserID(_UserID);
            ctrlPersonDetails1.LoadPersonInfo(_PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();

            lblIsActive.Text = (_User.IsActive == 1) ? "Yes" : "No";

        }

        private void CtrlPersonDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
