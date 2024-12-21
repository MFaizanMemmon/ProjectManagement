using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Components;
using ToDoApp.DBManageFolder;
using ToDoApp.Interfaces;
using ToDoApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";  // Redirect to login page if not authenticated
        options.LogoutPath = "/logout"; // Define logout path
        options.AccessDeniedPath = "/access-denied"; // Access denied page
        options.Cookie.Name = "MyAppAuthCookie";
        options.Cookie.HttpOnly = true;
    });

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));


builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IIteam, TeamService>();
builder.Services.AddTransient<ITeamProject,TeamProjectService>();
builder.Services.AddTransient<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Map("/", context =>
{
    context.Response.Redirect("/login");
    return Task.CompletedTask;
});


app.Run();
