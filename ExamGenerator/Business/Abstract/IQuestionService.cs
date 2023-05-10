using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        
        Question Add(QuestionDto questionDto);
        List<Question> AddRange(IEnumerable<QuestionDto> questionDtos);
        List<Question> GetRandomlyQuestions(int examId, int easyQuestionNumber, int middleQuestionNumber, int hardQuestionNumber);
        string AnswerExam(AnswerDto answerDto);
        CustomResponseDto<NoContentDto> DeleteQuestion(int questionId);
        Question GetQuestionByQuestionContentAndExamId(string questionContent, int examId);
    }
}
