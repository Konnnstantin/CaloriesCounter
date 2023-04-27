using CaloriesCount.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCount.BL.Controller
{
    public class EatingController : BaseController
    {
        private readonly User user;
        private const string FILE_FOOD = "food.dat";
        private const string FILE_PRODUCT = "product.dat";
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(_ => _.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
            }
            else
            {
                Eating.Add(product, weight);
            }
            SaveFoods();
        }
        private Eating GetEating()
        {
            return Load<Eating>(FILE_PRODUCT) ?? new Eating(user);
        }
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FILE_FOOD) ?? new List<Food>();
        }
        private void SaveFoods()
        {
            Save(FILE_FOOD, Foods);
            Save(FILE_PRODUCT, Eating);
        }
    }
}
