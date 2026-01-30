using Microsoft.EntityFrameworkCore;
using Tutorium.UserService.Core.Models;

namespace Tutorium.UserService.Infrastructure.Data
{
    public partial class PgContext
    {
        public DbSet<User> Users { get; set; }

        #region Credentials

        public DbSet<GoogleCredential> GoogleCredentials { get; set; }
        public DbSet<EmailPasswordCredential> EmailPasswordCredentials { get; set; }
        public DbSet<YandexCredential> YandexCredentials { get; set; }

        #endregion Credentials
    }
}
