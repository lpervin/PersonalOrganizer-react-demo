using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PersonalOrganizer.Domain.Models
{
    public class ToDo
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public long? AppUserId { get; set; }
       
        [JsonIgnore]
        public virtual AppUser User { get; set; }
        public DateTime DateCreated { get; set; }
        public Nullable<DateTime> DateCompleted { get; set; }
    }
}