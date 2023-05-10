using DataAccess.Concrete.EntityFramework.Configurations;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ExamContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ExamDb; Trusted_Connection=true");
        }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AskedQuestion> AskedQuestions { get; set; }
        public DbSet<AskedQuestionOption> AskedQuestionOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Exam>().HasOne(x => x.Teacher).WithOne(x => x.Exam).HasForeignKey<Teacher>(x => x.ExamId);
            //modelBuilder.Entity<Exam>().HasMany(x => x.Teachers).WithOne(x => x.Exam).HasForeignKey(x => x.ExamId);
            modelBuilder.Entity<Exam>().HasMany(x => x.Questions).WithOne(x => x.Exam).HasForeignKey(x=>x.ExamId);
            modelBuilder.Entity<Exam>().HasMany(x=>x.StudentAnswers).WithOne(x => x.Exam).HasForeignKey(x=>x.ExamId).OnDelete(DeleteBehavior.Restrict);
        //    modelBuilder.Entity<Exam>().HasMany(x => x.StudentExams).WithOne(x => x.Exam).HasForeignKey(x => x.ExamId);
            //modelBuilder.Entity<Student>().HasMany(x=>x.StudentExams).WithOne(x=>x.Student).HasForeignKey(x=>x.StudentId);
            modelBuilder.Entity<Student>().HasMany(x=>x.StudentAnswers).WithOne(x=>x.Student).HasForeignKey(x=>x.StudentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Question>().HasMany(x => x.QuestionOptions).WithOne(x => x.Question).HasForeignKey(x => x.QuestionId);
            //modelBuilder.Entity<StudentAnswer>().HasOne(x=>x.AskedQuestion).WithMany().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<StudentAnswer>().HasOne(x=>x.Exam).WithMany().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<StudentAnswer>().HasOne(x=>x.Student).WithMany().OnDelete(DeleteBehavior.Cascade);
            
            //modelBuilder.Entity<AskedQuestion>().HasMany(x=>x.StudentAnswers).WithOne(x=>x.AskedQuestion).HasForeignKey(x=>x.AskedQuestionId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.ApplyConfiguration(new ExamConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<StudenttExam>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
