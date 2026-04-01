using auth.Entity;

namespace auth.Dtos
{
    public class RoleDto
    {
        public Guid Id { get; set; } 
        public bool IsDeleted { get; set; } = false;
        public required string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }


}
