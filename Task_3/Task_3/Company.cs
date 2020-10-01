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
        public static ulong Income { get; set; }
        public static double BaseSalary { get; set; }
        public Company(ulong income, double baseSalary)
        {
            Income = income;
            BaseSalary = baseSalary;
        }
        /// <summary>
        /// Hiriring a new employee
        /// </summary>
        /// <param name="newEmployee">New person</param>
        public void Hire(IEmployee newEmployee)
        {
            employees.Add(newEmployee);
        }
        /// <summary>
        /// dismissal of an employees
        /// </summary>
        /// <param name="count">count of employees</param>
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
                    employees.RemoveAt(r.Next(0, employees.Count - 1));
            }
        }
        /// <summary>
        /// Hiring employees from the list
        /// </summary>
        /// <param name="newEmployees">list of employees</param>
        public void HireAll(List<IEmployee> newEmployees)
        {
            foreach (var emp in newEmployees)
            {
                employees.Add(emp);
            }
        }
        /// <summary>
        /// dismissal employee
        /// </summary>
        /// <param name="employee"></param>
        public void Fire(IEmployee employee)
        {
            employees.Remove(employee);
        }
        /// <summary>
        /// getting the list of employees with the highest salary
        /// </summary>
        /// <param name="count">count of employees</param>
        /// <returns></returns>
        List<IEmployee> getTopSalaryStaff(int count)
        {
            employees = employees.OrderByDescending(i => i.getMonthSalary()).ToList();
            return employees.GetRange(0, count);
        }
        /// <summary>
        /// getting the list of employees with the lowest salary
        /// </summary>
        /// <param name="count">count of employees</param>
        /// <returns></returns>
        List<IEmployee> getLowestSalaryStaff(int count)
        {
            employees = employees.OrderBy(i => i.getMonthSalary()).ToList();
            return employees.GetRange(0, count);
        }
        /// <summary>
        /// Print top employee`s salaries
        /// </summary>
        /// <param name="count"></param>
        public void PrintTopSalary(int count)
        {
            Console.WriteLine($"Топ {count} самых высоких зарплат:");
            var pos = 1;
            foreach (var emp in getTopSalaryStaff(count))
            {
                Console.WriteLine(pos + ") " + emp.getJobName() + " " + emp.getMonthSalary() + " руб.");
                pos++;
            }
        }
        /// <summary>
        /// Print low employee`s salaries
        /// </summary>
        /// <param name="count"></param>
        public void PrintLowestSalary(int count)
        {
            Console.WriteLine($"Топ {count} самых низких зарплат:");
            var pos = 1;
            foreach (var emp in getLowestSalaryStaff(count))
            {
                Console.WriteLine(pos + ") " + emp.getJobName() + " " + emp.getMonthSalary() + " руб.");
                pos++;
            }
        }
    }
}
