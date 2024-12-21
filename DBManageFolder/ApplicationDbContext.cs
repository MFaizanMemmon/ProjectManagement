using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ToDoApp.Models;

namespace ToDoApp.DBManageFolder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<ToDo> Todo { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Teams> Teams { get; set; }
        public DbSet<TeamMemberProjects> TeamProjects { get; set; }

        public DbSet<Users> Users { get; set; }

        


    }
}
