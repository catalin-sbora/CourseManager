using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.ApplicationLogic.DataModel
{
    public class CoursePresence
    {
        public Guid Id { get; set; }
        public Student Student { get; set; }
        public bool PresenceValue { get; set; }        
        public DateTime Date { get; set; }
    }
}
