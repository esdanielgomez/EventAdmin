using System;
using System.Collections.Generic;

namespace EventAdmin.DAL.Entities
{
    public partial class Session
    {
        public int IdSession { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string IconLink { get; set; }
        public int IdSessionType { get; set; }
        public int IdSessionLevel { get; set; }

        public virtual Sessionlevel IdSessionLevelNavigation { get; set; }
        public virtual Sessiontype IdSessionTypeNavigation { get; set; }
    }
}
