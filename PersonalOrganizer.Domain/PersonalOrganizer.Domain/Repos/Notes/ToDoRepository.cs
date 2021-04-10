using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersonalOrganizer.Domain.DataAccess;
using PersonalOrganizer.Domain.Models;

namespace PersonalOrganizer.Domain.Repos.Notes
{
    public class ToDoRepository : IToDo
    {
        private readonly TrackerDbContext _dbContext;
        public ToDoRepository(TrackerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<ToDo>> GetAllTodos(string userIdentifier)
        {
            
                return await _dbContext.ToDos
                    .Where(t => t.User.UserIdentifier == userIdentifier)   
                    .OrderByDescending(t => t.DateCreated)
                    .ToListAsync();
            
        }

        public async Task<ToDo> AddTooDo(ToDo addToDo, string userIdentifier)
        {
                //Lookup user id
                var appUser = await _dbContext.AppUsers.FirstOrDefaultAsync(u => u.UserIdentifier==userIdentifier);
                if (appUser==null)
                    throw new ApplicationException("Invalid User");
                //assign userId to this todo
                addToDo.AppUserId = appUser.Id;
                var newToDo = await _dbContext.ToDos.AddAsync(addToDo);
                await _dbContext.SaveChangesAsync();
                return newToDo.Entity;
            
        }

        public async Task UpdateToDo(ToDo updateToDo)
        {
                _dbContext.ToDos.Update(updateToDo);
                await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteToDo(long id)
        {
            
                var todoDelete = await _dbContext.ToDos.FindAsync(id);
                _dbContext.ToDos.Remove(todoDelete);
                await _dbContext.SaveChangesAsync();
            
        }

        public void Dispose()
       {
           _dbContext?.Dispose();
       }
    }
}