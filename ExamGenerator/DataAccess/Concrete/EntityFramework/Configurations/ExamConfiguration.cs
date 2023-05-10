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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Exam()
                {
                    Id = 1,
                    ExamName = "Matematik",
                    
                    //Teacher = new Teacher()
                    //{
                    //    Id = 1,
                    //    TeacherName = "Mehmet"
                    //},
                    //Questions = new List<Question>()
                    //{
                    //    new Question()
                    //    {
                    //        Id=1,
                    //        QuestionContent="Adınız nedir",
                    //        DegreeOfDifficulty="Kolay",
                    //        QuestionOptions = new List<QuestionOption>
                    //        {
                    //            new QuestionOption()
                    //            {
                    //                Id=1,
                    //                QuestionOptionContent= "Ahmet",
                    //                ChoiceOption ='A',
                    //                ResponseStatus = true
                    //            }
                    //        }
                    //    }
                    //}
                },
                new Exam()
                {
                    Id =2,
                    ExamName = "Türkçe"
                });
        }
    }
}
