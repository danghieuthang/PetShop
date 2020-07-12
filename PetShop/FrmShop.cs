using BUS;
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
    public partial class FrmShop : Form
    {
        private DataTable dtPet;
        private readonly PetBUS _petBUS;
        public FrmShop()
        {
            InitializeComponent();
            _petBUS = new PetBUS();
        }
        private void FrmShop_Load(object sender, EventArgs e)
        {
            dtPet = _petBUS.GetPets();
            bsPets.DataSource = dtPet;
            dgvPets.DataSource = bsPets;
            bnPetList.BindingSource=bsPets;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
