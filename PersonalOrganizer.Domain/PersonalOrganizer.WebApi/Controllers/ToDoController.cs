using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalOrganizer.Domain.Models;
using PersonalOrganizer.Domain.Repos.Notes;

namespace PersonalOrganizer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController  : Controller
    {
        private readonly IToDo _iToDoRepo;

        public ToDoController(IToDo todoRepo)
        {
            _iToDoRepo = todoRepo;
        }
        
        [HttpGet]
        public async Task<List<ToDo>> GetAllNotes()
        {
            return await _iToDoRepo.GetAllTodos();
        }

        [HttpPost]
        public async Task<ToDo> AddToDo(ToDo todoItem)
        {
            return await _iToDoRepo.AddTooDo(todoItem);
        }

        [HttpPut]
        public async Task UpdateToDo(ToDo todoItem)
        {
            await _iToDoRepo.UpdateToDo(todoItem);
        }

        [HttpDelete("{id}")]
        public async Task DeleteToDo(long id)
        {
            await _iToDoRepo.DeleteToDo(id);
        }

        [HttpGet]
        [Route("private")]
        [Authorize]
        public IActionResult Private()
        {
            var uid = User.Identity.Name;
            return Json(new
            {
                Message = $"Hello {uid} from a private endpoint! You need to be authenticated and have a scope of read:messages to see this."
            });
        }
    }
}