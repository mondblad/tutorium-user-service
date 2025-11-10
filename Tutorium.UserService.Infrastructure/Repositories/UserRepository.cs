using Tutorium.UserService.Infrastructure.Data;
using Tutorium.UserService.Core.Models;
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

        public async Task<User?> GetUserByEmailAndPas(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(t => t.Email == email);
            
            if (user == null)
                return null;

            if (!string.IsNullOrEmpty(password))
                return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) ? user : null;

            return user;
        }

        public async Task<User> AddAsync(string email, string password)
        {
            var user = new User() { Email = email };

            if (!string.IsNullOrEmpty(password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var entry = await _context.Users.AddAsync(user);

            return entry.Entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
