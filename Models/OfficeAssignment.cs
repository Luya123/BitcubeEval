using System.ComponentModel.DataAnnotations;

namespace Luya123.Models
{
    public class OfficeAssignment
    {
       [Key]
      public int LecturerId { get; set; }

        [StringLength(50)]

        [Display(Name = "Office Location")]

        public string Location { get; set; }
        public Lecturer Lecturer { get; set; }

    }
}