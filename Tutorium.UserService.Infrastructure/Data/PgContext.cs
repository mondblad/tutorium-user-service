using Microsoft.EntityFrameworkCore;
using Tutorium.Shared.Utils.EntityFramework.Extensions;

namespace Tutorium.UserService.Infrastructure.Data
{
    public partial class PgContext : DbContext
    {
        public PgContext(DbContextOptions<PgContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ModelBuilderExtensions.ApplySeparateTableAttribute(modelBuilder);
        }
    }
}
