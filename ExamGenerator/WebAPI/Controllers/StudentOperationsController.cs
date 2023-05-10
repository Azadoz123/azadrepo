using Business.Abstract;
using Business.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    //[Authorize(Roles = "Admin")]
    //[Authorize]
  //  [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentOperationsController : CustomBaseController
    {
        private readonly IAskedQuestionService _askedQuestionService;
        private readonly IStudentOperationService _studentOperationService;
        private readonly IStudentService _studentService;
        private readonly IStudentAnswerService _studentAnswerService;
        public StudentOperationsController(IAskedQuestionService askedQuestionService, IStudentOperationService studentOperationService, IStudentService studentService, IStudentAnswerService studentAnswerService)
        {
            _askedQuestionService = askedQuestionService;
            _studentOperationService = studentOperationService;
            _studentService = studentService;
            _studentAnswerService = studentAnswerService;
        }

        [HttpGet("TakeExam/{examId}")]
        public IActionResult TakeExam(int examId)
        {

            if (_studentOperationService.TakeExam(examId).Count() == 0)
            {
                //return BadRequest("Could not find ");

                return CreateActionResult(CustomResponseDto<NoContent>.Fail(404, Messages.NotFound));
            };
            //return Ok(_studentOperationService.TakeExam(examId));

            var askedQuestionsForClienDtos = _studentOperationService.TakeExam(examId);
            return CreateActionResult(CustomResponseDto<List<AskedQuestionForClientDto>>.Success(200, askedQuestionsForClienDtos));
        }

        [HttpPost("AnswerExam")]
        public IActionResult AnswerExam(ClientAnswerDto clientAnswerDto)
        {

            return CreateActionResult(_studentOperationService.AnswerExam(clientAnswerDto));
        }
        [HttpPost("GetExamResult")]
        public IActionResult GetExamResult(ExamAndStudentDto examAndStudentDto)
        {
            //var result = _studentOperationService.GetExamResult(examAndStudentDto);
            //return Ok (result );
            return CreateActionResult(_studentOperationService.GetExamResult(examAndStudentDto));
        }
        [HttpPost("TakeExamByGetOnlyOneQuestion")]
        public IActionResult TakeExamByGetOnlyOneQuestion(ExamAndStudentDto examAndStudentDto)
        {
            //if(_studentOperationService.TakeExamByGetOnlyOneQuestion(examAndStudentDto.ExamId, examAndStudentDto.StudentId) == null)
            //    return Ok("Sınavı tamamladınız");
            //else
            //     return Ok(_studentOperationService.TakeExamByGetOnlyOneQuestion(examAndStudentDto.ExamId, examAndStudentDto.StudentId));

            return CreateActionResult(_studentOperationService.TakeExamByGetOnlyOneQuestion(examAndStudentDto.ExamId, examAndStudentDto.StudentId));
        }

        [HttpPut("UpdateAnswer")]
        public IActionResult UpdateAnswer(UpdateAnswerDto updateAnswerDto)
        {
            //var studentAnswer = _studentAnswerService.Get(updateAnswerDto);
            // if(studentAnswer == null)
            // {
            //     return BadRequest("Böyle bir yanıt bulunamadı");
            // }

            //_studentAnswerService.Update(updateAnswerDto);
            //return Ok("Yanıtınız Güncellendi");
            return CreateActionResult(_studentAnswerService.Update(updateAnswerDto));
        }

        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            //_studentService.DeleteStudent(id);
            //return Ok();

            return CreateActionResult(_studentService.DeleteStudent(id));
        }

        
    }
}
