﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Application.DTOs.Book
{
    public class DisplayBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string AutherName { get; set; }
        public DateOnly PublicationDate { get; set; }
    }
}
