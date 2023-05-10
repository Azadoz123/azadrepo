using Core.Data_Access.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStudentAnswerDal : EfEntityRepositoryBase<StudentAnswer>, IStudentAnswerDal
    {
        private readonly DbContext _context;
        public EfStudentAnswerDal(ExamContext context) : base(context)
        {
            _context = context;
        }

        public List<StudentAnswer> AddRange(List<StudentAnswer> studentAnswer)
        {
            _context.Set<StudentAnswer>().AddRange(studentAnswer);
            _context.SaveChanges();
            return studentAnswer;
        }

        public List<StudentAnswer> GetAnsweredQuestionsByStudentIdAndExamId(int studentId, int examId)
        {
           return GetList(x=>x.StudentId == studentId && x.ExamId ==  examId).ToList();
        }
    }
}
