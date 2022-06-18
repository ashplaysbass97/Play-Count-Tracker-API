using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Abstractions;

namespace ServiceLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthResult> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return new AuthResult()
                {
                    Errors = new List<string>() { "Invalid email or password" }
                };
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (isValidPassword == true)
            {
                return new AuthResult()
                {
                    Success = true,
                    Token = _tokenService.GenerateToken(username)
                };
            }

            return new AuthResult()
            {
                Errors = new List<string>() { "Invalid email or password" }
            };
        }

        public async Task<AuthResult> RegisterAsync(string username, string password)
        {
            var user = new ApplicationUser() { UserName = username };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return new AuthResult()
                {
                    Success = true,
                    Token = _tokenService.GenerateToken(username)
                };
            }

            return new AuthResult()
            {
                Errors = result.Errors.Select(x => x.Description)
            };
        }
    }
}