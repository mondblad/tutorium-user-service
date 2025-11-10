using Grpc.Core;
using Tutorium.Shared;
using Tutorium.UserService.Infrastructure.Repositories;


namespace Tutorium.UserService.Api.GrpcServices
{
    public class UserGrpcService : User.UserBase
    {
        private readonly IUserRepository _userRepository;

        public UserGrpcService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async override Task<GetOrCreateUserResponse> GetOrCreateUser(GetOrCreateUserRequest request, ServerCallContext context)
        {
            var user = await _userRepository.GetUserByEmailAndPas(request.Email, request.Password);

            if (user is null)
            {
                user = await _userRepository.AddAsync(request.Email, request.Password);
                await _userRepository.SaveChangesAsync();
            }

            return new GetOrCreateUserResponse() { UserId = user.Id };
        }
    }
}
