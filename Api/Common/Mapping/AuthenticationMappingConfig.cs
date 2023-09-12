using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Queries;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest.Id, src => src.User.Id.Value)
                .Map(dest => dest.Email, src => src.User.Email)
                .Map(dest => dest.FirstName, src => src.User.FirstName)
                .Map(dest => dest.LastName, src => src.User.LastName);
        }
    }
}
