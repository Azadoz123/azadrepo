using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.ComplexTypes;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentOperationManager : IStudentOperationService
    {
        private readonly IAskedQuestionService _askedQuestionService;
        private readonly IMapper _mapper;
        private readonly IStudentAnswerService _studentAnswerService;
        private readonly IStudentExamService _studentExamService;
        public StudentOperationManager(IAskedQuestionService askedQuestionService, IMapper mapper, IStudentAnswerService studentAnswerService, IStudentExamService studentExamService)
        {
            _askedQuestionService = askedQuestionService;
            _mapper = mapper;
            _studentAnswerService = studentAnswerService;
            _studentExamService = studentExamService;
        }

        public CustomResponseDto<List<StudentAnswer>> AnswerExam(ClientAnswerDto clientAnswerDto)
        {
            List<StudentAnswerDto> answerList = new List<StudentAnswerDto>();
            char trueAnswer = 'A';
            var askedQuestions = _askedQuestionService.GetQuestionByExamId(clientAnswerDto.examId);
            if(askedQuestions.Count() == 0)
            {
               return  CustomResponseDto<List<StudentAnswer>>.Fail(404, Messages.ExamIsNotFound);
            }
            var AskedQuestionId = askedQuestions[0].Id;
            //var AskedQuestionId = answerList[0].AskedQuestionId;

             var answeredQuestions = _studentAnswerService.GetAnsweredQuestionsByStudentIdAndExamId(clientAnswerDto.StudentId, clientAnswerDto.examId);
            if (askedQuestions.Count() > answeredQuestions.Count())
            {
                //var remainingQuestions = askedQuestions.Count() - answeredQuestions.Count();
                //for (int i = 0; i < clientAnswerDto.charArr.Length; i++)
                //{
                //for (int i = answeredQuestions.Count(); i < askedQuestions.Count(); i++)
                for (int i = answeredQuestions.Count(); i < answeredQuestions.Count() + clientAnswerDto.charArr.Length; i++)
                {
                    if (askedQuestions.Count() != i)
                    {
                        var studentAnswerDto = new StudentAnswerDto()
                        {
                            ExamId = clientAnswerDto.examId,
                            StudentId = clientAnswerDto.StudentId,
                            //AskedQuestionId = askedQuestions[i].Id,
                            QuestionNumber = askedQuestions[i].QuestionNumber,
                            StudentAnswerForQuestion = clientAnswerDto.charArr[i - answeredQuestions.Count()],

                        };

                        foreach (var questionOption in askedQuestions[i].QuestionOptions)
                        {
                            if (questionOption.ResponseStatus == true)
                            {
                                trueAnswer = questionOption.ChoiceOption;
                            }
                        }
                        if (studentAnswerDto.StudentAnswerForQuestion == trueAnswer)
                        {
                            studentAnswerDto.StatusOfTruht = true;
                        }
                        else
                        {
                            studentAnswerDto.StatusOfTruht = false;
                        }
                        answerList.Add(studentAnswerDto);
                    }
                }



                var studentAnswer = _mapper.Map<List<StudentAnswer>>(answerList);
                _studentAnswerService.AddRange(studentAnswer);

                answeredQuestions = _studentAnswerService.GetAnsweredQuestionsByStudentIdAndExamId(clientAnswerDto.StudentId, clientAnswerDto.examId);

                var studentExam = _studentExamService.GetStudentExamByStudentIdAndExamId(clientAnswerDto.StudentId, clientAnswerDto.examId);

                if (studentExam == null)
                {
                    var studentExamDto = new StudentExamDto()
                    {
                        ExamId = clientAnswerDto.examId,
                        StudentId = clientAnswerDto.StudentId
                    };

                    if (askedQuestions.Count() == answeredQuestions.Count())
                    {
                        studentExamDto.StatusOfExam = StatusOfExam.Completed;
                    }
                    else
                    {
                        studentExamDto.StatusOfExam = StatusOfExam.NotCompleted;
                    }
                    _studentExamService.Add(studentExamDto);
                }
                else
                {
                    if (askedQuestions.Count() == answeredQuestions.Count())
                    {
                        studentExam.StatusOfExam = StatusOfExam.Completed;
                    }
                    else
                    {
                        studentExam.StatusOfExam = StatusOfExam.NotCompleted;
                    }

                    _studentExamService.Update(studentExam);
                }

                //return studentAnswer;
                return CustomResponseDto<List<StudentAnswer>>.Success(201, studentAnswer);
            }

            return CustomResponseDto<List<StudentAnswer>>.Fail(400, Messages.ExamIsCompleted);
            //return null;
        }
                
           

        public List<AskedQuestionForClientDto> TakeExam(int examId)
        {
            var askedQuestions = _askedQuestionService.GetQuestionByExamId(examId);
            var askedQuestionForClientDto = _mapper.Map<List<AskedQuestionForClientDto>>(askedQuestions);

            return askedQuestionForClientDto;
        }

        public CustomResponseDto<AskedQuestionForClientDto> TakeExamByGetOnlyOneQuestion(int examId, int studentId)
        {
            var askedQuestions = _askedQuestionService.GetQuestionByExamId(examId);
            if (askedQuestions.Count() == 0)
            {
                return CustomResponseDto<AskedQuestionForClientDto>.Fail(404, Messages.ExamIsNotAvailable);
            }
            var answeredQuestions = _studentAnswerService.GetAnsweredQuestionsByStudentIdAndExamId(studentId, examId);

            if(askedQuestions.Count() != answeredQuestions.Count())
            {
                var nextQuestion = askedQuestions[answeredQuestions.Count()];
                var result = _mapper.Map<AskedQuestionForClientDto>(nextQuestion);
                return CustomResponseDto<AskedQuestionForClientDto>.Success(200, result);
            }
            //return null;
            return CustomResponseDto<AskedQuestionForClientDto>.Fail(400, Messages.ExamIsCompleted);
        }
        public CustomResponseDto<string> GetExamResult(ExamAndStudentDto examAndStudentDto)
        {
            var trueAnswerNumber = 0;
            var falseAnswerNumber = 0;
            var askedQuestions = _askedQuestionService.GetQuestionByExamId(examAndStudentDto.ExamId);
            if(askedQuestions.Count() == 0)
            {
                return CustomResponseDto<string>.Fail(404, Messages.ExamIsNotAvailable);
            }
            var answeredQuestions = _studentAnswerService.GetAnsweredQuestionsByStudentIdAndExamId(examAndStudentDto.StudentId, examAndStudentDto.ExamId);
            if(askedQuestions.Count() == answeredQuestions.Count())
            {
                foreach (var question in answeredQuestions)
                {
                   if( question.StatusOfTruht == true)
                        trueAnswerNumber++;
                   else 
                        falseAnswerNumber++;

                }
                return  CustomResponseDto<string>.Success(200,"Doğru Cevap Sayınız : " + trueAnswerNumber + " Yanlış Cevap Sayınız : " + falseAnswerNumber);
            }

            return CustomResponseDto<string>.Fail(404, Messages.ExamIsNotCompletedByStudent);
            
        }
    }
}
