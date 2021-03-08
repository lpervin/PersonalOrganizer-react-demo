using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalOrganizer.Domain.Models;
using PersonalOrganizer.Domain.Repos.Notes;

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
        
        //get all
        [HttpGet]
        public async Task<List<Note>> GetAllNotes()
        {
            return await _inotes.GetAllNotes();
        }
        
        //get by id
        [HttpGet("{id}")]
        public async Task<Note> GetById(int id)
        {
            return await _inotes.GetNoteById(id);
        }
        
        //Add
        [HttpPost]
        public async Task<Note> AddNew(Note newNote)
        {
            return await _inotes.AddNote(newNote);
        }
        
        //Update
        [HttpPut]
        public async Task Update(Note note)
        {
             await _inotes.UpdateNote(note);
        }
        
        //Delete
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _inotes.DeleteNote(id);
        }
    }
}