using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water_Billing_Management_systeam
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTb.Text == "")
            {
                MessageBox.Show("Enter The Admin Password!!");
            } else if (PasswordTb.Text == "Bimalesh@07") 
            {
                Agents obj = new Agents();
                obj.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Worng Admin Password");
            }
        }
    }
}
