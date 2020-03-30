using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.ApplicationLogic.DataModel
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }

    }
}
