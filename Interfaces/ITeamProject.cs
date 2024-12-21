using ToDoApp.Components.TeamPages;
using ToDoApp.Models;

namespace ToDoApp.Interfaces
{
    public interface ITeamProject
    {
        Task<List<TeamMemberProjects>> GetTeamProjects();

        Task<List<TeamMemberProjects>> GetTeamProject(int teamId);

        Task<TeamMemberProjects> AddTeamProjectList(List<TeamMemberProjects> teamProjects);
        Task<TeamMemberProjects> UpdateTeamProjectList(List<TeamMemberProjects> teamProjects);

        Task<TeamMemberProjects> DeleteTeamProject(int teamId);

    }
}
