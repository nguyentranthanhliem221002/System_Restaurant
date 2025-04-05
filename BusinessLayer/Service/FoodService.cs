using DataLayer.IRepository;
using TransferObject;

namespace DataLayer.Service
{
    public class FoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        // Lấy tất cả món ăn
        public List<Food> GetAllFoods() => _foodRepository.GetAllFoods();

        // Thêm món ăn
        public void AddFood(Food food)
        {
            if (food == null) throw new ArgumentNullException(nameof(food));
            _foodRepository.AddFood(food);
        }

        // Xóa món ăn
        public void DeleteFood(int id) => _foodRepository.DeleteFood(id);
        
        // Lấy món ăn theo Id
        public Food GetFoodById(int id) => _foodRepository.GetFoodById(id);

        // Cập nhật món ăn
        public void UpdateFood(Food food)
        {
            if (food == null) throw new ArgumentNullException(nameof(food));
            _foodRepository.UpdateFood(food);
        }

        // Tìm món theo tên
        public List<Food> SearchFoodsByName(string name)
        {
            return _foodRepository.SearchFoodsByName(name);
        }
        public List<Food> GetFoodByCategoryId(int categoryId) => _foodRepository.GetFoodByCategoryId(categoryId);
    }
}
