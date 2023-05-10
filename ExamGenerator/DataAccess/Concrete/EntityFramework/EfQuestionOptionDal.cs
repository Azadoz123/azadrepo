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
    public class EfQuestionOptionDal : EfEntityRepositoryBase<QuestionOption>, IQuestionOptionDal
    {
        private readonly ExamContext _context;
        public EfQuestionOptionDal(ExamContext context) : base(context)
        {
            _context = context;
        }
    }
}
