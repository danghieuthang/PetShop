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
    public partial class FrmHistory : Form
    {
        private string userName;
        private readonly OrderBUS _orderBUS;
        public FrmHistory()
        {
            InitializeComponent();
        }

        public FrmHistory(String userName)
        {
            InitializeComponent();
            this.userName = userName;
            _orderBUS = new OrderBUS();
        }

        private void FrmHistory_Load(object sender, EventArgs e)
        {
            DataTable t = _orderBUS.GetOrderByUser(userName);

            bsOrders.DataSource = t;
            bnOrders.BindingSource = bsOrders;
            dgvHistory.DataSource = bsOrders;
        }
    }
}
