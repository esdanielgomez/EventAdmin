using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAdmin.BL.Models
{
    public class SpeakerHasSessionModel
    {
        public int IdSpeaker { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }

        public int IdSession { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string NameSessionType { get; set; }
        public string NameSessionLevel { get; set; }
    }
}
