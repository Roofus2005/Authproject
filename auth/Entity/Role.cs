namespace auth.Entity
{
    public class Role : BaseEnity
    {
        public required string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}
