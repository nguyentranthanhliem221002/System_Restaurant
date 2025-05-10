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

namespace PresentationLayer.Forms
{
    public partial class frm_users_manager : Form
    {
        private readonly UserService _userService;
        public frm_users_manager(UserService userService)
        {
            InitializeComponent();
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

        }

        private void frm_users_manager_Load(object sender, EventArgs e)
        {
            LoadUser();
        }
        public void LoadUser()
        {

            try
            {

                dgv_lisUser.DataSource = _userService.GetAllUsers();

                if (dgv_lisUser.Columns.Contains("UserName"))
                    dgv_lisUser.Columns["UserName"].HeaderText = "Tên tài khoản";

                //if (dgv_lisUser.Columns.Contains("Level"))
                //    dgv_lisUser.Columns["Level"].HeaderText = "Cấp độ";



                if (dgv_lisUser.Columns.Contains("Role"))
                {
                    dgv_lisUser.Columns["Role"].Visible = false;
                }

                if (dgv_lisUser.Columns.Contains("RoleId"))
                {
                    dgv_lisUser.Columns["RoleId"].Visible = false;
                }
                if (dgv_lisUser.Columns.Contains("Orders"))
                {
                    dgv_lisUser.Columns["Orders"].Visible = false;
                }
                if (dgv_lisUser.Columns.Contains("DateStart"))
                {
                    dgv_lisUser.Columns["DateStart"].Visible = false;

                }
                if (dgv_lisUser.Columns.Contains("NumberPhone"))
                {
                    dgv_lisUser.Columns["NumberPhone"].Visible = false;

                }
                if (dgv_lisUser.Columns.Contains("FullName"))
                {
                    dgv_lisUser.Columns["FullName"].Visible = false;

                }
                if (dgv_lisUser.Columns.Contains("Email"))
                {
                    dgv_lisUser.Columns["Email"].Visible = false;

                }
                //if (dgv_lisUser.Columns.Contains("UserName"))
                //{
                //    dgv_lisUser.Columns["UserName"].Visible = false;
                //}
                if (dgv_lisUser.Columns.Contains("PasswordHash"))
                {
                    dgv_lisUser.Columns["PasswordHash"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_changePassword_Click(object sender, EventArgs e)
        {
            string userName = txt_userUserName.Text;
            string passWordOld = txt_userPasswordHash.Text;  
            string passWordNew = txt_userPasswordNew.Text;  
            string passWordConfirm = txt_userPasswordConfirm.Text; 

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWordOld) ||
                string.IsNullOrEmpty(passWordNew) || string.IsNullOrEmpty(passWordConfirm))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (passWordNew != passWordConfirm)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = _userService.GetUserByUserName(userName); 

            if (user == null)
            {
                MessageBox.Show("Người dùng không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isOldPasswordValid = BCrypt.Net.BCrypt.Verify(passWordOld, user.PasswordHash);

            if (!isOldPasswordValid)
            {
                MessageBox.Show("Mật khẩu cũ không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(passWordNew);

            try
            {
                bool isPasswordChanged = _userService.ChangePassword(userName, newPasswordHash);

                if (isPasswordChanged)
                {
                    MessageBox.Show("Mật khẩu đã được thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi thay đổi mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool isPasswordVisible = false; 

        private void TogglePasswordVisibility(TextBox passwordTextBox, Button passwordButton, string showPasswordPath, string hidePasswordPath)
        {
            if (isPasswordVisible)
            {
                passwordTextBox.PasswordChar = '*';
                passwordButton.BackgroundImage = Image.FromFile(hidePasswordPath);  
            }
            else
            {
                passwordTextBox.PasswordChar = '\0';
                passwordButton.BackgroundImage = Image.FromFile(showPasswordPath);  
            }

            isPasswordVisible = !isPasswordVisible;
        }

        private void btn_showPassword_Click(object sender, EventArgs e)
        {
            string hidePasswordPath = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\hidePassword.png";
            string showPasswordPath = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\showPassword.png";

            // Gọi phương thức chung
            TogglePasswordVisibility(txt_userPasswordHash, btn_showPassword, showPasswordPath, hidePasswordPath);
        }

        private void btn_showPasswordNew_Click(object sender, EventArgs e)
        {
            string hidePasswordPath = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\hidePassword.png";
            string showPasswordPath = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\showPassword.png";

            TogglePasswordVisibility(txt_userPasswordNew, btn_showPasswordNew, showPasswordPath, hidePasswordPath);
        }

        private void btn_showPasswordConfirm_Click(object sender, EventArgs e)
        {
            string hidePasswordPath = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\hidePassword.png";
            string showPasswordPath = @"C:\Users\nguye\OneDrive\Máy tính\System_Restaurant\PresentationLayer\Resources\showPassword.png";

            TogglePasswordVisibility(txt_userPasswordConfirm, btn_showPasswordConfirm, showPasswordPath, hidePasswordPath);
        }

    }
}
