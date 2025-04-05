using TransferObject;

namespace DataLayer.IRepository
{
    public interface IFoodRepository
    {
        List<Food> GetAllFoods();
        void AddFood(Food food);
        void DeleteFood(int id);
        Food GetFoodById(int id);
        void UpdateFood(Food food);
        List<Food> SearchFoodsByName(string name);
        List<Food> GetFoodByCategoryId(int categoryId);
    }
}
