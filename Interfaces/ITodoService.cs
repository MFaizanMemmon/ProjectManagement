using ToDoApp.Models;

namespace ToDoApp.Interfaces
{
    public interface ITodoService
    {
        Task<List<ToDo>> Get();
        Task<ToDo> Get(int id);
        Task<ToDo> Add(ToDo todo);
        Task<ToDo> Update(ToDo todo);
        Task<ToDo> Delete(int id);



    }
}
