using Microsoft.EntityFrameworkCore;
using Tutorium.UserService.Core.Models;

namespace Tutorium.UserService.Infrastructure.Data
{
    public partial class PgContext
    {
        public DbSet<User> Users { get; set; }
    }
}
