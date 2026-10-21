using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.request
{
    internal class DeleteUserRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
