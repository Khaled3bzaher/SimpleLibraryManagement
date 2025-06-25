namespace SimpleLibraryManagement.Application.DTOs.BorrowedBook
{
    public class BorrowedBookDto
    {
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
