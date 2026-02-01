using Tutorium.Shared.Utils.BaseModel;
using Tutorium.UserService.Core.Models;

namespace Tutorium.UserService.Core.Users.Models
{
    public class User : BaseModelWithSoftDelete
    {
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        private readonly List<AuthCredential> _credentials = new();
        public IReadOnlyCollection<AuthCredential> Credentials => _credentials.AsReadOnly();
    }
}
