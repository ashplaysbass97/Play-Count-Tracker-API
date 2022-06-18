using DomainLayer.Models;
using ServiceLayer.Abstractions;
namespace PlayCountTrackerAPI.Routes
{
    public static class UserRoutes
    {
        public static void ConfigureUserRoutes(this WebApplication app)
        {
            app.MapPost("/login", Login).AllowAnonymous();
            app.MapPost("/register", Register).AllowAnonymous();
        }

        private static async Task<IResult> Login(IAuthService authService, User user)
        {
            var result = await authService.LoginAsync(user.Username, user.Password);
            if (result.Success)
                return Results.Ok(result.Token);

            return Results.BadRequest(result.Errors);
        }

        private static async Task<IResult> Register(IAuthService authService, User user)
        {
            var result = await authService.RegisterAsync(user.Username, user.Password);
            if (result.Success)
                return Results.Ok(result.Token);

            return Results.BadRequest(result.Errors);
        }
    }

}
