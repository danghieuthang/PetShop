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
    public partial class FrmHome : Form
    {
        private Form currentChildForm;
        private Button currentBtn;
        private UserDTO user;
        public FrmHome()
        {
            InitializeComponent();
        }
        public FrmHome(UserDTO user)
        {
            InitializeComponent();
            if (user != null)
            {
                this.user = user;
                txtUserName.Text = "Welcome - " + user.FullName;
            }
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
        }

        private void FrmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            pnChild.Controls.Add(childForm);
            childForm.Dock = DockStyle.Fill;
            pnChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void ClickNewBtn(Button btn)
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(64, 64, 64);
            }
            currentBtn = btn;
            currentBtn.BackColor = Color.FromArgb(30, 122, 227);
        }
        private void btnShop_Click(object sender, EventArgs e)
        {
            ClickNewBtn(btnShop);
            OpenChildForm(new FrmShop(user.UserName));
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ClickNewBtn(btnUser);
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            ClickNewBtn(btnCart);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            ClickNewBtn(btnHistory);
            OpenChildForm(new FrmHistory());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ClickNewBtn(btnLogout);
        }
    }
}
