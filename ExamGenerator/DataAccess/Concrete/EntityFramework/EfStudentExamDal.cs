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
    public class EfStudentExamDal : EfEntityRepositoryBase<StudentExam>, IStudentExamDal
    {
        private readonly DbContext _context;
        public EfStudentExamDal(ExamContext context) : base(context)
        {
        }

        public StudentExam GetStudentExamByStudentIdAndExamId(int studentId, int examId)
        {
           return Get(x=>x.StudentId == studentId && x.ExamId == examId);
        }
    }
}
