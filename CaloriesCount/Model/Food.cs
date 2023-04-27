using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCount.BL.Model
{
    /// <summary>
    /// Реализовать проверки
    /// </summary>
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Carbohydrates { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }

        public double Calories { get; set; }

        public Food(string name) : this(name, 0, 0, 0, 0)
        { }

        public Food(string name, double carbohydrates, double proteins, double fats, double calories)
        {
            Name = name;
            Carbohydrates = carbohydrates / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Calories = calories / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
