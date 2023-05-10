using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : CustomBaseController
    {
        private readonly ITeacherService _teacherService;
        private readonly IAskedQuestionService _askedQuestionService;
        private readonly IMapper _mapper;
        private readonly IStudentAnswerService _studentAnswerService;
        private readonly IQuestionService _questionService;
        public TeachersController(ITeacherService teacherService, IAskedQuestionService askedQuestionService, IMapper mapper, IStudentAnswerService studentAnswerService, IQuestionService questionService)
        {
            _teacherService = teacherService;
            _askedQuestionService = askedQuestionService;
            _mapper = mapper;
            _studentAnswerService = studentAnswerService;
            _questionService = questionService;
        }

        //[HttpPost("PrepareExam")]
        //public IActionResult PrepareExam(string examName, int easyQuestionNumber, int middleQuestionNumber, int hardQuestionNumber)
        //{
        //    var result = _teacherService.PrepareExam(examName, easyQuestionNumber, middleQuestionNumber, hardQuestionNumber);
        //    return Ok(result);
        //}
        [HttpDelete("DeleteTeacher/{teacherId}")]
        public IActionResult DeleteTeacher(int teacherId)
        {
            return CreateActionResult(_teacherService.DeleteTeacher(teacherId));
            //return Ok();
        }
        //[HttpPost("AddQuestionForTeacher")]
        ////public IActionResult AddQuestionForTeacher(TeacherDto teacherDto, QuestionDto questionDto)
        //public IActionResult AddQuestionForTeacher(TeacherAddDto teacherAddDto)
        //{
        //    _teacherService.AddQuestionForTeacher(teacherAddDto.teacherDto, teacherAddDto.questionDto);
        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult addasked(AskedQuestionDto askedQuestionDto)
        //{
        //    var askedQuestion = _mapper.Map<AskedQuestion>(askedQuestionDto);
        //    _askedQuestionService.Add(askedQuestion);

        //    var studentAnswer = new StudentAnswer
        //    {
        //        AskedQuestionId = askedQuestion.Id,
        //        StudentId = 1,
        //        ExamId = askedQuestion.ExamId,
        //        StudentAnswerForQuestion = 'A'
        //    };
        //    _studentAnswerService.Add(studentAnswer);

        //    return Ok();
        //}
    }
}
