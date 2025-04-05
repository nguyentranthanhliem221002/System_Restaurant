using BusinessLayer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer.Forms
{
    public partial class frm_target_manager : Form
    {
        public readonly OrderService _orderService;
        public frm_target_manager(OrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        private void frm_target_manager_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }
        public void LoadOrders()
        {
            try
            {
                List<Order> orders = new List<Order>();
                _orderService.GetAllOrders();
                dgv_target.DataSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
