using System;
using System.Collections.Generic;

namespace Luya123.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public string EmailAddress { get; set; }
      
        public DateTime DateOfBirth { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
