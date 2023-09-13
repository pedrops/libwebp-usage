﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Entities.DTO
{
    public class EmployeeWeekPeriodDTO
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Profile { get; set; }
        public bool IsFullTime { get; set; }
        public decimal HourRate { get; set; }
        public bool Active { get; set; }
        public int WorkedHours { get; set; }
        public decimal Bonus { get; set; }
        public decimal WeekPayment { get; set; }
        public decimal WeekTotalPayment { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        
    }
}
