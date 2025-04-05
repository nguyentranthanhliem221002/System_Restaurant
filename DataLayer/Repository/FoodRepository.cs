using DataLayer.IRepository;
using TransferObject;

namespace DataLayer.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Food> GetAllFoods() => _context.Foods.ToList();
        public void AddFood(Food food)
        {
            if (food == null) throw new ArgumentNullException(nameof(food));
            _context.Foods.Add(food);
            _context.SaveChanges();
        }
        public void DeleteFood(int id)
        {
            var food = _context.Foods.FirstOrDefault(f => f.Id == id);
            if (food != null)
            {
                _context.Foods.Remove(food);
                _context.SaveChanges();
            }
        }
        public Food GetFoodById(int id) => _context.Foods.FirstOrDefault(f => f.Id == id);
        public void UpdateFood(Food food)
        {
            var existingFood = _context.Foods.FirstOrDefault(f => f.Id == food.Id);
            if (existingFood != null)
            {
                existingFood.Name = food.Name;
                existingFood.Price = food.Price;
                existingFood.Description = food.Description;
                existingFood.Image = food.Image;
                existingFood.CategoryId = food.CategoryId;

                _context.SaveChanges();
            }
        }
        public List<Food> SearchFoodsByName(string name)
        {
            return _context.Foods
                           .Where(f => f.Name.Contains(name))
                           .ToList();
        }
        public List<Food> GetFoodByCategoryId(int categoryId) => _context.Foods.Where(f => f.CategoryId == categoryId).ToList();
    }
}
