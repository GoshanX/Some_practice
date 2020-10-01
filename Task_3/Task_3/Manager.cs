using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Manager : Employee
    {
        readonly double PREMIUM_MANAGER_RATE = 0.05;
        readonly int LEFT_BORDER_OF_THE_PREMIUM_INTERVAL = 115000;
        readonly int RIGHT_BORDER_OF_THE_PREMIUM_INTERVAL = 140000;
        public Manager(double baseSalary, Company company)
        {
            Random r = new Random();
            //BaseSalary with bonus
            Salary = baseSalary + PREMIUM_MANAGER_RATE * r.Next(LEFT_BORDER_OF_THE_PREMIUM_INTERVAL, RIGHT_BORDER_OF_THE_PREMIUM_INTERVAL);
            Company = company;
        }
    }
}
