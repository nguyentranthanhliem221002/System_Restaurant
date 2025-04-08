using DataLayer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frm_orders_manager : Form
    {
        private readonly OrderService _orderService;
        public frm_orders_manager(OrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        private void frm_orders_manager_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }
        public void LoadOrders()
        {
            try
            {
                dgv_order.DataSource = _orderService.GetAllOrders();

                if (dgv_order.Columns.Contains("User"))
                {
                    dgv_order.Columns["User"].Visible = false;
                }

                if (dgv_order.Columns.Contains("TableId"))
                {
                    dgv_order.Columns["TableId"].Visible = false;
                }
                if (dgv_order.Columns.Contains("Table"))
                {
                    dgv_order.Columns["Table"].Visible = false;
                }

                if (dgv_order.Columns.Contains("OrderDetails"))
                {
                    dgv_order.Columns["OrderDetails"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách món ăn: " + ex.Message);
            }
        }

        private void groupBox_listRole_Enter(object sender, EventArgs e)
        {

        }

        private void dgv_order_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
