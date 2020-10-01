using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class TopManager : IEmployee
    {
        double salary;
        readonly double PREMIUM_TOP_MANAGER_RATE = 1.5;
        readonly ulong PREMIUM_TOP_MANAGER_INCOME = 10000000;
        public TopManager()
        {
            salary = Company.BaseSalary;
            //Calculate bonus
            if (Company.Income > PREMIUM_TOP_MANAGER_INCOME)
            {
                salary += PREMIUM_TOP_MANAGER_RATE * Company.BaseSalary;
            }
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
