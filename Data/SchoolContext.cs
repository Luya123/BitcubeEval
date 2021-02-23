using Luya123.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luya123.Data
{
    public class SchoolContext : DbContext
    {

        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
            {
            }
        public DbSet <Course> Courses { get; set; }
        public DbSet <Enrollment> Enrollments { get; set; }
        public DbSet <Student> Students { get; set; }


        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Coursetaught> Coursetaught { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Cursos");
            modelBuilder.Entity<Enrollment>().ToTable("Inscriptiones");
            modelBuilder.Entity<Student>().ToTable("Estudiantes");

            modelBuilder.Entity<Degree>().ToTable("Departamentos");
            modelBuilder.Entity<Lecturer>().ToTable("Lecturers");
            modelBuilder.Entity<OfficeAssignment>().ToTable("AsignacionesDeOficina");
            modelBuilder.Entity<Coursetaught>().ToTable("AsignacionesDeCurse");

            modelBuilder.Entity<Coursetaught>()
                .HasKey(c => new { c.CourseId, c.LecturerId });

        }
    }

}


