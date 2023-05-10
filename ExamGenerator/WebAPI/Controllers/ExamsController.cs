using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    //[Authorize(Roles = "Admin")]
   // [Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : CustomBaseController
    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ExamsController(IExamService examService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _examService = examService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

           
        }    
        //[HttpGet("GetAll")]
        //public IActionResult GetAll()
        //{
        //    //var session = _httpContextAccessor.HttpContext.Session.GetString("key");
        //   var result = _examService.GetAll();
        //    return Ok(result);
        //}

        [HttpGet("GetAllExamWithQuestionAndQuestionOptionsAndTeacher")]
        public IActionResult GetAllExamWithQuestionAndQuestionOptionsAndTeacher() 
        {
            var result = _examService.GetAllExamWithQuestionAndQuestionOptionsAndTeacher();
            // var trueAnswers = _examService.GetTrueAnswers(result);
            // var newString = new string(trueAnswers.ToArray());
            //_httpContextAccessor.HttpContext.Session.SetString("key",newString);
            //return Ok(result);
            
            if(result.Count() == 0) 
            {
                return CreateActionResult(CustomResponseDto<List<NoContentDto>>.Fail(404,Messages.NotFound));
            }
            return CreateActionResult(CustomResponseDto<List<ExamDto>>.Success(200, result));
        }

        [HttpPost("AddExam")]
        public IActionResult AddExam(ExamAddDto examAddDto)
        {
            
           var result = _examService.AddExam(examAddDto);

            if(result == null)
            {
                return  CreateActionResult(CustomResponseDto<NoContentDto>.Fail(400, Messages.ThisExamIsExist));
            }
            //return Ok();

            return CreateActionResult(CustomResponseDto<Exam>.Success(201, result));
        }
        //[HttpPost("AnswerExam")]
        //public IActionResult AnswerExam(AnswerDto answerDto)
        //{
            
        //    return Ok(_examService.AnswerExam(answerDto));
        //}
        
        [HttpDelete("DeleteExam/{examId}")]
        public IActionResult DeleteExam(int examId)
        {
            //_examService.DeleteExam(examId);
            //return Ok();
            return CreateActionResult(_examService.DeleteExam(examId));
        }
        //[HttpPost("AddQuestionForTeacher")]
        ////public IActionResult AddQuestionForTeacher(TeacherDto teacherDto, QuestionDto questionDto)
        //public IActionResult AddQuestionForTeacher(TeacherAddDto teacherAddDto)
        //{
        //    _examService.AddQuestionForTeacher(teacherAddDto.teacherDto, teacherAddDto.questionDto);
        //    return Ok();
        //}
    }
}
