using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace Domain.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Username { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;
        [Required]
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
