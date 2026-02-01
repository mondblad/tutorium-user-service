using Tutorium.UserService.Infrastructure.Data;
using Tutorium.UserService.Core.Users.Abstractions;
using Tutorium.UserService.Core.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Tutorium.UserService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PgContext _context;

        public UserRepository(PgContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(t => t.Email == email);
        }

        public async Task CreateUserAsync(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }
    }
}
