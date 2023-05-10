using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ExamDto
    {
        public string ExamName { get; set; }
        public List<TeacherDto> Teachers { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
