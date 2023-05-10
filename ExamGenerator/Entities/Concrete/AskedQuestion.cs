using Core.Entities.Abstract;
using Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AskedQuestion: BaseEntity, IEntity
    {
        public AskedQuestion()
        {
            QuestionOptions = new List<AskedQuestionOption>();
            //StudentAnswers = new List<StudentAnswer>();
        }
        public int QuestionNumber { get; set; }
        public string QuestionContent { get; set; }
        public DegreeOfDifficulty DegreeOfDifficulty { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public List<AskedQuestionOption> QuestionOptions { get; set; }
        //public List<StudentAnswer> StudentAnswers { get; set; }
    }
}
