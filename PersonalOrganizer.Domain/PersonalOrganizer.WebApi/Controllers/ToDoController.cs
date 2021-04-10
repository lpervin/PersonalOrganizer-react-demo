using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalOrganizer.Domain.Models;
using PersonalOrganizer.Domain.Repos.Notes;
using PersonalOrganizer.WebApi.Auth;

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
        [Authorize]/*TODO: add policy to check if user owns this item*/
        [ConfirmApplicationUser]
        public async Task<List<ToDo>> GetAllNotes()
        {
            var uid = User.Identity.Name;
            return await _iToDoRepo.GetAllTodos(uid);
        }

        [HttpPost]
        [Authorize] /*TODO: add policy to check if user owns this item*/
        public async Task<ToDo> AddToDo(ToDo todoItem)
        {
            var uid = User.Identity.Name;
            return await _iToDoRepo.AddTooDo(todoItem, uid);
        }

        [HttpPut]
        [Authorize]/*TODO: add policy to check if user owns this item*/
        public async Task UpdateToDo(ToDo todoItem)
        {
            await _iToDoRepo.UpdateToDo(todoItem);
        }
        
        [Authorize]/*TODO: add policy to check if user owns this item*/
        [HttpDelete("{id}")]
        public async Task DeleteToDo(long id)
        {
            await _iToDoRepo.DeleteToDo(id);
        }

        [HttpGet]
        [Route("private")]
        [Authorize]
        [ConfirmApplicationUser]
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