using Tutorium.UserService.Core.Users.Models;

namespace Tutorium.UserService.Core.Users.Abstractions
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User newUser);
    }
}
