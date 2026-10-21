using Domain.Interface;
using Application.Interface;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.request;
using Application.Dto.response;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<GetUserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(user => new GetUserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            });
        }

        public async Task<GetUserResponseDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null) return null;

            return new GetUserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<CreateUserResponseDto> CreateUserAsync(CreateUserRequestDto requestDto)
        {
            var user = new User
            {
                Username = requestDto.Username,
                Email = requestDto.Email,
                PasswordHash = requestDto.Password
            };

            var createdUser = await _userRepository.AddAsync(user);

            return new CreateUserResponseDto
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Email = createdUser.Email
            };
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserRequestDto requestDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null) return false;

            user.Username = requestDto.Username;
            user.Email = requestDto.Email;

            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null) return false;

            await _userRepository.DeleteAsync(id);
            return true;
        }

        public async Task<LoginUserResponseDto?> LoginAsync(string username, string email, string password)
        {
            var user = await _userRepository.GetByUsernameOrEmailAsync(username, email);

            if (user is null || user.PasswordHash != password)
                return null;

            LoginUserResponseDto response = new LoginUserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };

            return response;
        }
    }
}