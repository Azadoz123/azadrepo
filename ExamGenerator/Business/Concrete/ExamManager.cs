using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Business.Constants;

namespace Business.Concrete
{
    public class ExamManager : IExamService
    {
        private readonly IExamDal _examDal;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITeacherService _teacherService;
        private readonly IQuestionService _questionService;
        public ExamManager(IExamDal examDal, IMapper mapper, IHttpContextAccessor httpContextAccessor, ITeacherService teacherService, IQuestionService questionService)
        {
            _examDal = examDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _teacherService = teacherService;
            _questionService = questionService;
        }

        public Exam AddExam(ExamAddDto examDto)
        {
            //var newTeacher = new Teacher();

            //foreach (var questionDtos in examDto.QuestionDtos)
            //{
            //    if (questionDtos.QuestionOptions.Count() == 4)
            //    { 

            //    }
            //}

            var ExamId = 0;
            var teacherId = 0;
            List<QuestionDto> questionList = new List<QuestionDto>();
            var exam = _mapper.Map<Exam>(examDto);     
            var examResult = _examDal.Get(x => x.ExamName == exam.ExamName);
             //newTeacher.ExamId = examResult.Id;
            if (examResult == null)
            {
               return _examDal.Add(exam);
                //newTeacher.ExamId = exam.Id;
                ExamId = exam.Id;
            }
            else
            {
                //newTeacher.ExamId = examResult.Id;
                ExamId = examResult.Id;
            }

            var teacherDto = _teacherService.TurnListTeacherDtoToTeacherDto(examDto.Teachers);
            //teacherDto.ExamId= newTeacher.ExamId;
            teacherDto.ExamId = ExamId;
            //var teacherResultDto = _teacherService.GetTeacherByName(teacherDto.TeacherName);
            var teacherResult = _teacherService.GetTeacherByNameAndExamId(teacherDto.TeacherName,teacherDto.ExamId);
            if (teacherResult == null)
            {
                var teacher =  _teacherService.Add(teacherDto);
                teacherId = teacher.Id;
            }
            else
            {
                teacherId =teacherResult.Id;
            }
            //var q = _mapper.Map<List<Question>>(examDto.Questions);

            foreach (var questionDto in examDto.Questions)
            {
                questionDto.ExamId = ExamId;
                var question = _questionService.GetQuestionByQuestionContentAndExamId(questionDto.QuestionContent,questionDto.ExamId);

                if(question == null)
                {
                    questionList.Add(questionDto);
                }
            }

            //var result = questionList.Select(x => x.QuestionContent);
            if(questionList.Count > 0)
            {
                //var questions = _questionService.AddRange(examDto.Questions);
                _questionService.AddRange(questionList);

              return  _examDal.Get(x => x.Id == ExamId);
            }

            return null;
            //foreach (var question in questions)
            //{

            //    foreach (var questionOption in question.QuestionOptions)
            //    {
            //        questionOption.QuestionId = question.Id;
            //    }

            //}
            //var NewExam = new Exam()
            //{
            //    ExamName = examAddDto.ExamName,
            //    Teachers = new List<Teacher>() {
            //    new Teacher()
            //    {
            //        TeacherName = examAddDto.examAddWithTeacherInfoDto.TeacherName
            //    }
            //    }
            //};
            //_examService.Add(NewExam);

        }

        public void AddQuestionForTeacher(TeacherDto teacherDto, QuestionDto questionDto)
        {
            //var teacher= _teacherService.GetTeacherById(teacherId);
            var teacher = _teacherService.GetTeacherByName(teacherDto.TeacherName);
            if (teacher == null)
            {
                _teacherService.Add(teacherDto);
            }
            _questionService.Add(questionDto);

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

        public CustomResponseDto<NoContentDto> DeleteExam(int examId)
        {
            var exam = _examDal.Get(x => x.Id == examId);

            if (exam != null)
            {
                _examDal.Delete(exam);

                return CustomResponseDto<NoContentDto>.Success(204);
                
            }

            return CustomResponseDto<NoContentDto>.Fail(404, Messages.NotFound);
        }

        public int ExamScore(AnswerDto answerDto)
        {
            return 1;
        }

        //public void Add(ExamAddDto examAddDto)
        //{
        //    _examDal.Add(examAddDto);
        //}
        public List<ExamDto> GetAll()
        {
            var exams = _examDal.GetList().ToList();
            var result = _mapper.Map<List<ExamDto>>(exams);
            return result;
        }

        public List<ExamDto> GetAllExamWithQuestionAndQuestionOptionsAndTeacher()
        {
            var exams = _examDal.GetAllExamWithQuestionAndQuestionOptionsAndTeacher().ToList();
            //var trueAnswers = GetTrueAnswers(exams);
            //var newString = new string(trueAnswers.ToArray());
            //_httpContextAccessor.HttpContext.Session.SetString("key", newString);
            var result = _mapper.Map<List<ExamDto>>(exams);
            return result;
        }

        public void GetRandomlyExamQuestions(string examName)
        {
            //_questionService.GetRandomlyQuestions(examName);
        }

        public List<char> GetTrueAnswers(List<Exam> exams)
        {
            List<char> result = new List<char>();
            foreach(var exam in exams)
            {
               foreach(var question in exam.Questions)
                {
                    foreach(var questionOption in question.QuestionOptions)
                    {
                        if (questionOption.ResponseStatus)
                            result.Add(questionOption.ChoiceOption);
                    }
                }
            };
            return result;
        }
    }
}
