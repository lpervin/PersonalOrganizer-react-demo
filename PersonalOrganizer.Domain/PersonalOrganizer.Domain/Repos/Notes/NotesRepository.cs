using System;
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
        
        public async Task<List<Note>> GetAllNotes(string userIdentifier)
        {
                
                var notes = await _dbContext
                             .Notes
                             .Where(n => n.User.UserIdentifier == userIdentifier)
                            .OrderByDescending(n => n.NoteDate)
                            .ToListAsync();
                return notes;
            
        }

        public async Task<Note> GetNoteById(int id)
        {
            
                var note = await _dbContext.Notes.FindAsync(id);
                return note;
            
        }

        public async Task<Note> AddNote(Note note, string userIdentifier)
        {
                await AssignUser(note, userIdentifier);
                var newNote=  await _dbContext.Notes.AddAsync(note);
                await _dbContext.SaveChangesAsync();
                return newNote.Entity;
        }


        public async Task UpdateNote(Note note, string userIdentifier)
        {
                await AssignUser(note, userIdentifier);
                _dbContext.Update<Note>(note);
                await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNote(int id)
        {
                var noteToDelete = await _dbContext.Notes.FindAsync(id);
                _dbContext.Notes.Remove(noteToDelete);
                await _dbContext.SaveChangesAsync();
        }

        private async Task AssignUser(Note note, string userIdentifier)
        {
            //Lookup user id
            var appUser = await _dbContext.AppUsers.FirstOrDefaultAsync(u => u.UserIdentifier == userIdentifier);
            if (appUser == null)
                throw new ApplicationException("Invalid User");
            //assign userId to this todo
            note.AppUserId = appUser.Id;
        }
        
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}