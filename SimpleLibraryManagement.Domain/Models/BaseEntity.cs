namespace SimpleLibraryManagement.Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
