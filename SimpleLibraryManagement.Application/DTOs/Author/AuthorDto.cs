using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Application.DTOs.Author
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly? BirthDate { get; set; }

    }
}
