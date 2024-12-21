using ToDoApp.Models;

namespace ToDoApp.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> Get();
        Task<Project> Get(int id);
        Task<Project> Add(Project project);
        Task<Project> Update(Project project);
        Task<Project> Delete(int id);

        
    }
}
