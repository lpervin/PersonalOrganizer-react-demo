using System;
using System.Linq;
using PersonalOrganizer.Domain.DataAccess;
using PersonalOrganizer.Domain.Repos;
using PersonalOrganizer.Domain.Models;
using PersonalOrganizer.Domain.Repos.Notes;
using Xunit;

namespace PersonalOrganizer.Test
{
    public class UnitTest1
    {

       [Fact]
        public void CanGetAllFromRepo()
        {
                var repo = new NotesRepository(new TrackerDbContext());
                var allNotes = repo.GetAllNotes().Result;
                Assert.NotNull(allNotes);
                Assert.NotEmpty(allNotes);
        }

        [Fact]
        public void CanAddNew()
        {
            var repo = new NotesRepository(new TrackerDbContext());
            var allNotes = repo.AddNote(new Note {NoteText = "Test Add", NoteDate = DateTime.Now});

            var newNote = repo.GetAllNotes().Result.OrderByDescending(n => n.NoteId).Take(1).FirstOrDefault();
            Assert.NotNull(newNote);
            Assert.Equal("Test Add", newNote.NoteText);

        }
        
        [Fact]
        public void CanUpdate()
        {
          
            var updateNote = new Note {NoteId = 10, NoteText = "Test Update", NoteDate = DateTime.Now};
            var repo = new NotesRepository(new TrackerDbContext());
            repo.UpdateNote(updateNote).Wait();
            var newNote = repo.GetNoteById(10).Result;
            Assert.NotNull(newNote);
            Assert.Equal("Test Update", newNote.NoteText);

        }

            
        [Fact]
        public void CanDelete()
        {
            var repo = new NotesRepository(new TrackerDbContext());
            repo.DeleteNote(43).Wait();
            var newNote = repo.GetNoteById(10).Result;
            Assert.Null(newNote);
        }



    }
}