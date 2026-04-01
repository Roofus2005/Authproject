namespace auth.Entity
{
    public class BaseEnity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; } = false;
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
    }
}
