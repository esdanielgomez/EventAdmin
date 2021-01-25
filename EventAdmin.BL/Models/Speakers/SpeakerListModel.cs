using EventAdmin.BL.Models.Sessions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventAdmin.BL.Models.Speakers
{
    public class SpeakerListModel
    {
        public int IdSpeaker { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }

    }
}
