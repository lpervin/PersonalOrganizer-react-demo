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
    public class NotesController : ControllerBase
    {
        private readonly INotes _inotes;
        public NotesController(INotes notesRepo)
        {
            _inotes = notesRepo;
        }
        
        [HttpGet]
        [Authorize]
        [ConfirmApplicationUser]
        public async Task<List<Note>> GetAllNotes()
        {
            var uid = User.Identity.Name;
            return await _inotes.GetAllNotes(uid);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<Note> GetById(int id)
        {
            return await _inotes.GetNoteById(id);
        }
        
        [HttpPost]
        [Authorize]/*TODO: add policy to check if user owns this item*/
        public async Task<Note> AddNew(Note newNote)
        {
            var uid = User.Identity?.Name;
            return await _inotes.AddNote(newNote, uid);
        }
        
        [HttpPut]
        [Authorize]/*TODO: add policy to check if user owns this item*/
        public async Task Update(Note note)
        {
            var uid = User.Identity?.Name;
             await _inotes.UpdateNote(note,uid);
        }
        
        [HttpDelete("{id}")]
        [Authorize]/*TODO: add policy to check if user owns this item*/
        public async Task Delete(int id)
        {
            await _inotes.DeleteNote(id);
        }
    }
}