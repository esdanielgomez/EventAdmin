using System;
using System.Collections.Generic;

namespace EventAdmin.DAL.Entities
{
    public partial class Event
    {
        public Event()
        {
            Organizer = new HashSet<Organizer>();
            Speaker = new HashSet<Speaker>();
            Sponsor = new HashSet<Sponsor>();
        }

        public int IdEvent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RegistrationLink { get; set; }
        public string StreamingLink { get; set; }

        public virtual ICollection<Organizer> Organizer { get; set; }
        public virtual ICollection<Speaker> Speaker { get; set; }
        public virtual ICollection<Sponsor> Sponsor { get; set; }
    }
}
