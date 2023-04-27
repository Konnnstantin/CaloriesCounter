using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaloriesCount.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaloriesCount.BL.Model;

namespace CaloriesCount.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciesControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var exerciseStart = DateTime.Now;
            var exerciseEnd = DateTime.Now.AddHours(1);
            var userController = new UserController(userName);
            var exerciseController = new ExerciesController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(50, 100));

            
            exerciseController.Add(activity, exerciseStart, exerciseEnd);

           
            Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);
        }
    }
}