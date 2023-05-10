using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentAnswerManager : IStudentAnswerService
    {
        private readonly IStudentAnswerDal _studentAnswerDal;
        private readonly IMapper _mapper;
        private readonly IAskedQuestionService _askedQuestionService;

        public StudentAnswerManager(IStudentAnswerDal studentAnswerDal, IMapper mapper, IAskedQuestionService askedQuestionService)
        {
            _studentAnswerDal = studentAnswerDal;
            _mapper = mapper;
            _askedQuestionService = askedQuestionService;
        }

        public StudentAnswer Add(StudentAnswer studentAnswer)
        {
            //var studentAnswer = _mapper.Map<StudentAnswer>(studentAnswerDto);
            _studentAnswerDal.Add(studentAnswer); 
            return studentAnswer;
        }

        public List<StudentAnswer> AddRange(List<StudentAnswer> studentAnswers)
        {
            //var studentAnswer = _mapper.Map<List<StudentAnswer>>(clientAnswerDtos);
            _studentAnswerDal.AddRange(studentAnswers);

            return studentAnswers;
        }

        public bool CheckIfAnswerTrue(int studentId, int examId, int questionNumber, char studentAnswerForQuestion)
        {
           if( _askedQuestionService.GetAskedQuestionTrueAnswerByExamIdAndQuestionNumber(examId, questionNumber).Equals(studentAnswerForQuestion) )
            {
                return true;
            }
           return false;
        }

        public StudentAnswer Get(UpdateAnswerDto updateAnswerDto)
        {
           return _studentAnswerDal.Get(x=>x.ExamId ==  updateAnswerDto.ExamId && x.StudentId == updateAnswerDto.StudentId && x.QuestionNumber == updateAnswerDto.QuestionNumber);
        }

        public List<StudentAnswer> GetAnsweredQuestionsByStudentIdAndExamId(int studentId, int examId)
        {
          return  _studentAnswerDal.GetAnsweredQuestionsByStudentIdAndExamId(studentId, examId);
        }

        public CustomResponseDto<string> Update(UpdateAnswerDto updateAnswerDto)
        {
             var studentAnswer = Get(updateAnswerDto);
            if(studentAnswer == null )
            {
                return CustomResponseDto<string>.Fail(404, Messages.NoSuchQuestionFound);
            }
            studentAnswer.StudentAnswerForQuestion = updateAnswerDto.StudentAnswerForQuestion;
            if(CheckIfAnswerTrue(updateAnswerDto.StudentId,updateAnswerDto.ExamId, updateAnswerDto.QuestionNumber, updateAnswerDto.StudentAnswerForQuestion))
            {
                studentAnswer.StatusOfTruht = true;
            }
            else
            {
                studentAnswer.StatusOfTruht = false;
            }

            _studentAnswerDal.Update(studentAnswer);

            return CustomResponseDto<string>.Success(200, Messages.YourAnswerIsUpdated);

        }
    }
}
