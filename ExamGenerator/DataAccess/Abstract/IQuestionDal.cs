using Core.Data_Access;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IQuestionDal: IEntityRepository<Question>
    {
        List<Question> GetRandomlyQuestions(int examId, int easyQuestionNumber, int middleQuestionNumber, int hardQuestionNumber);
        //Question GetQuestionByQuestionContentAndExamId(string questionContent, int examId);

    }
}
