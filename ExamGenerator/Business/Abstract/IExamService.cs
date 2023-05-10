using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExamService
    {
        List<ExamDto> GetAll();
        List<ExamDto> GetAllExamWithQuestionAndQuestionOptionsAndTeacher();
        Exam AddExam(ExamAddDto examDto);
        void AddQuestionForTeacher(TeacherDto teacherDto, QuestionDto questionDto);
        string AnswerExam(AnswerDto answerDto);
        List<char> GetTrueAnswers(List<Exam> exams);
        //int ExamScore(AnswerDto answerDto);
        CustomResponseDto<NoContentDto> DeleteExam(int examName);
        void GetRandomlyExamQuestions(string examName);
    }
}
