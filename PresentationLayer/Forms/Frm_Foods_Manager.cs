using BusinessLayer.Service;
using DataLayer.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    public partial class frm_foods_manager : Form
    {
        private readonly FoodService _foodService;
        private readonly CategoryService _categoryService;
        private readonly IServiceProvider _serviceProvider;

        public frm_foods_manager(frm_main frmMain, FoodService foodService, CategoryService categoryService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _foodService = foodService ?? throw new ArgumentNullException(nameof(foodService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        private void frm_foods_manager_Load(object sender, EventArgs e)
        {
            LoadFoods();
            LoadCategories();
        }

        private void LoadFoods()
        {
            try { dgv_listFood.DataSource = _foodService.GetAllFoods(); }
            catch (Exception ex) { ShowMessage("Lỗi khi tải danh sách món ăn", ex, MessageBoxIcon.Error); }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();
                if (categories == null || !categories.Any())
                {
                    ShowMessage("Không có danh mục nào!", null, MessageBoxIcon.Information);
                    return;
                }
                if (dgv_listFood.Columns.Contains("Category"))
                {
                    dgv_listFood.Columns["Category"].Visible = false;
                }

                if (dgv_listFood.Columns.Contains("CategoryId"))
                {
                    dgv_listFood.Columns["CategoryId"].Visible = false;
                }

                comboBox_listCategory.DataSource = categories;
                comboBox_listCategory.DisplayMember = "Name";
                comboBox_listCategory.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                ShowMessage("Lỗi khi tải danh mục", ex, MessageBoxIcon.Error);
            }
        }

        private void ShowMessage(string message, Exception ex, MessageBoxIcon icon)
        {
            MessageBox.Show($"{message}{(ex != null ? ": " + ex.Message : "")}", "Thông báo", MessageBoxButtons.OK, icon);
        }

        private void ClearForm()
        {
            txt_foodName.Clear();
            txt_foodPrice.Clear();
            txt_foodDescription.Clear();
            pictureBox_foodImage.Image = null;
            pictureBox_foodImage.Tag = null;
            txt_foodName.Focus();
        }

        private bool ValidateFoodInput(out string name, out decimal price, out string desc, out string img, out int categoryId)
        {
            name = txt_foodName.Text.Trim();
            desc = txt_foodDescription.Text.Trim();
            img = pictureBox_foodImage.Tag?.ToString();
            categoryId = Convert.ToInt32(comboBox_listCategory.SelectedValue);
            bool valid = true;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(desc))
            {
                ShowMessage("Vui lòng nhập đầy đủ thông tin!", null, MessageBoxIcon.Warning);
                valid = false;
            }

            if (!decimal.TryParse(txt_foodPrice.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out price) || price <= 0)
            {
                ShowMessage("Giá món ăn không hợp lệ!", null, MessageBoxIcon.Warning);
                valid = false;
            }

            if (string.IsNullOrEmpty(img) || !File.Exists(img))
            {
                ShowMessage("Vui lòng chọn ảnh hợp lệ!", null, MessageBoxIcon.Warning);
                valid = false;
            }

            return valid;
        }

        private void btn_loadImage_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Title = "Chọn ảnh món ăn",
                Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                LoadImage(openFileDialog.FileName);
        }

        private void LoadImage(string path)
        {
            try
            {
                pictureBox_foodImage.Image?.Dispose();
                pictureBox_foodImage.Image = Image.FromFile(path);
                pictureBox_foodImage.Tag = path;
            }
            catch (Exception ex)
            {
                ShowMessage("Không thể tải ảnh", ex, MessageBoxIcon.Error);
            }
        }

        private void btn_foodAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFoodInput(out var name, out var price, out var desc, out var img, out var categoryId)) return;

            _foodService.AddFood(new Food
            {
                Name = name,
                Price = Math.Round(price, 3),
                Description = desc,
                Image = img,
                CategoryId = categoryId
            });

            ClearForm();
            LoadFoods();
            ShowMessage("Món ăn đã được thêm thành công!", null, MessageBoxIcon.Information);
        }

        private void btn_foodDelete_Click(object sender, EventArgs e)
        {
            var row = dgv_listFood.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (row == null || !int.TryParse(row.Cells["Id"].Value?.ToString(), out int id))
            {
                ShowMessage("Vui lòng chọn món ăn để xóa!", null, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _foodService.DeleteFood(id);
                LoadFoods();
                ShowMessage("Xóa món ăn thành công!", null, MessageBoxIcon.Information);
            }
        }

        private void btn_foodFix_Click(object sender, EventArgs e)
        {
            var row = dgv_listFood.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (row == null || !int.TryParse(row.Cells["Id"].Value?.ToString(), out int id)) return;

            var food = _foodService.GetFoodById(id);
            if (food == null)
            {
                ShowMessage("Không tìm thấy món ăn!", null, MessageBoxIcon.Error);
                return;
            }

            txt_foodName.Text = food.Name;
            txt_foodPrice.Text = food.Price.ToString();
            txt_foodDescription.Text = food.Description;
            pictureBox_foodImage.ImageLocation = food.Image;
            pictureBox_foodImage.Tag = food.Image;
        }

        private void btn_foodUpdate_Click(object sender, EventArgs e)
        {
            var row = dgv_listFood.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (row == null || !int.TryParse(row.Cells["Id"].Value?.ToString(), out int id))
            {
                ShowMessage("Vui lòng chọn món ăn để cập nhật!", null, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateFoodInput(out var name, out var price, out var desc, out var img, out var categoryId)) return;

            _foodService.UpdateFood(new Food
            {
                Id = id,
                Name = name,
                Price = Math.Round(price, 3),
                Description = desc,
                Image = img,
                CategoryId = categoryId
            });

            ClearForm();
            LoadFoods();
            ShowMessage("Cập nhật món ăn thành công!", null, MessageBoxIcon.Information);
        }

        private void btn_foodSearch_Click(object sender, EventArgs e)
        {
            var name = txt_foodSearch.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                ShowMessage("Vui lòng nhập tên món ăn để tìm kiếm!", null, MessageBoxIcon.Warning);
                return;
            }

            var results = _foodService.SearchFoodsByName(name);
            if (!results.Any())
            {
                ShowMessage("Không tìm thấy món ăn nào phù hợp!", null, MessageBoxIcon.Information);
                LoadFoods();
                return;
            }

            dgv_listFood.DataSource = results;
        }

        private void btn_frm_categories_manager_Click(object sender, EventArgs e)
        {
            var frmMain = Application.OpenForms.OfType<frm_main>().FirstOrDefault();
            if (frmMain != null)
            {
                var categoryForm = _serviceProvider.GetRequiredService<frm_categories_manager>();
                frmMain.OpenChildForm(categoryForm);
            }
        }

    }
}
