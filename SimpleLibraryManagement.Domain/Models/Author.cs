using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Domain.Models
{
    public class Author : BaseEntity
    {
        public DateOnly? BirthDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
