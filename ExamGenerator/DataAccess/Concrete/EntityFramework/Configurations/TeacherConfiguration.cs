using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Teacher()
                {
                    Id = 1,
                    TeacherName = "Mehmet",
                    ExamId = 1
                },
                new Teacher()
                {
                    Id = 2,
                    TeacherName = "Ahmet",
                    ExamId = 1
                },
                new Teacher()
                {
                    Id = 3,
                    TeacherName = "Ayşe",
                    ExamId = 1
                },
                new Teacher()
                {
                    Id = 4,
                    TeacherName = "Ali",
                    ExamId = 2
                },
                new Teacher()
                {
                    Id = 5,
                    TeacherName = "Fatma",
                    ExamId = 2
                });
        }
    }
}
