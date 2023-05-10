using Entities.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AskedQuestionDto
    {
        public int QuestionNumber { get; set; }
        public string QuestionContent { get; set; }
        public DegreeOfDifficulty DegreeOfDifficulty { get; set; }
        public int ExamId { get; set; }
        public List<AskedQuestionOptionDto> QuestionOptions { get; set; }
        //public List<StudentAnswerDto> StudentAnswers { get; set; }
    }
}
