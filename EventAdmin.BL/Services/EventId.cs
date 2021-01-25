using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAdmin.BL.Services
{
    public class EventId
    {
        private static EventId instance { get; set; } = null;

        public int Id { get; set; } = 1;

        private EventId() { }

        public static EventId GetInstance()
        {
            if (instance == null) {
                instance = new EventId();
            }

            return instance;
        }
    }
}
