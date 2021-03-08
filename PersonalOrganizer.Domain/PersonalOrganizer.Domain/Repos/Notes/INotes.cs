using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalOrganizer.Domain.Models;

namespace PersonalOrganizer.Domain.Repos.Notes
{
    public interface INotes
    {
        Task<List<Note>> GetAllNotes();
        Task<Note> GetNoteById(int id);
        Task<Note> AddNote(Note note);
        Task UpdateNote(Note note);
        Task DeleteNote(int id);
    }
}