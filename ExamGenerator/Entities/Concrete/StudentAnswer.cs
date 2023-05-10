using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StudentAnswer:BaseEntity , IEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        //public int AskedQuestionId { get; set; }
        //public AskedQuestion AskedQuestion { get; set; }
        public int QuestionNumber { get; set; }
        public char StudentAnswerForQuestion { get; set; }
        public bool StatusOfTruht { get; set; }
    }
}
