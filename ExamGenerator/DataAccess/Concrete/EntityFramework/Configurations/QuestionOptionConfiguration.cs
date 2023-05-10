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
    public class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new QuestionOption()
                {
                    Id = 1,
                    QuestionOptionContent = "2",
                    ChoiceOption = 'A',
                    ResponseStatus = true,
                    QuestionId = 1
                },
                new QuestionOption()
                {
                    Id= 2,
                    QuestionOptionContent = "4",
                    ChoiceOption = 'B',
                    ResponseStatus= false,
                    QuestionId = 1
                },
                new QuestionOption()
                {
                    Id=3,
                    QuestionOptionContent = "6",
                    ChoiceOption = 'C',
                    ResponseStatus= false,
                    QuestionId = 1
                },
                new QuestionOption()
                {
                    Id = 4,
                    QuestionOptionContent = "8",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId= 1
                }, 
                new QuestionOption()
                {
                    Id = 5,
                    QuestionOptionContent= "9",
                    ChoiceOption = 'A',
                    ResponseStatus= false,
                    QuestionId= 2
                },
                new QuestionOption()
                {
                    Id=6, 
                    QuestionOptionContent= "18",
                    ChoiceOption = 'B',
                    ResponseStatus= true,
                    QuestionId= 2
                },
                new QuestionOption()
                {
                    Id = 7,
                    QuestionOptionContent = "22",
                    ChoiceOption = 'C',
                    ResponseStatus= false,
                    QuestionId= 2
                },
                new QuestionOption()
                {
                    Id = 8,
                    QuestionOptionContent = "30",
                    ChoiceOption = 'D',
                    ResponseStatus= false,
                    QuestionId= 2
                },
                new QuestionOption()
                {
                    Id = 9,
                    QuestionOptionContent = "1",
                    ChoiceOption = 'A',
                    ResponseStatus = false,
                    QuestionId = 3
                },
                new QuestionOption()
                {
                    Id = 10,
                    QuestionOptionContent = "11",
                    ChoiceOption = 'B',
                    ResponseStatus = false,
                    QuestionId = 3
                },
                new QuestionOption()
                {
                    Id = 11,
                    QuestionOptionContent = "24",
                    ChoiceOption = 'C',
                    ResponseStatus = true,
                    QuestionId = 3
                },
                new QuestionOption()
                {
                    Id = 12,
                    QuestionOptionContent = "33",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId = 3
                },
                new QuestionOption()
                {
                    Id = 13,
                    QuestionOptionContent = "1",
                    ChoiceOption = 'A',
                    ResponseStatus = false,
                    QuestionId = 4
                },
                new QuestionOption()
                {
                    Id = 14,
                    QuestionOptionContent = "45",
                    ChoiceOption = 'B',
                    ResponseStatus = false,
                    QuestionId = 4
                },
                new QuestionOption()
                {
                    Id = 15,
                    QuestionOptionContent = "2,9",
                    ChoiceOption = 'C',
                    ResponseStatus = false,
                    QuestionId = 4
                },
                new QuestionOption()
                {
                    Id = 16,
                    QuestionOptionContent = "3,14",
                    ChoiceOption = 'D',
                    ResponseStatus = true,
                    QuestionId = 4
                },
                new QuestionOption()
                {
                    Id = 17,
                    QuestionOptionContent = "8",
                    ChoiceOption = 'A',
                    ResponseStatus = true,
                    QuestionId = 5
                },
                new QuestionOption()
                {
                    Id = 18,
                    QuestionOptionContent = "63",
                    ChoiceOption = 'B',
                    ResponseStatus = false,
                    QuestionId = 5
                },
                new QuestionOption()
                {
                    Id = 19,
                    QuestionOptionContent = "15",
                    ChoiceOption = 'C',
                    ResponseStatus = false,
                    QuestionId = 5
                },
                new QuestionOption()
                {
                    Id = 20,
                    QuestionOptionContent = "90",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId = 5
                },
                new QuestionOption()
                {
                    Id = 21,
                    QuestionOptionContent = "6",
                    ChoiceOption = 'A',
                    ResponseStatus = true,
                    QuestionId = 6
                },
                new QuestionOption()
                {
                    Id = 22,
                    QuestionOptionContent = "4",
                    ChoiceOption = 'B',
                    ResponseStatus = false,
                    QuestionId = 6
                },
                new QuestionOption()
                {
                    Id = 23,
                    QuestionOptionContent = "8",
                    ChoiceOption = 'C',
                    ResponseStatus = false,
                    QuestionId = 6
                },
                new QuestionOption()
                {
                    Id = 24,
                    QuestionOptionContent = "12",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId = 6
                },
                new QuestionOption()
                {
                    Id = 25,
                    QuestionOptionContent = "A",
                    ChoiceOption = 'A',
                    ResponseStatus = false,
                    QuestionId = 7
                },
                new QuestionOption()
                {
                    Id = 26,
                    QuestionOptionContent = "K",
                    ChoiceOption = 'B',
                    ResponseStatus = false,
                    QuestionId = 7
                },
                new QuestionOption()
                {
                    Id = 27,
                    QuestionOptionContent = "X",
                    ChoiceOption = 'C',
                    ResponseStatus = true,
                    QuestionId = 7
                },
                new QuestionOption()
                {
                    Id = 28,
                    QuestionOptionContent = "Z",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId = 7
                },
                new QuestionOption()
                {
                    Id = 29,
                    QuestionOptionContent = "B-Ş",
                    ChoiceOption = 'A',
                    ResponseStatus = false,
                    QuestionId = 8
                },
                new QuestionOption()
                {
                    Id = 30,
                    QuestionOptionContent = "A-Z",
                    ChoiceOption = 'B',
                    ResponseStatus = true,
                    QuestionId = 8
                },
                new QuestionOption()
                {
                    Id = 31,
                    QuestionOptionContent = "D-P",
                    ChoiceOption = 'C',
                    ResponseStatus = false,
                    QuestionId = 8
                },
                new QuestionOption()
                {
                    Id = 32,
                    QuestionOptionContent = "B-Ö",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId = 8
                },
                new QuestionOption()
                {
                    Id = 33,
                    QuestionOptionContent = "a , ı , o , u",
                    ChoiceOption = 'A',
                    ResponseStatus = true,
                    QuestionId = 9
                },
                new QuestionOption()
                {
                    Id = 34,
                    QuestionOptionContent = "e , i , ö , ü",
                    ChoiceOption = 'B',
                    ResponseStatus = false,
                    QuestionId = 9
                },
                new QuestionOption()
                {
                    Id = 35,
                    QuestionOptionContent = "a , e , ı , i",
                    ChoiceOption = 'C',
                    ResponseStatus = false,
                    QuestionId = 9
                },
                new QuestionOption()
                {
                    Id = 36,
                    QuestionOptionContent = "o , e , ü , i",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId = 9
                },
                new QuestionOption()
                {
                    Id = 37,
                    QuestionOptionContent = "1",
                    ChoiceOption = 'A',
                    ResponseStatus = false,
                    QuestionId = 10
                },
                new QuestionOption()
                {
                    Id = 38,
                    QuestionOptionContent = "2",
                    ChoiceOption = 'B',
                    ResponseStatus = false,
                    QuestionId = 10
                },
                new QuestionOption()
                {
                    Id = 39,
                    QuestionOptionContent = "3",
                    ChoiceOption = 'C',
                    ResponseStatus = true,
                    QuestionId = 10
                },
                new QuestionOption()
                {
                    Id = 40,
                    QuestionOptionContent = "4",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId = 10
                },
                new QuestionOption()
                {
                    Id = 41,
                    QuestionOptionContent = "YAT",
                    ChoiceOption = 'A',
                    ResponseStatus = true,
                    QuestionId = 11
                },
                new QuestionOption()
                {
                    Id = 42,
                    QuestionOptionContent = "ARABA",
                    ChoiceOption = 'B',
                    ResponseStatus = false,
                    QuestionId = 11
                },
                new QuestionOption()
                {
                    Id = 43,
                    QuestionOptionContent = "UÇAK",
                    ChoiceOption = 'C',
                    ResponseStatus = false,
                    QuestionId = 11
                },
                new QuestionOption()
                {
                    Id = 44,
                    QuestionOptionContent = "OTOBÜS",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId = 11
                },
                new QuestionOption()
                {
                    Id = 45,
                    QuestionOptionContent = "SARI",
                    ChoiceOption = 'A',
                    ResponseStatus = true,
                    QuestionId = 12
                },
                new QuestionOption()
                {
                    Id = 46,
                    QuestionOptionContent = "SAKSI",
                    ChoiceOption = 'B',
                    ResponseStatus = false,
                    QuestionId = 12
                },
                new QuestionOption()
                {
                    Id = 47,
                    QuestionOptionContent = "SABUN",
                    ChoiceOption = 'C',
                    ResponseStatus = false,
                    QuestionId = 12
                },
                new QuestionOption()
                {
                    Id = 48,
                    QuestionOptionContent = "SAKIZ",
                    ChoiceOption = 'D',
                    ResponseStatus = false,
                    QuestionId = 12
                });
        }
    }
}
