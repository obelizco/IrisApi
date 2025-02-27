using Iris.Application.AuthUser.Commands;
using Iris.Application.AuthUser.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IrisApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator _mediator) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<AuthUserDto> Login(LoginUserCommand command)
    {
        return await _mediator.Send(command);
    }

}
