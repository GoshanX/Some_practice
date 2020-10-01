using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public class Company
    {
        List<IEmployee> employees = new List<IEmployee>();
        public static double Income { get; set; }
        public static double BaseSalary { get; set; }
        public Company(double income,double baseSalary)
        {
            Income = income;
            BaseSalary = baseSalary;
        }
        public void Hire(IEmployee newEmployee)
        {
            employees.Add(newEmployee);
        }
        public void Fire(int count)
        {
            if (count > employees.Count)
            {
                employees.Clear();
            }
            else
            {
                Random r = new Random();
                for (int i = 0; i < count; i++)
                    employees.RemoveAt(r.Next(0,employees.Count-1));
            }
        }
        public void HireAll(List<IEmployee> newEmployees)
        {
            foreach(var emp in newEmployees)
            {
                employees.Add(emp);
            }
        }
        public void Fire(IEmployee employee)
        {
            employees.Remove(employee);
        }

        List<IEmployee> getTopSalaryStaff(int count)
        {
           employees = employees.OrderByDescending(i => i.getMonthSalary()).ToList();
           return employees.GetRange(0, count);
        }
        List<IEmployee> getLowestSalaryStaff(int count)
        {
            employees = employees.OrderBy(i => i.getMonthSalary()).ToList();
            return employees.GetRange(0, count);
        }

        public void PrintTopSalary(int count)
        {
            Console.WriteLine($"Топ {count} самых высоких зарплат:");
            foreach(var emp in getTopSalaryStaff(count))
            {
                Console.WriteLine(emp.getJobName() + " " + emp.getMonthSalary());
            }
        }
        public void PrintLowestSalary(int count)
        {
            Console.WriteLine($"Топ {count} самых низких зарплат:");
            foreach (var emp in getLowestSalaryStaff(count))
            {
                Console.WriteLine(emp.getJobName() +" " + emp.getMonthSalary());
            }
        }

    }
}
