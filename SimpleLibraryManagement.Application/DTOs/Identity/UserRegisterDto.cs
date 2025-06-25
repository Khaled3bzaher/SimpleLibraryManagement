﻿using System.ComponentModel.DataAnnotations;

namespace SimpleLibraryManagement.Application.DTOs.Identity
{
    public class UserRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
