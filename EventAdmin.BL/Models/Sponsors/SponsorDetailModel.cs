using System;
using System.Collections.Generic;
using System.Text;

namespace EventAdmin.BL.Models.Sponsors
{
    public class SponsorDetailModel
    {
        public int IdSponsor { get; set; }
        public string Name { get; set; }
        public string LogoLink { get; set; }
        public string Description { get; set; }
        public string WebPage { get; set; }
    }
}
