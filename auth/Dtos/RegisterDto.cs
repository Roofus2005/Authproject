using auth.Enum;

namespace auth.Dtos
{
    public class RegisterDto
    {
        public Guid Id { get; set; } 
        public DateTime DateTimeCreated { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Occupation { get; set; }
        public required string UserName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }

    public class CreateRegisterModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string Occupation { get; set; }
        public required string UserName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
