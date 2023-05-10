using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ExamAddDto: IDto
    {
        public string ExamName { get; set; }
        //public List<TeacherDto> TeacherDtos { get; set; }
        public List<TeacherDto> Teachers { get; set; }
        //public List<QuestionDto> QuestionDtos { get; set; }
        public List<QuestionDto> Questions { get; set; }
        //public int ExamId { get; set; }
        //public int TeacherId { get; set; }
        //public int QuestionId { get; set; }
        //public int QuestionOptionId { get; set; }
    }
}
