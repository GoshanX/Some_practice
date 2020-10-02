using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_3Test
{
    [TestClass]
    public class TopManagerTest
    {
        [TestMethod]
        public void CalculateSalaryUpTest()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(11000000);

            //action
            Task_3.TopManager topOfTheTopManager = new Task_3.TopManager(1000000, company);

            //assert
            Assert.AreEqual(topOfTheTopManager.getMonthSalary(), 2500000);
        }

        [TestMethod]
        public void CalculateSalaryTest()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(1800000);

            //action
            Task_3.TopManager simpleTopManager = new Task_3.TopManager(1000000, company);

            //assert
            Assert.AreEqual(simpleTopManager.getMonthSalary(), 1000000);
        }
    }
}
