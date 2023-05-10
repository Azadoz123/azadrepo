using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Profiles
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<Exam, ExamAddDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<QuestionOption, QuestionOptionDto>().ReverseMap();
            CreateMap<AskedQuestion, AskedQuestionDto>().ReverseMap();
            CreateMap<AskedQuestionOption, AskedQuestionOptionDto>().ReverseMap();
            CreateMap<StudentAnswer, StudentAnswerDto>().ReverseMap();
            CreateMap<Question, AskedQuestionDto>().ReverseMap();
            CreateMap<QuestionOption, AskedQuestionOptionDto>().ReverseMap();
            CreateMap<AskedQuestion, AskedQuestionForClientDto>().ReverseMap();
            CreateMap<AskedQuestionOption, AskedQuestionOptionForClientDto>().ReverseMap();
            CreateMap<StudentAnswer, StudentAnswerDto>().ReverseMap();
            CreateMap<StudentExam, StudentExamDto>().ReverseMap();  
        }
    }
}
