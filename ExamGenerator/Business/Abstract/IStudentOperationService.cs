using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentOperationService
    {
        List<AskedQuestionForClientDto> TakeExam(int examId);
        CustomResponseDto<List<StudentAnswer>> AnswerExam(ClientAnswerDto clientAnswerDto);
        CustomResponseDto<string> GetExamResult(ExamAndStudentDto examAndStudentDto);
        CustomResponseDto<AskedQuestionForClientDto> TakeExamByGetOnlyOneQuestion(int examId, int studentId);
    }
}
