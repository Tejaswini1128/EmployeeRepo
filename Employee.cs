using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlEmployeeApp
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
    }
}
