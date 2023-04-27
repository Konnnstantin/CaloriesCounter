using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCount.BL.Model
{/// <summary>
/// Реализовать проверки
/// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public Dictionary<Food, double> Foods { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            var eating = Foods.Keys.FirstOrDefault(_ => _.Name.Equals(food.Name));
            if (eating == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[eating] += weight;
            }
        }
    }
}
