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
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public Exercise(DateTime start, DateTime end, User user, Activity activity)
        {
            Start = start;
            End = end;
            Activity = activity;
            User = user;
        }
    }
}
