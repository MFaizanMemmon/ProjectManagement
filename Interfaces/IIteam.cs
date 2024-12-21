using ToDoApp.Models;

namespace ToDoApp.Interfaces
{
    public interface IIteam
    {
        Task<List<Teams>> Get();

        Task<Teams> Get(int id);

        Task<Teams> Add(Teams teams);

        Task<Teams> Update(Teams teams);

        Task<Teams> Delete(int id);

    }
}
