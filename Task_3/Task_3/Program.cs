using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        public static void Main()
        {
            Company company = new Company(110000000);

            for (int i = 0; i < 180; i++)
            {
                company.Hire(new Operator(100000, company));
            }
            for (int i = 0; i < 80; i++)
            {
                company.Hire(new Manager(200000, company));
            }
            for (int i = 0; i < 10; i++)
            {
                company.Hire(new TopManager(300000, company));
            }

            company.PrintTopSalary(15);
            company.PrintLowestSalary(30);

            company.Fire(50);

            company.PrintTopSalary(15);
            company.PrintLowestSalary(30);
        }
    }
}
