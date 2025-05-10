using DataLayer.IRepository;
using Microsoft.Extensions.DependencyInjection;
using TransferObject;

namespace PresentationLayer
{
    public partial class frm_login : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserRepository _userRepository; // Chuyển sang inject IUserRepository

        public frm_login(IServiceProvider serviceProvider, IUserRepository userRepository)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _userRepository = userRepository; // Khởi tạo IUserRepository
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txt_userName.Text;
                string password = txt_password.Text;

                // Kiểm tra thông tin đăng nhập thông qua UserRepository
                var user = _userRepository.Authenticate(userName, password);

                if (user != null)
                {
                    // Lưu thông tin người dùng vào CurrentUser
                    CurrentUser.UserId = user.Id;
                    CurrentUser.RoleId = user.RoleId; // Lưu RoleId

                    // Đóng form đăng nhập
                    this.Hide();

                    // Mở form chính
                    var frmMain = _serviceProvider.GetRequiredService<frm_main>();
                    frmMain.ShowDialog();
                }
                else
                {
                    // Thông báo lỗi nếu đăng nhập không thành công
                    MessageBox.Show("Thông tin đăng nhập không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và thông báo người dùng
                MessageBox.Show("Lỗi xảy ra khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exitFrm_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private bool isPasswordVisible = false;  // Biến theo dõi trạng thái mật khẩu

        private void btn_showPassword_Click(object sender, EventArgs e)
        {
            string hidePasswordPath = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\hidePassword.png";
            string showPasswordPath = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\showPassword.png";

            if (isPasswordVisible)
            {
                txt_password.PasswordChar = '*';
                btn_showPassword.BackgroundImage = Image.FromFile(hidePasswordPath);  
            }
            else
            {
                txt_password.PasswordChar = '\0';
                btn_showPassword.BackgroundImage = Image.FromFile(showPasswordPath); 
            }

            isPasswordVisible = !isPasswordVisible;
        }
    }
}
