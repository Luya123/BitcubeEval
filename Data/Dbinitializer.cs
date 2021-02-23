
using System;
using Luya123.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luya123.Data
{
    public static class Dbinitializer
    {
        public static void Initialize(SchoolContext context) {
            context.Database.EnsureCreated();

            if (context.Students.Any()) 
            {
                return;
            }

            var students = new Student[]
                {
                new Student{ FirstMidName="Luyanda", LastName="Mthalane", EmailAddress = "Mthalaneluyanda@gmail.com", DateOfBirth=DateTime.Parse("1999-06-08") },
                new Student{ FirstMidName="Carman", LastName="Green", EmailAddress = "CarmanGreen@gmail.com", DateOfBirth=DateTime.Parse("1998-06-08") },
                new Student{ FirstMidName="Jack", LastName="Shezi",  EmailAddress = "Jack@gmail.com", DateOfBirth=DateTime.Parse("1995-06-08") },
                new Student{ FirstMidName="Jill", LastName="Khoza",  EmailAddress = "JillKhoza@gmail.com", DateOfBirth=DateTime.Parse("1992-06-08") },
                };

                foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();


            //Lecturer
            var lecturers = new Lecturer[]
            { 
                new Lecturer{ FirstMidname="Thabani", Surname="Mkhize", Emailaddress = "Thabani@gmail.com",Degree="Visual Basic", Dateofbirth=DateTime.Parse("1992-06-08")},
               new Lecturer{ FirstMidname="Kwanele", Surname="Ngcobo", Emailaddress = "KwaneleNgcobo@gmail.com", Degree="System Software", Dateofbirth=DateTime.Parse("1992-06-08")},
               new Lecturer{ FirstMidname="Neliswa", Surname="Smith", Emailaddress = "NeliswaSmith@gmail.com" ,Degree="Information System",Dateofbirth=DateTime.Parse("1992-06-08")},

            };


            foreach (Lecturer lecturer in lecturers)
            {
                context.Lecturers.Add(lecturer);
            }
            context.SaveChanges();

            //Department
            var degrees = new Degree[]
            {
                new Degree { Name = "Programming", Budget = 1300, StartDate = DateTime.Parse("1992-06-08"),
            LecturerId = lecturers.Single(i=> i.Surname == "Mkhize").ID}
            };

            foreach (Degree degree in degrees)
            {
                context.Degrees.Add(degree);
            }
            context.SaveChanges();

            //COURSE
            var courses = new Course[]
                     {
                        new Course{CourseId=111, Title="C++", Credits=3,},  
                        new Course{CourseId=111, Title="C++", Credits=3,},   
                        new Course{CourseId=222, Title="C++102", Credits=7},
                        new Course{CourseId=333, Title="VB.Net", Credits=8},
                        new Course{CourseId=444, Title="VB.Net", Credits=22},
                    };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            //officeAssignment

            var officeAssignments = new OfficeAssignment[]
            {

                    new OfficeAssignment{LecturerId=lecturers.Single(i=>i.Surname=="Mthalane").ID, Location = "PMB"},
                    new OfficeAssignment{LecturerId=lecturers.Single(i=>i.Surname=="Ngcobo").ID, Location = "Dbn"},

            };
            foreach (OfficeAssignment oa in officeAssignments)
            {
                context.OfficeAssignments.Add(oa);
            }
            context.SaveChanges();



            var enrollments = new Enrollment[]
               {
                 //new Enrollment{ StudentId=students.Single(s=>s.LastName=="Green").Id,CourseId=courses.Single(c=>c.Title=="C++").CourseId,Grade=Grade.C }, 



                 new Enrollment{StudentId=1, CourseId=111, Grade=Grade.A},
                 new Enrollment{StudentId=1, CourseId=111, Grade=Grade.A},
                 new Enrollment{StudentId=1, CourseId=444, Grade=Grade.B},

                 new Enrollment{StudentId=2, CourseId=222, Grade=Grade.B},
                 new Enrollment{StudentId=2, CourseId=222, Grade=Grade.C},

                 new Enrollment{StudentId=3, CourseId=333 }, 
                 new Enrollment{StudentId=3, CourseId=333, Grade=Grade.A},



               };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                    s.StudentId == e.StudentId &&
                    s.Course.CourseId == e.CourseId).SingleOrDefault();

                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
               
            }
            context.SaveChanges();

        }
    }
}
