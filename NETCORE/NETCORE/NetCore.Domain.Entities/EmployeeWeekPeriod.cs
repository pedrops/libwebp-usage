using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Entities
{
    public class EmployeeWeekPeriod : Employee
    {
        public int WorkedHours { get; set; }
    }
}
