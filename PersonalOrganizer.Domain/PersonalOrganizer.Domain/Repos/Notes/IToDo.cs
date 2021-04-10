using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalOrganizer.Domain.Models;

namespace PersonalOrganizer.Domain.Repos.Notes
{
    public interface IToDo : IDisposable
    {
        Task<List<ToDo>> GetAllTodos(string userIdentifier);
        Task<ToDo> AddTooDo(ToDo updateToDo, string userIdentifier);
        Task UpdateToDo(ToDo updateToDo);
        Task DeleteToDo(long id);
    }
}