using BusinessLayer.Service;
using TransferObject;

namespace PresentationLayer.Forms
{
    public partial class frm_employees_manager : Form
    {
        private readonly UserService _userService;

        public frm_employees_manager(UserService userService)
        {
            InitializeComponent();
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

        }

        private void frm_employees_manager_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
                // Lấy danh sách nhân viên từ service
                List<User> employees = _userService.GetAllUsers();

                // Gán dữ liệu vào DataGridView
                dgv_listEmployee.DataSource = employees;
                if (dgv_listEmployee.Columns.Contains("PasswordHash"))
                {
                    dgv_listEmployee.Columns["PasswordHash"].Visible = false;
                }

                if (dgv_listEmployee.Columns.Contains("Role"))
                {
                    dgv_listEmployee.Columns["Role"].Visible = false;
                }

                if (dgv_listEmployee.Columns.Contains("RoleId"))
                {
                    dgv_listEmployee.Columns["RoleId"].Visible = false;
                }

                if (dgv_listEmployee.Columns.Contains("Orders"))
                {
                    dgv_listEmployee.Columns["Orders"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
