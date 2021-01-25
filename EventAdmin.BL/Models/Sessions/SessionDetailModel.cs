using EventAdmin.BL.Models.Speakers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventAdmin.BL.Models.Sessions
{
    public class SessionDetailModel
    {
        public int IdSession { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string IconLink { get; set; }
        public int IdSessionType { get; set; }
        public string NameSessionType { get; set; }
        public int IdSessionLevel { get; set; }
        public string NameSessionLevel { get; set; }

        public List<SpeakerHasSessionModel> SpeakersSessions { get; set; }
    }
}
