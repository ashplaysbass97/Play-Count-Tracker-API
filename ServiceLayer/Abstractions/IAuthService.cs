using DomainLayer.Models;

namespace ServiceLayer.Abstractions
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(string username, string password);
        Task<AuthResult> RegisterAsync(string username, string password);
    }
}
