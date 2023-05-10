

using Entities.ComplexTypes;
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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x=> x.QuestionOptions).

            builder.HasData(
                new Question
                {
                    Id = 1,
                    QuestionContent = "Aşağıdakilerden hangisi asal sayıdır?",
                    DegreeOfDifficulty = DegreeOfDifficulty.Easy,
                    //DegreeOfDifficulty = (int)Difficulty.Easy,
                    ExamId = 1        
                },
                new Question()
                {
                    Id= 2,
                    QuestionContent = "3x6 işleminin sonucu kaçtır",
                    DegreeOfDifficulty= DegreeOfDifficulty.Easy,
                    //DegreeOfDifficulty= (int)Difficulty.Easy,
                    ExamId = 1
                },
                new Question()
                {
                    Id = 3,
                    QuestionContent = "Aşağıdakilerden hangisi çift sayıdır",
                    DegreeOfDifficulty = DegreeOfDifficulty.Middle,
                    //DegreeOfDifficulty = (int)Difficulty.Middle,
                    ExamId = 1
                },
                new Question()
                {
                    Id = 4,
                    QuestionContent = "Pi sayısı kaçtır?",
                    //DegreeOfDifficulty = (int)DegreeOfDifficulty.Middle,
                    DegreeOfDifficulty = DegreeOfDifficulty.Middle,
                    ExamId = 1
                },
                new Question()
                {
                    Id = 5,
                    QuestionContent = "Aşağıdakilerden hangisi 3'e bölünmez?",
                    //DegreeOfDifficulty = (int)DegreeOfDifficulty.Hard,
                    DegreeOfDifficulty = DegreeOfDifficulty.Hard,
                    ExamId = 1
                },
                new Question()
                {
                    Id = 6,
                    QuestionContent = "Aşağıdakilerden hangisi 4'e bölünmez?",
                    //DegreeOfDifficulty = (int)DegreeOfDifficulty.Hard,
                    DegreeOfDifficulty = DegreeOfDifficulty.Hard,
                    ExamId = 1
                },
                new Question
                {
                    Id = 7,
                    QuestionContent = "Aşağıdaki harflerden hangisi alfabemizde yer almaz?",
                    DegreeOfDifficulty = DegreeOfDifficulty.Easy,
                    //DegreeOfDifficulty = (int)Difficulty.Easy,
                    ExamId = 2
                },
                new Question()
                {
                    Id = 8,
                    QuestionContent = "Aşağıdakilerden hangisinde alfabemizin ilk ve son harfi verilmiştir?",
                    DegreeOfDifficulty = DegreeOfDifficulty.Easy,
                    //DegreeOfDifficulty= (int)Difficulty.Easy,
                    ExamId = 2
                },
                new Question()
                {
                    Id = 9,
                    QuestionContent = "Aşağıdakilerden hangisinde kalın ünlü harfler verilmiştir ?",
                    DegreeOfDifficulty = DegreeOfDifficulty.Middle,
                    //DegreeOfDifficulty = (int)Difficulty.Middle,
                    ExamId = 2
                },
                new Question()
                {
                    Id = 10,
                    QuestionContent = "' Kitap okumayı seviyorum. ' cümlesi kaç kelimeden oluşmuştur ?",
                    //DegreeOfDifficulty = (int)DegreeOfDifficulty.Middle,
                    DegreeOfDifficulty = DegreeOfDifficulty.Middle,
                    ExamId = 2
                },
                new Question()
                {
                    Id = 11,
                    QuestionContent = "Aşağıdakilerden hangisi tek hecelidir ?",
                    //DegreeOfDifficulty = (int)DegreeOfDifficulty.Hard,
                    DegreeOfDifficulty = DegreeOfDifficulty.Hard,
                    ExamId = 2
                },
                new Question()
                {
                    Id = 12,
                    QuestionContent = "Aşağıda verilen kelimelerden hangisinin harf sayısı diğerlerinden daha azdır ? ",
                    //DegreeOfDifficulty = (int)DegreeOfDifficulty.Hard,
                    DegreeOfDifficulty = DegreeOfDifficulty.Hard,
                    ExamId = 2
                });
        }
    }
}
