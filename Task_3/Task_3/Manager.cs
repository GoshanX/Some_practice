using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Manager : IEmployee
    {
        double salary;
        readonly double PREMIUM_MANAGER_RATE = 0.05;
        readonly int LEFT_BORDER_OF_THE_PREMIUM_INTERVAL = 115000;
        readonly int RIGHT_BORDER_OF_THE_PREMIUM_INTERVAL = 140000;
        public Manager()
        {
            Random r = new Random();
            //BaseSalary with bonus
            salary = Company.BaseSalary + PREMIUM_MANAGER_RATE * r.Next(LEFT_BORDER_OF_THE_PREMIUM_INTERVAL, RIGHT_BORDER_OF_THE_PREMIUM_INTERVAL);
        }
        public string getJobName()
        {
            return this.GetType().Name;
        }

        public double getMonthSalary()
        {
            return salary;
        }
    }
}
