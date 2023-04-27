using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCount.BL.Model
{/// <summary>
/// В дальнейшем реализовать проверки
/// </summary>
        [Serializable]
        public class User
        {
            private double _weight;
            public int Id { get; set; }
            public string Name { get; set; }
            public Gender Gender { get; set; }
            public DateTime BirthDate { get; set; }
            public double Weight
            {
                get { return _weight; }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentNullException(("Вес не может быть ноль или меньше"));
                    }
                    else
                    {
                        _weight = value;
                    }
                }
            }
            public double Height { get; set; }
            public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }


            public User(string name)
            {
                Name = name ?? throw new ArgumentNullException("Имя не может быть пустым", nameof(name));
            }
            public override string ToString()
            {
                return "Имя: " + Name + " " + "Возраст: " + Age;

            }
        }
}
