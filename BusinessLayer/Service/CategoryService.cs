using DataLayer.IRepository;
using TransferObject;

namespace BusinessLayer.Service
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;  
        }
        public List<Category> GetAllCategories() => _categoryRepository.GetAllCatetories();

        // Thêm một danh mục mới
        public void AddCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _categoryRepository.AddCategory(category); 
        }

        // Xóa một danh mục theo ID
        public void DeleteCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
                throw new Exception("Category not found");

            _categoryRepository.DeleteCategoryId(id); 
        }

        // Lấy danh mục theo ID
        public Category GetCategoryById(int id) => _categoryRepository.GetCategoryById(id);

        // Cập nhật thông tin danh mục
        public void UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var existingCategory = _categoryRepository.GetCategoryById(category.Id);
            if (existingCategory == null)
                throw new Exception("Category not found");

            _categoryRepository.UpdateCategory(category); 
        }

        // Tìm kiếm danh mục theo tên
        public List<Category> SearchCategoriesByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Search name cannot be null or empty");

            return _categoryRepository.SearchCategoriesByName(name); 
        }
    }
}

