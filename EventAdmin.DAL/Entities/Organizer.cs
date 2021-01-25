using System;
using System.Collections.Generic;

namespace EventAdmin.DAL.Entities
{
    public partial class Organizer
    {
        public int IdOrganizer { get; set; }
        public string Name { get; set; }
        public string LogoLink { get; set; }
        public string WebPage { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public int IdEvent { get; set; }

        public virtual Event IdEventNavigation { get; set; }
    }
}
