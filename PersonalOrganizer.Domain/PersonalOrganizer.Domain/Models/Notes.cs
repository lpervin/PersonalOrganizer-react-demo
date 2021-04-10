using System;
using System.Text.Json.Serialization;

namespace PersonalOrganizer.Domain.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteText { get; set; }
        
        public long? AppUserId { get; set; }
        
        [JsonIgnore]
        public virtual AppUser User { get; set; }
        public DateTime NoteDate { get; set; }
    }
}