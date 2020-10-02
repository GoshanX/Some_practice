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
        public double Income { get; set; }

        public Company(double income)
        {
            Income = income;
        }

        /// <summary>
        /// Hiriring a new employee
        /// </summary>
        /// <param name="newEmployee">New person</param>
        public void Hire(IEmployee newEmployee)
        {
            if (Income > newEmployee.getMonthSalary())
            {
                employees.Add(newEmployee);
                Income -= newEmployee.getMonthSalary();
            }
            else
            {
                throw new Exception("Невозможно нанять сотрудника, так как недостаточно средств для выплаты зарплаты");
            }
        }

        /// <summary>
        /// dismissal of an employees
        /// </summary>
        /// <param name="count">count of employees</param>
        public void Fire(int count)
        {
            if(count < 0)
            {
                throw new ArgumentException("Неверное значение параметра count: только натуральные числа");
            }
            if (count > employees.Count)
            {
                employees.Clear();
            }
            else
            {
                Random r = new Random();
                for (int i = 0; i < count; i++)
                {
                    int indexRemove = r.Next(0, employees.Count - 1);
                    Income += employees[indexRemove].getMonthSalary();
                    employees.RemoveAt(indexRemove);
                }
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
                Hire(emp);
            }
        }

        /// <summary>
        /// dismissal employee
        /// </summary>
        /// <param name="employee"></param>
        public void Fire(IEmployee employee)
        {
            if (employees.Contains(employee))
            {
                employees.Remove(employee);
                Income += employee.getMonthSalary();
            }
            else
            {
                throw new ArgumentException("Неверное значение параметра employee: данный сотрудник не работает в компании");
            }
        }

        /// <summary>
        /// getting the list of employees with the highest salary
        /// </summary>
        /// <param name="count">count of employees</param>
        /// <returns></returns>
        List<IEmployee> getTopSalaryStaff(int count)
        {
            if (count < employees.Count && count > 0)
            {
                employees = employees.OrderByDescending(i => i.getMonthSalary()).ToList();
                return employees.GetRange(0, count);
            }
            else
            {
                throw new ArgumentException("Неверное значение параметра count");
            }
        }

        /// <summary>
        /// getting the list of employees with the lowest salary
        /// </summary>
        /// <param name="count">count of employees</param>
        /// <returns></returns>
        List<IEmployee> getLowestSalaryStaff(int count)
        {
            if (count < employees.Count && count > 0)
            {
                employees = employees.OrderBy(i => i.getMonthSalary()).ToList();
                return employees.GetRange(0, count);
            }
            else
            {
                throw new ArgumentException("Неверное значение параметра count");
            }
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

        /// <summary>
        /// Get number of employees in the company
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfEmployees()
        {
            return employees.Count;
        }
    }
}
