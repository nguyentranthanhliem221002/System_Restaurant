using BusinessLayer.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    public partial class frm_categories_manager : Form
    {
        private readonly CategoryService _categoryService;

        public frm_categories_manager(CategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        private void frm_categories_manager_Load(object sender, EventArgs e) => LoadCategories();

        private void LoadCategories()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();
                dgv_listCategory.DataSource = categories;
                if (dgv_listCategory.Columns.Contains("Foods"))
                {
                    dgv_listCategory.Columns["Foods"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải danh mục", ex);
            }
        }

        private void ShowError(string message, Exception ex) => MessageBox.Show($"{message}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ShowMessage(string message, MessageBoxIcon icon) => MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, icon);

        private void ClearCategoryForm() => txt_categoryName.Clear();

        private int GetSelectedCategoryId() => Convert.ToInt32(dgv_listCategory.SelectedRows[0].Cells["Id"].Value);

        private void btn_categoryAdd_Click(object sender, EventArgs e)
        {
            string categoryName = txt_categoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                ShowMessage("Vui lòng nhập tên danh mục!", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var category = new Category { Name = categoryName };
                _categoryService.AddCategory(category);
                ClearCategoryForm();
                LoadCategories();
                ShowMessage("Danh mục đã được thêm thành công!", MessageBoxIcon.Information);
            }
            catch (Exception ex) { ShowError("Lỗi khi thêm danh mục", ex); }
        }

        private void btn_categoryDelete_Click(object sender, EventArgs e)
        {
            if (dgv_listCategory.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn một danh mục!", MessageBoxIcon.Warning);
                return;
            }

            int categoryId = GetSelectedCategoryId();
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _categoryService.DeleteCategoryById(categoryId);
                    LoadCategories();
                    ShowMessage("Xóa danh mục thành công!", MessageBoxIcon.Information);
                }
                catch (Exception ex) { ShowError("Lỗi khi xóa danh mục", ex); }
            }
        }

        private void btn_categoryFix_Click(object sender, EventArgs e)
        {
            if (dgv_listCategory.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn một danh mục!", MessageBoxIcon.Warning);
                return;
            }

            int categoryId = GetSelectedCategoryId();
            var category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                ShowMessage("Không tìm thấy danh mục!", MessageBoxIcon.Error);
                return;
            }

            txt_categoryName.Text = category.Name;
        }

        private void btn_categoryUpdate_Click(object sender, EventArgs e)
        {
            if (dgv_listCategory.SelectedRows.Count == 0)
            {
                ShowMessage("Vui lòng chọn một danh mục!", MessageBoxIcon.Warning);
                return;
            }

            string categoryName = txt_categoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                ShowMessage("Vui lòng nhập tên danh mục!", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int categoryId = GetSelectedCategoryId();
                var category = new Category { Id = categoryId, Name = categoryName };
                _categoryService.UpdateCategory(category);
                ClearCategoryForm();
                LoadCategories();
                ShowMessage("Cập nhật danh mục thành công!", MessageBoxIcon.Information);
            }
            catch (Exception ex) { ShowError("Lỗi khi cập nhật danh mục", ex); }
        }

        private void btn_categorySearch_Click(object sender, EventArgs e)
        {
            string name = txt_categorySearch.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                ShowMessage("Vui lòng nhập tên món ăn để tìm kiếm!", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var searchResults = _categoryService.SearchCategoriesByName(name);

                if (!searchResults.Any())
                {
                    ShowMessage("Không tìm thấy món ăn nào phù hợp! Đang tải lại danh sách món ăn...", MessageBoxIcon.Information);
                    LoadCategories();
                }
                else
                {
                    dgv_listCategory.DataSource = searchResults;
                }
            }
            catch (Exception ex) { ShowError("Lỗi khi tìm kiếm món ăn", ex); }
        }


    }
}
