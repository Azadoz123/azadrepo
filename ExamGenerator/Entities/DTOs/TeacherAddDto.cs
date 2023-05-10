using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TeacherAddDto
    {
        public TeacherDto teacherDto { get; set; }
        public QuestionDto questionDto { get; set; }
    }
}
