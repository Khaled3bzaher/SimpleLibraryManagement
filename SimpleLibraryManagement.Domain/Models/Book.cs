namespace SimpleLibraryManagement.Domain.Models
{
    public class Book : BaseEntity
    {
        public DateOnly PublicationDate { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }
    }
}
