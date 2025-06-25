using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleLibraryManagement.Domain.Models;
using SimpleLibraryManagement.Infrastructure.Configurations;

namespace SimpleLibraryManagement.Infrastructure.Data
{
    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BorrowedBookConfiguration).Assembly);

            modelBuilder.Entity<Author>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Book>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Borrower>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Category>()
                .HasQueryFilter(a => !a.IsDeleted);

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
    }
}
