using Microsoft.AspNetCore.Mvc;
using PessoasApi.Dtos.Users;
using PessoasApi.Services;

namespace PessoasApi.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(IUsersService usersService, TokenService tokenService) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService;
        private readonly TokenService _tokenService = tokenService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var user = await _usersService.RegisterAsync(dto.Username, dto.Email, dto.Password);

            var token = _tokenService.Generate(user);

            return Ok(new UserLoginResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = token
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var user = await _usersService.LoginAsync(dto.Username, dto.Password);

            if (user == null)
                return Unauthorized("Usuário ou senha inválidos");

            var token = _tokenService.Generate(user);

            return Ok(new UserLoginResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = token
            });
        }
    }
}
