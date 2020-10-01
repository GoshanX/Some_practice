using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class TopManager:IEmployee
    {
        double salary;
        public TopManager()
        {
            salary = Company.BaseSalary;
            if (Company.Income > 10000000)
            {
                salary += 1.5 * Company.BaseSalary;
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
