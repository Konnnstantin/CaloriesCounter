using CaloriesCount.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCount.BL.Controller
{
    public class UserController : BaseController
    {
        private const string FILE_USERS = "users.dat";
        public List<User> Users { get; }
        public User CurrentUser { get; }

        public bool IsNewUser = false;

        public UserController(string name)
        {
            Users = GetUserData();
            CurrentUser = Users.SingleOrDefault(_ => _.Name == name);

            if (CurrentUser == null)
            {
                CurrentUser = new User(name);
                Users.Add(CurrentUser);
                IsNewUser = true;
                SaveUserData();
            }
        }
        private List<User> GetUserData()
        {
            return Load<List<User>>(FILE_USERS) ?? new List<User>();
        }
        public void SetNewUserData(string genderName, DateTime birthDay, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            SaveUserData();
        }
        private void SaveUserData()
        {
            Save(FILE_USERS, Users);
        }
    }
}
