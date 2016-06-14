using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASQL_Final_Yoyo
{
    public partial class frmMainMenu : Form
    {
        public DAL dataAccess = new DAL();
        public frmUserPage userForm = new frmUserPage();
        public frmAdminPage adminForm = new frmAdminPage();


        public frmMainMenu()
        {
            InitializeComponent();            
        }

        //Attempting to log into the server.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectedToServer = dataAccess.VerifyConnection();
            int validUser = 0;

            //Check if we're able to connect to the server.
            if (connectedToServer != "Success")
            {
                lblUserFeedback.Text = connectedToServer;
            }
            else
            {
                //Attempt to connect with the following information
                //bool userFound = dataAccess.UserStatus("SELECT COUNT(*) FROM UsersTable WHERE Name = 'Admin' AND ThePassword = '1234' ");

                validUser = dataAccess.AttemptLogin(txtboxUser.Text, txtboxPassword.Text);

                   //User is not found within the database
                if (validUser == 0)
                {
                    lblUserFeedback.Text = "Incorrect user information";
                }
                    //User is found in the database.
                else if (validUser >= 10)
                {
                    lblUserFeedback.Text = "Bridget says you're an admin";
                    this.Hide();
                    adminForm.ShowDialog();
                    this.Close();
                }
                else if (validUser <= 5)
                {
                    lblUserFeedback.Text = "Tong says you're a user.";
                    this.Hide();
                    userForm.ShowDialog();
                    this.Close();
                }
            }


        }
    }
}
