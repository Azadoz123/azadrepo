using Business.Abstract;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : CustomBaseController
    {
        private IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        //[HttpGet("GetRandomlyExamQuestions/{examId}")]
        //public IActionResult GetRandomlyExamQuestions(int examId)
        //{
            //_questionDal.GetRandomlyQuestions();
            //return Ok(_questionService.GetRandomlyQuestions(examName));
        //    return Ok();
        //}
        //[HttpPost("AnswerExam")]
        //public IActionResult AnswerExam(AnswerDto answerDto)
        //{

        //    return Ok(_questionService.AnswerExam(answerDto));
        //}
        [HttpDelete("DeleteQuestion/{questionId}")]
        public IActionResult DeleteQuestion(int questionId)
        {
          return CreateActionResult(_questionService.DeleteQuestion(questionId));
            //return Ok();
        }
    }
}
