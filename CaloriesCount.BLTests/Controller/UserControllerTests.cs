using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaloriesCount.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCount.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-20);
            var gender = "man";
            var height = 172;
            var weight = 64;
            var userController = new UserController(userName);

            userController.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

           
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
        }
    }
}