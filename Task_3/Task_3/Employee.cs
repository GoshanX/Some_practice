﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public class Employee : IEmployee
    {
        protected double Salary { get; set; }
        protected Company Company { get; set; }

        public string getJobName()
        {
            return GetType().Name;
        }

        public double getMonthSalary()
        {
            return Salary;
        }
    }
}
