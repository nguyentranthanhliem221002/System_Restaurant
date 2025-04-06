using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.Forms;
using TransferObject;

namespace PresentationLayer
{
    public partial class frm_main : Form
    {
        private Form activeForm = null; // Biến lưu trữ form con đang mở
        private readonly IServiceProvider _serviceProvider;

        public frm_main(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.IsMdiContainer = true;
            CustomizeUI(); // Gọi phương thức này để tùy chỉnh giao diện sau khi form được khởi tạo
        }

        private void btn_exitFrm_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void CustomizeUI()
        {
            if (CurrentUser.RoleId == 1) // Admin
            {
                ShowAdminButtons();
            }
            else if (CurrentUser.RoleId == 2) // Employee
            {
                ShowEmployeeButtons();
            }
        }

        private void ShowAdminButtons()
        {
            // Hiển thị tất cả các button dành cho Admin
            btn_frm_tables_manager.Visible = true;
            btn_frm_foods_manager.Visible = true;
            btn_frm_employees_manager.Visible = true;
            btn_frm_roles_manager.Visible = true;
            btn_frm_orders_manager.Visible = true;
            btn_users_manager.Visible = true;
            lb_roleName.Text = RoleType.admin.ToString();
        }

        private void ShowEmployeeButtons()
        {
            // Ẩn các button không dành cho Employee
            btn_frm_tables_manager.Visible = true;
            btn_frm_foods_manager.Visible = false;
            btn_frm_employees_manager.Visible = false;
            btn_frm_roles_manager.Visible = false;
            btn_frm_orders_manager.Visible = false;
            btn_users_manager.Visible = true;
            lb_roleName.Text = RoleType.employee.ToString();

        }

        public void OpenChildForm(Form childForm)
        {
            if (childForm.IsMdiContainer)
            {
                MessageBox.Show("Không thể mở Form dạng MDI bên trong panel.");
                return;
            }

            // Nếu đã có form con đang mở, đóng nó trước
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel_container.Controls.Add(childForm);
            this.panel_container.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_frm_tables_manager_Click(object sender, EventArgs e)
        {
            OpenChildForm(_serviceProvider.GetRequiredService<frm_tables_manager>());
        }

        private void btn_frm_foods_manager_Click(object sender, EventArgs e)
        {
            OpenChildForm(_serviceProvider.GetRequiredService<frm_foods_manager>());
        }

        private void btn_frm_employees_manager_Click(object sender, EventArgs e)
        {
            OpenChildForm(_serviceProvider.GetRequiredService<frm_employees_manager>());
        }

        private void btn_frm_roles_manager_Click(object sender, EventArgs e)
        {
            OpenChildForm(_serviceProvider.GetRequiredService<frm_roles_manager>());
        }

        private void btn_frm_order_manager_Click(object sender, EventArgs e)
        {
            OpenChildForm(_serviceProvider.GetRequiredService<frm_orders_manager>());
        }

        private void btn_users_manager_Click(object sender, EventArgs e)
        {
            OpenChildForm(_serviceProvider.GetRequiredService<frm_users_manager>());

        }

        private void frm_main_Load(object sender, EventArgs e)
        {

        }
    }
}
