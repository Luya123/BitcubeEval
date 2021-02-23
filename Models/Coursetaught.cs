namespace Luya123.Models
{
    public class Coursetaught
    {
        public int LecturerId { get; set; }

        public int CourseId { get; set; }
        public Lecturer Lecturer { get; set; }

        public Course Course { get; set; }
    }
}