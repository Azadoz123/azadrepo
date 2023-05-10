using Core.Data_Access.EntityFramework;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfQuestionDal : EfEntityRepositoryBase<Question>, IQuestionDal
    {
        private readonly ExamContext _context;
        public EfQuestionDal(ExamContext context) : base(context)
        {
            _context = context;
        }

      

        public List<Question> GetRandomlyQuestions(int examId, int easyQuestionNumber, int middleQuestionNumber, int hardQuestionNumber)
        {
            //_context.Set<Question>().Where(x=>x.DegreeOfDifficulty == 1);
            //GetList().Where(x=>x.DegreeOfDifficulty)
            //return  _context.Set<Question>().OrderBy(x=> Guid.NewGuid()).Take(3).ToList();
            //return _context.Set<Question>().Where(x=>x.DegreeOfDifficulty == 0).Where(x=>x.Id ==2).ToList();
                  //.Where(x => x.DegreeOfDifficulty ==1 || x.DegreeOfDifficulty == 2).Include(x => x.QuestionOptions).OrderBy(x => Guid.NewGuid()).Take(2).ToList();
           
            //.Select(x=>x.DegreeOfDifficulty ==0 ).ToList();
            //    Include(x=>x.QuestionOptions).OrderBy(x => Guid.NewGuid()).Take(1)
            //.Where(x => x.DegreeOfDifficulty == 1).Include(x => x.QuestionOptions).OrderBy(x=> Guid.NewGuid()).Take(1).ToList();
            //return db.photos.Where(x => x.userlogin == userlogin).OrderBy(x => Guid.NewGuid()).Take(10).ToList();

            var newQuestionList = new List<Question>();
           var easyQuestions =  _context.Set<Question>().Where(x=>x.ExamId == examId &&  x.DegreeOfDifficulty == DegreeOfDifficulty.Easy).Include(x => x.QuestionOptions).OrderBy(x => Guid.NewGuid()).Take(easyQuestionNumber).ToList();
           var middleQuestions =  _context.Set<Question>().Where(x => x.ExamId == examId &&  x.DegreeOfDifficulty == DegreeOfDifficulty.Middle).Include(x => x.QuestionOptions).OrderBy(x => Guid.NewGuid()).Take(middleQuestionNumber).ToList();
           var hardQuestions =  _context.Set<Question>().Where(x => x.ExamId == examId &&  x.DegreeOfDifficulty == DegreeOfDifficulty.Hard).Include(x => x.QuestionOptions).OrderBy(x => Guid.NewGuid()).Take(hardQuestionNumber).ToList();



            newQuestionList.AddRange(easyQuestions);
            newQuestionList.AddRange(middleQuestions);
            newQuestionList.AddRange(hardQuestions);
            return newQuestionList;
        }

    }
}
