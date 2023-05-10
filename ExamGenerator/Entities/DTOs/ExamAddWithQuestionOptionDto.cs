using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ExamAddWithQuestionOptionDto
    {
        public List<string> QuestionOptionContent { get; set; }
        public char Answer { get; set; }
    }
}
