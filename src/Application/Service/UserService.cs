
using Domain.Interface;
using Application.Interface;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.request;

namespace Application.Services
{
    public class UserService<T> : IUserService<T> where T : class
    {
        private readonly IUserRepository<User> _userRepository;

        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            });
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        public async Task<UserDto> CreateUserAsync(CreateUserRequestDto requestDto)
        {
            var user = new User
            {
                Username = requestDto.Username,
                Email = requestDto.Email,
                PasswordHash = requestDto.Password//need to be hashed in future
            };

            var createdUser = await _userRepository.AddAsync(user);

            return new UserDto
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Email = createdUser.Email
            };
        }

        public async Task UpdateUserAsync(int id, UpdateUserRequestDto requestDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return;

            user.Username = requestDto.Username;
            user.Email = requestDto.Email;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}