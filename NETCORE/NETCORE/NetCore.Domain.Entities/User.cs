using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NetCore.Domain.Entities.DTO;
using System;

namespace NetCore.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(UserDTO dto)
        {
            if (dto.Id != null)
                Id = dto.Id;
            UserName = dto.UserName;
            Password = dto.Password;
        }
    }
}
