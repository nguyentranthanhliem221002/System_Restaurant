using DataLayer.IRepository;
using TransferObject;

namespace DataLayer.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) 
        {
            _context = context;
        }


        public List<Category> GetAllCatetories() => _context.Categories.ToList();
        // Thêm danh mục mới
        public void AddCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            _context.Categories.Add(category); 
            _context.SaveChanges(); 
        }
        public Category GetCategoryById(int id) => _context.Categories.FirstOrDefault(c => c.Id == id);

        // Xóa danh mục theo ID
        public void DeleteCategoryId(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id); 
            if (category != null)
            {
                _context.Categories.Remove(category); 
                _context.SaveChanges();
            }
        }
        // Cập nhật thông tin danh mục
        public void UpdateCategory(Category category)
        {
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id); 
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;

                _context.SaveChanges();
            }
        }

        // Tìm kiếm danh mục theo tên
        public List<Category> SearchCategoriesByName(string name)
        {
            return _context.Categories
                           .Where(c => c.Name.Contains(name)) 
                           .ToList(); 
        }
    }
}
