using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ComplexTypes;

namespace Entities.Concrete
{
    public class Question: BaseEntity, IEntity
    {
        public Question()
        {
            QuestionOptions = new List<QuestionOption>();
            //StudentAnswers = new List<StudentAnswer>();
        }
        public string QuestionContent { get; set; }   
        public DegreeOfDifficulty DegreeOfDifficulty { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public List<QuestionOption> QuestionOptions { get; set; }
        //public List<StudentAnswer> StudentAnswers { get; set; }
    }
}
