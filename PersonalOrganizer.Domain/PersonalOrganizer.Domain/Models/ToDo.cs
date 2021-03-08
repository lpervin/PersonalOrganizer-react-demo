using System;

namespace PersonalOrganizer.Domain.Models
{
    public class ToDo
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCreated { get; set; }
        public Nullable<DateTime> DateCompleted { get; set; }
    }
}