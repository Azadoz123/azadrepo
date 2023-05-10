using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Student : BaseEntity, IEntity
    {
        public Student()
        {
            StudentExams = new List<StudentExam>();
            StudentAnswers = new List<StudentAnswer>();
        }
        public string studentName { get; set; }
        public List<StudentExam> StudentExams { get; set; }
        public List<StudentAnswer> StudentAnswers { get; set; }
    }
}
