using Luya123.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Luya123.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name= "Number")]
        public int CourseId { get; set; }

        [StringLength(50,MinimumLength = 1)]
        public string Title { get; set; }

        [Range(0,10)]
        public int Credits { get; set; }
        public int DegreeId { get; set; }

        public Degree Degree { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Coursetaught> Coursetaughts { get; set; }
    }
}
