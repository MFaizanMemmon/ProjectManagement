using Microsoft.EntityFrameworkCore;
using ToDoApp.Components.TeamPages;
using ToDoApp.DBManageFolder;
using ToDoApp.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class TeamProjectService : ITeamProject
    {
        private readonly ApplicationDbContext _context;
        public TeamProjectService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<TeamMemberProjects> AddTeamProjectList(List<TeamMemberProjects> teamProjects)
        {
            if (teamProjects == null || !teamProjects.Any())
                throw new ArgumentException("The teamProjects list cannot be null or empty.", nameof(teamProjects));

            await _context.TeamProjects.AddRangeAsync(teamProjects);
            await _context.SaveChangesAsync();

            // Return the first project or another suitable result
            return teamProjects.FirstOrDefault();
        }



        public Task<TeamMemberProjects> DeleteTeamProject(int teamId)
        {
            throw new NotImplementedException();

        }

        public Task<List<TeamMemberProjects>> GetTeamProject(int teamId)
        {
            return _context.TeamProjects.Where(x => x.ProjectId == teamId).ToListAsync();
        }

        public Task<List<TeamMemberProjects>> GetTeamProjects()
        {
            return _context.TeamProjects.ToListAsync();
        }
        
        public async Task<TeamMemberProjects> UpdateTeamProjectList(List<TeamMemberProjects> teamProjects)
        {
            _context.UpdateRange(teamProjects);
            await _context.SaveChangesAsync();
            return teamProjects.FirstOrDefault();

        }
    }
}
