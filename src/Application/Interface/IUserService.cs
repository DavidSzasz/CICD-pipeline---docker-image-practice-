using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.request;
using Application.Dto.response;

namespace Application.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserResponseDto?>> GetAllUsersAsync();
        Task<GetUserResponseDto?> GetUserByIdAsync(int id);
        Task<CreateUserResponseDto?> CreateUserAsync(CreateUserRequestDto requestDto);
        Task<bool> UpdateUserAsync(int id, UpdateUserRequestDto requestDto);
        Task<bool> DeleteUserAsync(int id);
        Task<LoginUserResponseDto?> LoginAsync(string username, string email, string password);
    }
}