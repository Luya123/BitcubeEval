using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Luya123.Models
{
    public class Degree
    {
        public int DegreeId { get; set; }

        [StringLength(50, MinimumLength = 3)]

        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName ="money")]

        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]

        public DateTime StartDate { get; set; }

        public int? LecturerId { get; set; }
        public  Lecturer Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }



    }
}