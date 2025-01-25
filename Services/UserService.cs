using WatchList.Dtos;
using WatchList.Models;
using WatchList.Repositories;
using WatchList.Services;

namespace WatchList.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;  // Assuming you have a password hashing service

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> RegisterUserAsync(UserDto userDto, string password)
        {
            // Hash the password before saving it
            var passwordHash = _passwordHasher.HashPassword(password);

            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                Role = userDto.Role,
                CreatedAt = DateTime.UtcNow
            };

            return await _userRepository.AddUserAsync(user);
        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null) return false;

            // Compare the hashed password
            return _passwordHasher.VerifyPassword(password, user.PasswordHash);
        }
    }
}
