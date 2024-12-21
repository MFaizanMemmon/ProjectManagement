using System.Security.Claims;

namespace ToDoApp.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string username, string password);
        Task Logout();
        
        ClaimsPrincipal GetPrincipal();
    }
}
