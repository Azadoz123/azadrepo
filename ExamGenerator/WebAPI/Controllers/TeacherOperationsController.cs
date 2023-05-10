using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherOperationsController : CustomBaseController
    {
        private readonly ITeacherOperationService _teacherOperationService;
        private readonly IExamService _examService;
        private readonly IAskedQuestionService _askedQuestionService;

        public TeacherOperationsController(ITeacherOperationService teacherOperationService, IExamService examService, IAskedQuestionService askedQuestionService)
        {
            _teacherOperationService = teacherOperationService;
            _examService = examService;
            _askedQuestionService = askedQuestionService;
        }

        [HttpPost("PrepareExam")]
        public IActionResult PrepareExam(int examId, int easyQuestionNumber, int middleQuestionNumber, int hardQuestionNumber)
        {
           
            var result = _teacherOperationService.PrepareExam(examId, easyQuestionNumber, middleQuestionNumber, hardQuestionNumber);
            //return Ok(result);
            return CreateActionResult(result);
        }

        [HttpPost("AddExam")]
        public IActionResult AddExam(ExamAddDto examAddDto)
        {

            return CreateActionResult(_teacherOperationService.AddExam(examAddDto));
            //return Ok();
        }
    }
}
