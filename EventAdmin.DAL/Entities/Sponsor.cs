using System;
using System.Collections.Generic;

namespace EventAdmin.DAL.Entities
{
    public partial class Sponsor
    {
        public int IdSponsor { get; set; }
        public string Name { get; set; }
        public string LogoLink { get; set; }
        public string Description { get; set; }
        public string WebPage { get; set; }
        public int IdEvent { get; set; }

        public virtual Event IdEventNavigation { get; set; }
    }
}
