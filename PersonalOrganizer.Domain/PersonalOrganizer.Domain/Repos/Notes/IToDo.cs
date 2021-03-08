using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalOrganizer.Domain.Models;

namespace PersonalOrganizer.Domain.Repos.Notes
{
    public interface IToDo
    {
        Task<List<ToDo>> GetAllTodos();
        Task<ToDo> AddTooDo(ToDo updateToDo);
        Task UpdateToDo(ToDo updateToDo);
        Task DeleteToDo(long id);
    }
}