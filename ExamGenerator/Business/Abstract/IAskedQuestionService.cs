using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAskedQuestionService
    {
        AskedQuestion Add(AskedQuestion askedQuestion);
        List<AskedQuestion> AddRange(List<AskedQuestionDto> askedQuestions);
        List<AskedQuestion> GetQuestionByExamId(int examId);
        char GetAskedQuestionTrueAnswerByExamIdAndQuestionNumber(int examId, int questionNumber);
    }
}
