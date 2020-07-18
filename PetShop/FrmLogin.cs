using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class FrmLogin : Form
    {
        private readonly UserBUS _userBUS;
        public FrmLogin()
        {
            InitializeComponent();
            _userBUS = new UserBUS();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            if (txtID.Text == "UserName")
            {
                txtID.Text = "";
            }
        }
        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                txtID.Text = "UserName";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.UseSystemPasswordChar = false;
            }
        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            UserDTO user = _userBUS.CheckLogin(txtID.Text, txtPassword.Text);
            if (user != null)
            {
                _ = new FrmHome(user, this)
                {
                    Visible = true
                };
                this.Hide();
            }
            else
                MessageBox.Show("User Name or password not right!");
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

        }
    }
}
