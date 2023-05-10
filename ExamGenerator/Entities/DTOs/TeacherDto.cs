using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TeacherDto: IDto
    {
        public string TeacherName { get; set; }
        public int ExamId { get; set; }
    }
}
