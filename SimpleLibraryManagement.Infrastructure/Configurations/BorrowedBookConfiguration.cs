using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleLibraryManagement.Domain.Models;
using System.Reflection.Emit;

namespace SimpleLibraryManagement.Infrastructure.Configurations
{
    internal class BorrowedBookConfiguration : IEntityTypeConfiguration<BorrowedBook>
    {
        public void Configure(EntityTypeBuilder<BorrowedBook> builder)
        {
            builder
               .HasKey(bb => new { bb.BookId, bb.BorrowerId });

            builder
                .HasOne(bb => bb.Borrower)
                .WithMany(bb => bb.BorrowedBooks)
                .HasForeignKey(bb => bb.BorrowerId);

            builder
               .HasOne(bb => bb.Book)
               .WithMany(bb => bb.BorrowedBooks)
               .HasForeignKey(bb => bb.BookId);
        }
    }
}
