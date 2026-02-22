using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Tutorium.Grpc.User;
using Tutorium.UserService.Core.Users.Abstractions;
using Tutorium.UserService.Core.Users.Models;
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

        public override async Task<IsUserExistsResponse> IsUserExists(IsUserExistsRequest request, ServerCallContext context)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            return new IsUserExistsResponse() { Exists = user is not null };
        }

        public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            var newUser = new User()
            {
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                CreatedAt = request.CreatedAtUtc.ToDateTime(),
            };

            await _userRepository.CreateUserAsync(newUser);

            return new CreateUserResponse() { UserId = newUser.Id };
        }
    }
}
