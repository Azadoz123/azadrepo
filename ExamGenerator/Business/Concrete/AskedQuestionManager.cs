using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AskedQuestionManager: IAskedQuestionService
    {
        private readonly IAskedQuestionDal _askedQuestionDal;
        private readonly IMapper _mapper;

        public AskedQuestionManager(IAskedQuestionDal askedQuestionDal, IMapper mapper)
        {
            _askedQuestionDal = askedQuestionDal;
            _mapper = mapper;
        }

        public AskedQuestion Add(AskedQuestion askedQuestion)
        {
            _askedQuestionDal.Add(askedQuestion);
            return askedQuestion;
        }

        public List<AskedQuestion> AddRange(List<AskedQuestionDto> askedQuestionDtos)
        {
            var askedQuestions = _mapper.Map<List<AskedQuestion>>(askedQuestionDtos);
            _askedQuestionDal.AddRange(askedQuestions);
            return askedQuestions;
        }

        public char GetAskedQuestionTrueAnswerByExamIdAndQuestionNumber(int examId, int questionNumber)
        {
           var askedQuestion = _askedQuestionDal.GetAskedQuestionWithAskedQuestionOption(examId, questionNumber);
            foreach (var questionOption in askedQuestion.QuestionOptions)
            {
                if(questionOption.ResponseStatus == true)
                {
                    return questionOption.ChoiceOption;
                }
            }
            return default;
        }

        public List<AskedQuestion> GetQuestionByExamId(int examId)
        {
            return _askedQuestionDal.GetList(x=>x.ExamId == examId).Include(x=>x.QuestionOptions).ToList();
        }
    }
}
