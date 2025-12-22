using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day3_OOPS
{
    class Employee
    {
        public int EmpId;
        public string EmpName;

        // Constructor
        public Employee(int id, string name)
        {
            EmpId = id;
            EmpName = name;
        }
    }
}
