using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Luya123.Models
{
    public class Lecturer
    {
       
        public int ID { get; set; }

        [Required]
        [Display(Name = "Surname")]
        [StringLength(50)]
        


        public string Surname { get; set; }


        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]

        public String FirstMidname{ get; set; }



        [Required]
        [Column("Emailaddress")]
        [Display(Name = "Email address")]
        [StringLength(50)]

        public String Emailaddress { get; set; }



        [Required]
        [Column("Degree")]
        [Display(Name = "Degree")]
        [StringLength(50)]

        public String Degree { get; set; }




        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]

        public DateTime Dateofbirth { get; set; }

       [Display(Name ="Full Name")]


        public String FullName
        {
            get { return Surname + ", " + FirstMidname; }
        }


        public ICollection<Coursetaught> Coursetaughts { set; get; }
        public OfficeAssignment OfficeAssignment { set; get; }

    }
}
