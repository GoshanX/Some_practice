using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Operator : IEmployee
    {
        double salary;
        public Operator()
        {
            salary = Company.BaseSalary;
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
