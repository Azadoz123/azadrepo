using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ExamAndTeacherAddDto:  IDto
    {
        public string ExamName { get; set; }
       public Teacher Teacher { get; set; }

        //public ExamAddWithTeacherInfoDto examAddWithTeacherInfoDto { get; set; }
        //public ExamAddWithQuestionInfoDto examAddWithQuestionInfoDto { get; set; }
        //public ExamAddWithQuestionOptionDto examAddWithQuestionOptionDto { get; set; }
    }
}
