using Core.Data_Access;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAskedQuestionDal: IEntityRepository<AskedQuestion>
    {
        List<AskedQuestion> AddRange(List<AskedQuestion> askedQuestions);
        AskedQuestion GetAskedQuestionWithAskedQuestionOption(int examId, int questionNumber);
    }
}
