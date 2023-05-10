using Core.Data_Access.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAskedQuestionDal : EfEntityRepositoryBase<AskedQuestion>, IAskedQuestionDal
    {
        private readonly DbContext _context;
        public EfAskedQuestionDal(ExamContext context) : base(context)
        {
            _context = context;
        }

        public List<AskedQuestion> AddRange(List<AskedQuestion> askedQuestions)
        {
            _context.Set<AskedQuestion>().AddRange(askedQuestions);
            //foreach (var question in askedQuestions)
            //{
            //    _context.Set<AskedQuestion>().Add(question);
            //}

            //return questions;
            _context.SaveChanges();
            return askedQuestions;
        }

        public AskedQuestion GetAskedQuestionWithAskedQuestionOption(int examId, int questionNumber)
        {
           return _context.Set<AskedQuestion>().Include(x => x.QuestionOptions).FirstOrDefault(x => x.QuestionNumber == questionNumber && x.ExamId == examId);
        }
    }
}
