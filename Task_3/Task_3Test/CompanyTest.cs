using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Task_3Test
{
    [TestClass]
    public class CompanyTest
    {
        [TestMethod]
        public void HireTestNumberOfEmployees()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(200000);
            Task_3.IEmployee new_operator = new Task_3.Operator(100000, company);

            //action
            company.Hire(new_operator);

            //assert
            Assert.AreEqual(company.GetNumberOfEmployees(), 1);
        }

        [TestMethod]
        public void HireTestIncome()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(200000);
            Task_3.IEmployee new_operator = new Task_3.Operator(100000, company);

            //action
            company.Hire(new_operator);

            //assert
            Assert.AreEqual(company.Income, 100000);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void HireTestException()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(200000);
            Task_3.IEmployee new_operator = new Task_3.Operator(300000, company);

            //action
            company.Hire(new_operator);
        }

        [TestMethod]
        public void FireTestIncome()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(2000000);
            Task_3.IEmployee manager = new Task_3.Manager(100000, company);
            List<Task_3.IEmployee> employees = new List<Task_3.IEmployee>() { new Task_3.Operator(10000, company), new Task_3.Manager(1000000, company), manager };

            //action
            company.HireAll(employees);
            var oldIncome = company.Income;
            company.Fire(manager);

            //assert
            Assert.AreEqual(company.Income, oldIncome + manager.getMonthSalary());
        }

        [TestMethod]
        public void FireTestNumberOfEmployees()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(2000000);
            Task_3.IEmployee manager = new Task_3.Manager(100000, company);
            List<Task_3.IEmployee> employees = new List<Task_3.IEmployee>() { new Task_3.Operator(10000, company), new Task_3.Manager(1000000, company), manager };
            
            //action
            company.HireAll(employees);
            company.Fire(manager);

            //assert
            Assert.AreEqual(company.GetNumberOfEmployees(), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FireTestExceprionWhenEmployeeDoesntExist()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(2000000);
            Task_3.IEmployee manager = new Task_3.Manager(100000, company);
            List<Task_3.IEmployee> employees = new List<Task_3.IEmployee>() { new Task_3.Operator(10000, company), new Task_3.Manager(1000000, company) };
            
            //action
            company.HireAll(employees);
            company.Fire(manager);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FireTestExceprionWhenCountLessThenZero()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(2000000);
            Task_3.IEmployee manager = new Task_3.Manager(100000, company);
            List<Task_3.IEmployee> employees = new List<Task_3.IEmployee>() { new Task_3.Operator(10000, company), new Task_3.Manager(1000000, company) };
            
            //action
            company.HireAll(employees);
            company.Fire(-1);
        }

        [TestMethod]
        public void HireAllTestNamberOfEmployees()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(2000000);
            Task_3.IEmployee manager = new Task_3.Manager(100000, company);
            List<Task_3.IEmployee> employees = new List<Task_3.IEmployee>() { new Task_3.Operator(10000, company), new Task_3.Manager(1000000, company), manager };

            //action
            company.HireAll(employees);

            //assert
            Assert.AreEqual(company.GetNumberOfEmployees(), 3);
        }

        [TestMethod]
        public void FireTestNamberOfEmployeesWhenParametrCount()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(2000000);
            Task_3.IEmployee manager = new Task_3.Manager(100000, company);
            List<Task_3.IEmployee> employees = new List<Task_3.IEmployee>() { new Task_3.Operator(10000, company), new Task_3.Manager(1000000, company), manager };

            //action
            company.HireAll(employees);
            company.Fire(2);

            //assert
            Assert.AreEqual(company.GetNumberOfEmployees(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintTopSalaryTestArgumentException()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(2000000);
            Task_3.IEmployee manager = new Task_3.Manager(100000, company);
            List<Task_3.IEmployee> employees = new List<Task_3.IEmployee>() { new Task_3.Operator(10000, company), new Task_3.Manager(1000000, company) };
           
            //action
            company.HireAll(employees);
            
            //ArgumentException, because number of employees = 3
            company.PrintTopSalary(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintLowestSalaryTestArgumentException()
        {
            //arrange
            Task_3.Company company = new Task_3.Company(2000000);
            Task_3.IEmployee manager = new Task_3.Manager(100000, company);
            List<Task_3.IEmployee> employees = new List<Task_3.IEmployee>() { new Task_3.Operator(10000, company), new Task_3.Manager(1000000, company) };
           
            //action
            company.HireAll(employees);
            
            //ArgumentException, because count < 1
            company.PrintLowestSalary(-10);
        }

    }
}