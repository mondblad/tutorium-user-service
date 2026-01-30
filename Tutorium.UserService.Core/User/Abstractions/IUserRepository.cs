using Tutorium.UserService.Core.Models;

namespace Tutorium.UserService.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        /*Task<User?> GetUserByEmailAndPas(string email, string password);
        Task<User> AddAsync(string email, string password);
        Task SaveChangesAsync();*/
    }
}
