using Microsoft.EntityFrameworkCore;
using ToDoApp.DBManageFolder;
using ToDoApp.Interfaces;
using ToDoApp.Models;
namespace ToDoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationDbContext _context;
        public TodoService(ApplicationDbContext context)
        {
            _context = context;                
        }
        public async Task<ToDo> Add(ToDo todo)
        {
            _context.Todo.AddAsync(todo);
            await _context.SaveChangesAsync();
            
            return todo;
        }

        public async Task<ToDo> Delete(int id)
        {
            var toDo = await _context.Todo.FindAsync(id);
            _context.Todo.Remove(toDo);
            await _context.SaveChangesAsync();
            return toDo;
        }

        public async Task<List<ToDo>> Get()
        {
            return await _context.Todo.OrderByDescending(todo => todo.TodoId).ToListAsync();
        }

        public async Task<ToDo> Get(int id)
        {
           var todo = await _context.Todo.FindAsync(id);
           return todo;
        }

        public async Task<ToDo> Update(ToDo todo)
        {
           _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return todo;
        }
    }
}
