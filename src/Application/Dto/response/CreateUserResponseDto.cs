using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.response
{
    public class CreateUserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}
