namespace SimpleLibraryManagement.Domain.Models
{
    public class Borrower : BaseEntity
    {
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }
    }
}
