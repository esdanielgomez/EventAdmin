using EventAdmin.BL.Models.Speakers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventAdmin.BL.Models.Sessions
{
    public class SessionListModel
    {
        public int IdSession { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string NameSessionType { get; set; }
        public string NameSessionLevel { get; set; }

    }
}
