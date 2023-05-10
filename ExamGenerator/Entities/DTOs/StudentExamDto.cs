using Entities.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class StudentExamDto
    {
        public StatusOfExam StatusOfExam { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
    }
}
