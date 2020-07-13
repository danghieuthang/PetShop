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
    public partial class FrmShop : Form
    {
        private DataTable dtPet;
        private DataTable dtType;
        private readonly PetBUS _petBUS;
        private readonly TypeBUS _typeBUS;
        private string userName;
        private OrderBUS _orderBUS;
        public FrmShop()
        {
            InitializeComponent();
            _petBUS = new PetBUS();
            _typeBUS = new TypeBUS();
        }
        public FrmShop(string userName)
        {
            InitializeComponent();
            _petBUS = new PetBUS();
            _typeBUS = new TypeBUS();
            this.userName = userName;
            _orderBUS = new OrderBUS();
        }
        private void FrmShop_Load(object sender, EventArgs e)
        {
            dtPet = _petBUS.GetPets();
            bsPets.DataSource = dtPet;
            dgvPets.DataSource = bsPets;
            bnPetList.BindingSource = bsPets;

            // Set Data for cbType
            dtType = _typeBUS.GetType();
            
            dtType.Rows.Add(new Object[] {0, "All" });// Add default type select
            dtType.DefaultView.Sort = "ID ASC"; // Sort List Type by ID
            cbType.DataSource = dtType;
            cbType.DisplayMember = "Name"; // Only show the column 'Name'
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_MouseLeave(object sender, EventArgs e)
        {

        }

        private void txtSearch_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Search";
            }
        }
        private int GetQuantity()
        {
            if (txtAmount.Text.Length == 0)
            {
                MessageBox.Show("Quantity must be required!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            int quantity = int.Parse(txtAmount.Text);
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return quantity;
        }
        private OrderDTO CreateOrder()
        {
            int index = dgvPets.CurrentCell.RowIndex;
            int ammount = GetQuantity();
            OrderDTO order = new OrderDTO
            {
                Pet = new PetDTO { ID = int.Parse(dgvPets.Rows[index].Cells["ID"].Value.ToString()) },
                User = new UserDTO { UserName = userName },
                TotalPrice = ammount * decimal.Parse(dgvPets.Rows[index].Cells["Price"].Value.ToString()),
                Amount = ammount
            };
            return order;
        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (GetQuantity() < 0)
            {
                return;
            }
            if (MessageBox.Show("Do you want to buy?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (_orderBUS.InsertOrder(CreateOrder()))
            {
                MessageBox.Show("Buy was successfull ^^", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Buy was fail :(", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dtPet.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", txtSearch.Text);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbType.SelectedIndex;
            dtPet.DefaultView.RowFilter = string.Format("Type LIKE '%{0}%'", index == 0 ? "" : dtType.Rows[index-1]["Name"].ToString());
        }
    }
}
