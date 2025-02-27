using Iris.Application.AuthUser.Dtos;
using Iris.Domain.Exceptions;
using Iris.Domain.Helpers;
using Iris.Domain.Options;
using MediatR;
using Microsoft.Extensions.Options;

namespace Iris.Application.AuthUser.Commands;

public record LoginUserCommand(string UserName, string Password): IRequest<AuthUserDto>;
public class LoginUserHandler(IOptions<AuthOptions> authOptions, JWTokenGenerator _jwt) : IRequestHandler<LoginUserCommand, AuthUserDto>
{
    public async Task<AuthUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        string userName = authOptions.Value.UserName;
        string password = authOptions.Value.Password;
        string id = authOptions.Value.Id;

        if (userName!=request.UserName || password!=request.Password)
        {
            throw new UserUnRegisteredException("El usuario ingresado es incorrecto");
        }
        string token = _jwt.GenerateToken(id);
        return new AuthUserDto
        {
            Id = id,
            Token = token,
            UserName = userName
        };
    }
}

