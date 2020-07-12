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
        public FrmHome()
        {
            InitializeComponent();
        }
        public FrmHome(UserDTO user)
        {
            InitializeComponent();
            if (user != null)
            {
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

        private void btnShop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmShop());
        }
    }
}
