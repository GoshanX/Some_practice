using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public class TopManager : Employee
    {
        readonly double PREMIUM_TOP_MANAGER_RATE = 1.5;
        readonly ulong PREMIUM_TOP_MANAGER_INCOME = 10000000;
        public TopManager(double baseSalary, Company company)
        {
            Salary = baseSalary;
            //Calculate bonus
            if (company.Income > PREMIUM_TOP_MANAGER_INCOME)
            {
                Salary += PREMIUM_TOP_MANAGER_RATE * Salary;
            }
            Company = company;
        }
    }
}
