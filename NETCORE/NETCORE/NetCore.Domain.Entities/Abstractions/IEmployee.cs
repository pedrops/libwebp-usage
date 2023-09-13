﻿namespace NetCore.Domain.Entities.Abstractions
{
    public interface IEmployee : IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkingHours { get; set; }
        public string Title { get; set; }
        public bool IsFullTime { get; set; }
    }
}
