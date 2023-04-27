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
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender(string name)
        {
            Name = name ?? throw new ArgumentNullException("Имя не может быть ноль", nameof(name));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
