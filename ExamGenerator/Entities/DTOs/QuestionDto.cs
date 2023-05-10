using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class QuestionDto: IDto
    {
        public string QuestionContent { get; set; }
        public int DegreeOfDifficulty { get; set; }
        public int ExamId { get; set; }
        public List<QuestionOptionDto> QuestionOptions { get; set; }
    }
}
