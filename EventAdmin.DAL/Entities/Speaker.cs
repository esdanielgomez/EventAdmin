using System;
using System.Collections.Generic;

namespace EventAdmin.DAL.Entities
{
    public partial class Speaker
    {
        public int IdSpeaker { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string PhotoLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public int IdEvent { get; set; }

        public virtual Event IdEventNavigation { get; set; }
    }
}
