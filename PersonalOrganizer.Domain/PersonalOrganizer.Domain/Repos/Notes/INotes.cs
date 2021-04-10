using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalOrganizer.Domain.Models;

namespace PersonalOrganizer.Domain.Repos.Notes
{
    public interface INotes : IDisposable
    {
        Task<List<Note>> GetAllNotes(string userIdentifier);
        Task<Note> GetNoteById(int id);
        Task<Note> AddNote(Note note, string userIdentifier);
        Task UpdateNote(Note note, string userIdentifier);
        Task DeleteNote(int id);
    }
}