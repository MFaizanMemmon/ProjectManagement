using Microsoft.EntityFrameworkCore;
using ToDoApp.DBManageFolder;
using ToDoApp.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class TeamService : IIteam
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teams> Add(Teams teams)
        {
           _context.Teams.Add(teams);
           await _context.SaveChangesAsync();
            return teams;
        }

        public async Task<Teams> Delete(int id)
        {
           var result = await _context.Teams.FindAsync(id);
            if (result != null)
            {
                _context.Remove(id);
                _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<List<Teams>> Get()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Teams> Get(int id)
        {
            return await _context.Teams.FindAsync(id);
        }


        public async Task<Teams> Update(Teams teams)
        {
            _context.Teams.Update(teams); 
            await _context.SaveChangesAsync(); 
            return teams; 
        }

    }
}
