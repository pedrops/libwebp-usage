namespace NetCore.Domain.Entities.DTO
{
    public class EmployeeAddDTO
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal HourRate { get; set; } = 0;
        public string Profile { get; set; }
        public bool IsFullTime { get; set; }
    }
}
