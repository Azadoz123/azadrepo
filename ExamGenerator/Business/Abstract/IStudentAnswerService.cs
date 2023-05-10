using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentAnswerService
    {
        StudentAnswer Add(StudentAnswer studentAnswer);
        List<StudentAnswer> AddRange(List<StudentAnswer> studentAnswers);
        List<StudentAnswer> GetAnsweredQuestionsByStudentIdAndExamId(int studentId, int examId);
        StudentAnswer Get(UpdateAnswerDto updateAnswerDto);
        CustomResponseDto<string> Update(UpdateAnswerDto updateAnswerDto);
        bool CheckIfAnswerTrue(int  studentId, int examId, int questionNumber, char studentAnswerForQuestion);
    }
}
