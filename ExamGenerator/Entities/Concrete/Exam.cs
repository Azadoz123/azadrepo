using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Exam: BaseEntity, IEntity
    {
        public Exam()
        {
            Questions = new List<Question>();
            Teachers = new List<Teacher>();
            StudentExams = new List<StudentExam>();
            StudentAnswers = new List<StudentAnswer>();
        }
        public string ExamName { get; set; }
        public List<Question> Questions { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<StudentExam> StudentExams { get; set; }
        public List<StudentAnswer> StudentAnswers { get; set; }
    }
}