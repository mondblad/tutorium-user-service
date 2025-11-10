using Microsoft.EntityFrameworkCore;

namespace Tutorium.UserService.Infrastructure.Data
{
    public partial class PgContext : DbContext
    {
        public PgContext(DbContextOptions<PgContext> options) : base(options) { }

        //public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Уникальный индекс на email
            /*modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();*/

            // Можно добавить конфигурацию ролей, длину полей и т.д.
        }
    }
}
