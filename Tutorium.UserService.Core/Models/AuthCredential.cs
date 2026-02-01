using Tutorium.Shared.Utils.EntityFramework.Attributes;
using Tutorium.Shared.Utils.BaseModel;
using Tutorium.UserService.Core.Users.Models;

namespace Tutorium.UserService.Core.Models
{
    public enum AuthProvider {
        EmailPassword = 0,
        Google = 1,
        Yandex = 2 
    }

    [SeparateTableAttribute]
    public abstract class AuthCredential : BaseModelWithSoftDelete
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public abstract AuthProvider Provider { get; }
    }

    public class GoogleCredential : AuthCredential
    {
        public override AuthProvider Provider => AuthProvider.Google;
        public string googleKey { get; set; } = null!;
    }

    public class EmailPasswordCredential : AuthCredential
    {
        public override AuthProvider Provider => AuthProvider.EmailPassword;
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
    }

    public class YandexCredential : AuthCredential
    {
        public override AuthProvider Provider => AuthProvider.Yandex;
    }
}
