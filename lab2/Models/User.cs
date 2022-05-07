﻿using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool IsActive { get; set; }

        //Relationship
        public List<Blog>? Blogs { get; set; }
    }
}