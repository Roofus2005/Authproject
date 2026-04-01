using auth.Entity;
using System.ComponentModel.DataAnnotations;

namespace auth.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; } 
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }

    public class LoginRequestModel
    {
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
