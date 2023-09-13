using NetCore.Domain.Entities.DTO;

namespace NetCore.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address{ get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Profile{ get; set; }
        public bool IsFullTime { get; set; }
        public decimal HourRate { get; set; }
        public bool Active { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


        public Employee()
        { }

        public Employee(EmployeeDTO dto)
        {
            if(dto.Id != null)
                Id = dto.Id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Address = dto.Address;
            Email = dto.Email;
            PhoneNumber = dto.PhoneNumber;
            Profile = dto.Profile;
            IsFullTime = dto.IsFullTime;
            InsertedDate = dto.InsertedDate;
            UpdatedDate = dto.UpdatedDate;
            HourRate  = dto.HourRate;
            Active = dto.Active;
        }


    }

}

