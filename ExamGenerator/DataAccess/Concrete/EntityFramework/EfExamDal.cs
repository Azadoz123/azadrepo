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
    public class EfExamDal : EfEntityRepositoryBase<Exam>, IExamDal
    {
        private readonly ExamContext _context;
        public EfExamDal(ExamContext context) : base(context)
        {
            _context = context;
        }

        public List<Exam> GetAllExamWithQuestionAndQuestionOptionsAndTeacher()
        {
          return  _context.Exams.Include(x=>x.Questions).ThenInclude(x=>x.QuestionOptions).Include(x=>x.Teachers).ToList();
        }
    }
}
