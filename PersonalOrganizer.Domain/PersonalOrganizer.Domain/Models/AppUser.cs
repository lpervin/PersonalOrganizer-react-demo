using System.Collections.Generic;

namespace PersonalOrganizer.Domain.Models
{
    public class AppUser
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string UserEamil { get; set; }
        public string IdProvider { get; set; }
        public virtual List<ToDo> UserToDos { get; set; }
        public virtual List<Note> UserNotes { get; set; }
        
    }
}