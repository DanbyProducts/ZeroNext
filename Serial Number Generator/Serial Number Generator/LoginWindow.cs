/*
 TO-DO : - (Done) Authorization, only allowed person are used to use this applicaiton, create user profiles with admin access only. 
         - (Done)Ask for password when starting an application.
            - (Done)Connect to db and check the username and password.
         - (Done)Create Greg Hall as an admin, and he will create other users.
         - (Done)Create user profiles database 
         - UI to add/delete admin, factory codes & product codes,
         - What if admin deletes a user, then how we will get all serial number created by him, it won be in userprofiles db.
            - Dont delete a user from DB, set the IsActive status to false.
                - False : cant acces the application
                - True : can access the application


        - Log Files

IMPORTANT         - Implement EXCEPTIONS

 Current Features : - Creates a serial number after clicking a button, then it shows the print label button to print that serial number.
                    


 Process Flow : Select the printer first to use, to avoid selecting the printers again and again.
           
 Not Done - Didnt store password encrypted. Its in plain text.     



 Future Plans : Create a ASP.NET Web Application or add this project in sharepoint.
                - Use Active directory also.
  */

  /*
   FIX : Opening another window from runtime, can't run the application again.
            Make sure to close parent form in case of exceptions in AdminRole Form
   */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Serial_Number_Generator
{
    public partial class LoginWindow : Form
    {

        static MySqlConnection connection = null;

        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //validate user entered credentials
            if (ValidateUserCredentials())
            {
                //connect to db
                if (ConnectToDb())
                {
                    //check user credentials to see if its admin or not
                    if (CheckUserCredentials())
                    {
                        ShowAdminWindow();
                    }
                    else
                    {
                        DisplayErrorMessageBox("Login Credentials Not Correct. Try Again with correct credentials.");
                    }
                }              
            }           
        }

        private bool CheckUserCredentials()
        {
            try
            {
                MySqlDataReader myreader = null;
                MySqlCommand command = new MySqlCommand("SELECT * FROM zeronext.userprofiles where Username='" + UsernameTb.Text.ToString() + "' and UserPassword = '" + PasswordTb.Text.ToString() + "';", connection);
                myreader = command.ExecuteReader();      
                if (!myreader.HasRows)
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return true;
        }

        private bool ValidateUserCredentials()
        {
            //clear error message of login form errorlabels
            ClearErrorLabels();

            //check user credentialS
            if (UsernameTb.Text == "")
                UsernameErrorLabel.Text = "Cannot Be Blank!";               
            if (PasswordTb.Text == "")
                PasswordErrorLabel.Text = "Cannot be Blank!";               
            if (UsernameTb.Text == "" || PasswordTb.Text == "")
                return false;
            return true;        
        }

        private void ClearErrorLabels()
        {
            UsernameErrorLabel.Text = "";
            PasswordErrorLabel.Text = "";
        }

        private static bool ConnectToDb()
        {
            
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return true;
        }

        private void ShowAdminWindow()
        {
            AdminRoles adminroleswindow = new AdminRoles(this);
            adminroleswindow.Show();
            Hide();
        }


        private static void DisplayErrorMessageBox(string ErrorMessage)
        {
            MessageBox.Show(ErrorMessage.ToString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exit the application
            this.Close();
        }

     
    }
}
