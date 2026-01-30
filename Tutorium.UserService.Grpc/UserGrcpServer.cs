using Grpc.Core;
using Tutorium.Grpc.User;
using Tutorium.UserService.Infrastructure.Repositories;
using static Tutorium.Grpc.User.UserGrpc;

namespace Tutorium.UserService.Grpc
{
    public class UserGrcpServer : UserGrpcBase
    {
        private readonly IUserRepository _userRepository;

        public UserGrcpServer(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public override async Task<UserExistsResponse> IsUserExists(UserExistsRequest request, ServerCallContext context)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            return new UserExistsResponse() { Exists = user is not null };
        }
    }
}
