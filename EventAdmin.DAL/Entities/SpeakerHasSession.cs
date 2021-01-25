using System;
using System.Collections.Generic;

namespace EventAdmin.DAL.Entities
{
    public partial class SpeakerHasSession
    {
        public int IdSpeaker { get; set; }
        public int IdSession { get; set; }

        public virtual Session IdSessionNavigation { get; set; }
        public virtual Speaker IdSpeakerNavigation { get; set; }
    }
}
