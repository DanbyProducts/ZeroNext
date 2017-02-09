using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Number_Generator
{
    public partial class AdminRoles : Form
    {
        public AdminRoles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginWindow loginwindow = new LoginWindow();
            loginwindow.Show();
            Hide();
        }
    }
}
