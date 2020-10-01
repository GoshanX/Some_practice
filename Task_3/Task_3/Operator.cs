using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Operator : Employee
    {
        public Operator(double baseSalary, Company company)
        {
            Salary = baseSalary;
            Company = company;
        }
    }
}
