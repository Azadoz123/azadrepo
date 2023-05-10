using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UpdateAnswerDto
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }    
        public int QuestionNumber { get; set; }
        public char StudentAnswerForQuestion { get; set; }
    }
}
