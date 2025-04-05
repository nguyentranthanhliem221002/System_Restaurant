using TransferObject;

namespace DataLayer.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCatetories();
        void AddCategory(Category category);
        void DeleteCategoryId(int id);
        Category GetCategoryById(int id);
        void UpdateCategory(Category category);
        List<Category> SearchCategoriesByName(string name);
    }
}
