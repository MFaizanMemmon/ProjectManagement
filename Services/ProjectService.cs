using Microsoft.EntityFrameworkCore;
using ToDoApp.DBManageFolder;
using ToDoApp.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Project> Add(Project project)
        {
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> Delete(int id)
        {
            var project = await _context.Project.FirstAsync(p => p.ProjectId == id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<List<Project>> Get()
        {
            return await _context.Project.ToListAsync();
        }

        public async Task<Project> Get(int id)
        {
            return await _context.Project.FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task<Project> Update(Project project)
        {
            _context.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }
    }
}
