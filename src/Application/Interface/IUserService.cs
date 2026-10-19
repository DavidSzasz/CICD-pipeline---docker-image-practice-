using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.request;

namespace Application.Interface
{
    public interface IUserService<T> where T : class
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(CreateUserRequestDto requestDto);
        Task UpdateUserAsync(int id, UpdateUserRequestDto requestDto);
        Task DeleteUserAsync(int id);
    }
}
