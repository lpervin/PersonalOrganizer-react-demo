using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalOrganizer.Domain.DataAccess;
using PersonalOrganizer.Domain.Models;

namespace PersonalOrganizer.Domain.Repos.Notes
{
    public class NotesRepository: INotes
    {
        private readonly TrackerDbContext _dbContext;

        public NotesRepository(TrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<Note>> GetAllNotes()
        {
             
            await using (_dbContext)
            {
                
                var notes = await _dbContext
                            .Notes
                            .OrderByDescending(n => n.NoteDate)
                            .ToListAsync();
                return notes;
            }
        }

        public async Task<Note> GetNoteById(int id)
        {
            
            await using (_dbContext)
            {
                var note = await _dbContext.Notes.FindAsync(id);
                return note;
            }
        }

        public async Task<Note> AddNote(Note note)
        {
             
            await using (_dbContext)
            {
                var newNote=  await _dbContext.Notes.AddAsync(note);
                await _dbContext.SaveChangesAsync();
                return newNote.Entity;
            }
        }

        public async Task UpdateNote(Note note)
        {
            
            await using (_dbContext)
            {
                // dbContext.Notes.Attach(note);
                _dbContext.Update<Note>(note);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteNote(int id)
        {
            
            await using (_dbContext)
            {
                var noteToDelete = await _dbContext.Notes.FindAsync(id);
                _dbContext.Notes.Remove(noteToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}