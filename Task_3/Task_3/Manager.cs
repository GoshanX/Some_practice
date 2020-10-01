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
        public Manager()
        {
            Random r = new Random();
            salary = Company.BaseSalary + 0.05 * r.Next(115000, 140000);
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
