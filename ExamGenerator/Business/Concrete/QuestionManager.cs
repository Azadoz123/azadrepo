using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;
        private readonly IMapper _mapper;
        private readonly IExamDal _examDal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public QuestionManager(IQuestionDal questionDal, IMapper mapper, IExamDal examDal, IHttpContextAccessor httpContextAccessor)
        {
            _questionDal = questionDal;
            _mapper = mapper;
            _examDal = examDal;
            _httpContextAccessor = httpContextAccessor;
        }

        public Question Add(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            _questionDal.Add(question);
            return question;
        }

        public List<Question> AddRange(IEnumerable<QuestionDto> questionDtos)
        {
            var questions = _mapper.Map<List<Question>>(questionDtos);
            foreach (var question in questions)
            {
                _questionDal.Add(question);
            }

            return questions;
        }

        public List<Question> GetRandomlyQuestions(int examId, int easyQuestionNumber, int middleQuestionNumber, int hardQuestionNumber)
        {
            //var exams = _examDal.GetAllExamWithQuestionAndQuestionOptionsAndTeacher().ToList();
            //var trueAnswers = GetTrueAnswers(exams);
            //var newString = new string(trueAnswers.ToArray());
            //_httpContextAccessor.HttpContext.Session.SetString("key", newString);
            //var result = _mapper.Map<List<ExamDto>>(exams);
            //return result;

            var exam = _examDal.Get(x => x.Id == examId);
            var questions = _questionDal.GetRandomlyQuestions(exam.Id, easyQuestionNumber, middleQuestionNumber, hardQuestionNumber);
            var trueAnswers = GetTrueAnswersForQuestions(questions);
            var newString = new string(trueAnswers.ToArray());
            _httpContextAccessor.HttpContext.Session.SetString("key", newString);
            //var questionDtos = _mapper.Map<List<QuestionDto>>(questions);
            //return questionDtos;
            return questions;
        }
        public List<char> GetTrueAnswersForQuestions(List<Question> questions)
        {
            List<char> result = new List<char>();

            foreach (var question in questions)
            {
                foreach (var questionOption in question.QuestionOptions)
                {
                    if (questionOption.ResponseStatus)
                        result.Add(questionOption.ChoiceOption);
                }
            };


            return result;
        }
        public string AnswerExam(AnswerDto answerDto)
        {
            int ans = 0;
            char[] charArr = _httpContextAccessor.HttpContext.Session.GetString("key").ToCharArray();
            //charArr.ToList().ForEach(p =>
            //{
            //    if (charArr[p] == answerDto.charArr[p])
            //        ans++;
            //});
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] == answerDto.charArr[i])
                    ans++;
            }
            return "Doğru cevap sayısı : " + ans;
        }

        public CustomResponseDto<NoContentDto> DeleteQuestion(int questionId)
        {
            var question = _questionDal.Get(x=>x.Id == questionId);

            if(question != null)
            {
                _questionDal.Delete(question);

                return CustomResponseDto<NoContentDto>.Success(204);
            }
            
            return CustomResponseDto<NoContentDto>.Fail(404, Messages.NotFound);
        }

        public Question GetQuestionByQuestionContentAndExamId(string questionContent, int examId)
        {
          return  _questionDal.Get(x=>x.QuestionContent == questionContent &&  x.ExamId == examId);
        }
    }
}
