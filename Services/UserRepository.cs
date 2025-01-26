// using WatchList.Models;
// using WatchList.Repositories;

// namespace WatchList.Repositories
// {
//     public class UserRepository : IUserRepository
//     {
//         private readonly YourDbContext _context;  // Assuming you use Entity Framework for data access

//         public UserRepository(YourDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<User> GetUserByIdAsync(int id)
//         {
//             return await _context.Users.FindAsync(id);
//         }

//         public async Task<User> GetUserByUsernameAsync(string username)
//         {
//             return await _context.Users
//                 .FirstOrDefaultAsync(u => u.Username == username);
//         }

//         public async Task<User> AddUserAsync(User user)
//         {
//             _context.Users.Add(user);
//             await _context.SaveChangesAsync();
//             return user;
//         }
//     }
// }
