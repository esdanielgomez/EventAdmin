using System;
using System.Collections.Generic;

namespace EventAdmin.DAL.Entities
{
    public partial class Sessionlevel
    {
        public Sessionlevel()
        {
            Session = new HashSet<Session>();
        }

        public int IdSessionLevel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Session> Session { get; set; }
    }
}
