using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.ApplicationLogic.DataModel
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
