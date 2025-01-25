using WatchList.Dtos;
using WatchList.Models;

namespace WatchList.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> RegisterUserAsync(UserDto userDto, string password);
        Task<bool> ValidateUserAsync(string username, string password);
    }
}
