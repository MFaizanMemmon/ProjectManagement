using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ToDoApp.DBManageFolder;
using ToDoApp.Interfaces;

namespace ToDoApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public AuthService(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public ClaimsPrincipal GetPrincipal()
        {
            return _contextAccessor.HttpContext.User;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                Console.WriteLine("Starting login process for username: " + username);

                // Check if _context is null
                if (_context == null)
                {
                    Console.WriteLine("DbContext (_context) is null");
                    return false;
                }

                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
                if (user == null)
                {
                    Console.WriteLine("User not found in database.");
                    return false;
                }

                // Check if _contextAccessor or HttpContext is null
                if (_contextAccessor == null || _contextAccessor.HttpContext == null)
                {
                    Console.WriteLine("_contextAccessor or HttpContext is null.");
                    return false;
                }

                Console.WriteLine("Creating claims for user: " + user.UserName);

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role ?? "DefaultRole") // Ensure Role is not null
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Sign in the user
                _contextAccessor.HttpContext.Items["SignIn"] = principal;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
                return false;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var principal = context.HttpContext.Items["SignIn"] as ClaimsPrincipal;
            if (principal != null)
            {
                context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
            }
        }
        public async Task Logout()
        {
            await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
