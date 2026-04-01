namespace auth.Entity
{
    public class User : BaseEnity
    {
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public Guid RegisterId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}
