using CaloriesCount.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCount.BL.Controller
{
    public class ExerciesController : BaseController
    {
        private readonly User user;
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";

        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciesController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExerices();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(_ => _.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, user, activity);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(end, begin, user, act);
                Exercises.Add(exercise);
            }
            SaveAllExerices();
        }

        private List<Exercise> GetAllExerices()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }
        private void SaveAllExerices()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
