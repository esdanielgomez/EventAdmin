using System;
using System.Collections.Generic;
using System.Text;

namespace EventAdmin.BL.Models.Organizers
{
    public class OrganizerDetailModel
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
    }
}
