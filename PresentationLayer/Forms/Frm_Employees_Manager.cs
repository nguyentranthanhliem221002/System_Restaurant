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
        private void ClearUsers()
        {
            txt_userEmail.Text = string.Empty;
            txt_userFullName.Text = string.Empty;
            txt_userNumberPhone.Text = string.Empty;
            txt_userSearch.Text = string.Empty;
            txt_userUserName.Text = string.Empty;
            txt_userPasswordHash.Text = string.Empty;
            dateTimePicker_userDateStart.Text = string.Empty;
        }
        private void LoadUsers()
        {
            try
            {
        
                dgv_lisUser.DataSource = _userService.GetAllUsers(); 
              
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
                if (dgv_lisUser.Columns.Contains("UserName"))
                {
                    dgv_lisUser.Columns["UserName"].Visible = false;
                }
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

        private void btn_userAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string userFullName = txt_userFullName.Text;
                string userNumberPhone = txt_userNumberPhone.Text;
                string userEmail = txt_userEmail.Text;
                DateTime userDateStart = dateTimePicker_userDateStart.Value;
                string userUserName = txt_userUserName.Text;
                string userPasswordHash = BCrypt.Net.BCrypt.HashPassword(txt_userPasswordHash.Text);
                int roleId = 0;

                if (radioButton_optionAdmin.Checked)
                {
                    // Kiểm tra số lượng Admin hiện tại
                    int adminCount = _userService.GetUsersByRoleId(1).Count();
                    if (adminCount >= 1)
                    {
                        MessageBox.Show("Chỉ có thể có một Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    roleId = 1; // Admin
                }
                else if (radioButton_optionEmployee.Checked)
                {
                    roleId = 2; // Employee
                }
                if (string.IsNullOrWhiteSpace(userFullName) ||
                      string.IsNullOrWhiteSpace(userEmail) ||
                      string.IsNullOrWhiteSpace(userNumberPhone) ||
                      string.IsNullOrWhiteSpace(userUserName) ||
                      string.IsNullOrWhiteSpace(txt_userPasswordHash.Text))
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    _userService.AddUser(new User
                    {
                        FullName = userFullName,
                        NumberPhone = userNumberPhone,
                        Email = userEmail,
                        DateStart = userDateStart,
                        UserName = userUserName,
                        PasswordHash = userPasswordHash,
                        RoleId = roleId
                    });

                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearUsers();
                    LoadUsers();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_userDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_lisUser.SelectedRows.Count > 0)
                {
                    int selectedUserId = (int)dgv_lisUser.SelectedRows[0].Cells["Id"].Value;
                    int selectedUserRole = (int)dgv_lisUser.SelectedRows[0].Cells["RoleId"].Value;

                    if (selectedUserRole == 1)
                    {
                        MessageBox.Show("Không thể xóa người dùng có vai trò Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        _userService.DeleteUser(selectedUserId);
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearUsers();
                        LoadUsers();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_userFix_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_lisUser.SelectedRows.Count > 0)
                {
                    var row = dgv_lisUser.SelectedRows[0];
                    txt_userFullName.Text = row.Cells["FullName"].Value.ToString();
                    txt_userNumberPhone.Text = row.Cells["NumberPhone"].Value.ToString();
                    txt_userEmail.Text = row.Cells["Email"].Value.ToString();
                    dateTimePicker_userDateStart.Value = (DateTime)row.Cells["DateStart"].Value;
                    txt_userUserName.Text = row.Cells["UserName"].Value.ToString();

                   
                    radioButton_optionEmployee.Checked = true;

                    // Kiểm tra nếu cột "Role" có giá trị
                    if (row.Cells["Role"].Value != null)
                    {
                        // Nếu Role là số (1 = Admin, 2 = Employee), bạn có thể kiểm tra giá trị này
                        int role = (int)row.Cells["Role"].Value;
                        radioButton_optionAdmin.Checked = (role == 1);
                        radioButton_optionEmployee.Checked = (role == 2);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Lỗi khi nạp thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_userUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_lisUser.SelectedRows.Count > 0)
                {
                    int userId = (int)dgv_lisUser.SelectedRows[0].Cells["Id"].Value;
                    string userFullName = txt_userFullName.Text;
                    string userNumberPhone = txt_userNumberPhone.Text;
                    string userEmail = txt_userEmail.Text;
                    DateTime userDateStart = dateTimePicker_userDateStart.Value;
                    string userUserName = txt_userUserName.Text;
                    string userPassword = txt_userPasswordHash.Text; 

                    int newRoleId = radioButton_optionAdmin.Checked ? 1 : 2; // Chọn Admin hoặc Employee

                    // Kiểm tra nếu chọn Admin, đảm bảo chỉ có một Admin trong hệ thống
                    if (newRoleId == 1)
                    {
                        int adminCount = _userService.GetUsersByRoleId(1).Count();
                        if (adminCount >= 1)
                        {
                            MessageBox.Show("Chỉ có thể có một Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(userPassword))
                    {
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userPassword);
                        _userService.UpdateUser(new User
                        {
                            Id = userId,
                            FullName = userFullName,
                            NumberPhone = userNumberPhone,
                            Email = userEmail,
                            DateStart = userDateStart,
                            UserName = userUserName,
                            PasswordHash = hashedPassword, 
                            RoleId = newRoleId 
                        });
                    }
                    else
                    {
                        // Nếu không thay đổi mật khẩu, chỉ cập nhật các trường khác
                        _userService.UpdateUser(new User
                        {
                            Id = userId,
                            FullName = userFullName,
                            NumberPhone = userNumberPhone,
                            Email = userEmail,
                            DateStart = userDateStart,
                            UserName = userUserName,
                            RoleId = newRoleId 
                        });
                    }

                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearUsers();
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_userSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_userSearch.Text.Trim().ToLower();

                //if (string.IsNullOrEmpty(keyword))
                //{
                //    MessageBox.Show("Vui lòng nhập tên nhân viên để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                var allUsers = _userService.GetAllUsers();

                var result = allUsers.Where(u => u.FullName.ToLower().Contains(keyword)).ToList();

                dgv_lisUser.DataSource = result;
                ClearUsers();

                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
