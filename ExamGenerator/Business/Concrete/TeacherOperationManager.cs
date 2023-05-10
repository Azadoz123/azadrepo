using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeacherOperationManager: ITeacherOperationService
    {
        private readonly IAskedQuestionService _askedQuestionService;
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private readonly IExamService _examService;

        public TeacherOperationManager(IAskedQuestionService askedQuestionService, IExamService examService, IQuestionService questionService, IMapper mapper)
        {
            _askedQuestionService = askedQuestionService;
            _examService = examService;
            _questionService = questionService;
            _mapper = mapper;
        }

        public CustomResponseDto<ExamDto> AddExam(ExamAddDto examAddDto)
        {
           var exam = _examService.AddExam(examAddDto);
           var examDto = _mapper.Map<ExamDto>(exam);
            return  CustomResponseDto<ExamDto>.Success(201, examDto);
        }

        public CustomResponseDto<string> PrepareExam(int examId, int easyQuestionNumber, int middleQuestionNumber, int hardQuestionNumber)
        {
            if (_askedQuestionService.GetQuestionByExamId(examId).Count() > 0)
            {
                return CustomResponseDto<string>.Fail(400, "Sınav sorularını hazırlanmış bulunmaktasınız. Sınav sorularını değiştir seçeneğini deneyin.");
            }
            if (_askedQuestionService.GetQuestionByExamId(examId).Count() == 0)
            {
                var questions = _questionService.GetRandomlyQuestions(examId, easyQuestionNumber, middleQuestionNumber, hardQuestionNumber);
                
                var askedQuestionDtos = _mapper.Map<List<AskedQuestionDto>>(questions);

                for (int i = 0; i < askedQuestionDtos.Count(); i++)
                {
                    askedQuestionDtos[i].QuestionNumber = i + 1;
                };
                _askedQuestionService.AddRange(askedQuestionDtos);
                //return questionDtos;
                return CustomResponseDto<string>.Success(201, Messages.ExamQuestionsIsPrepared);
            }

            return CustomResponseDto<string>.Success(400, Messages.ExamQuestionsIsPrepared);
        }
    }
}
