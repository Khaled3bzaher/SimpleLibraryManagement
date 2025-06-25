namespace SimpleLibraryManagement.Domain.Models
{
    public class Category : BaseEntity
    {
        public ICollection<Book> Books { get; set; }
    }
}
