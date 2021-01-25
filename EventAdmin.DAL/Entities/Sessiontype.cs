using System;
using System.Collections.Generic;

namespace EventAdmin.DAL.Entities
{
    public partial class Sessiontype
    {
        public Sessiontype()
        {
            Session = new HashSet<Session>();
        }

        public int IdSessionType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Session> Session { get; set; }
    }
}
