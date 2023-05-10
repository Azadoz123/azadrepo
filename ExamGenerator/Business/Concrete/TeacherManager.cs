using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;
        private readonly IAskedQuestionService _askedQuestionService;

        public TeacherManager(ITeacherDal teacherDal, IMapper mapper, IQuestionService questionService, IAskedQuestionService askedQuestionService)
        {
            _teacherDal = teacherDal;
            _mapper = mapper;
            _questionService = questionService;
            _askedQuestionService = askedQuestionService;
        }

        public Teacher Add(TeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            _teacherDal.Add(teacher);
            return teacher;
        }

        public void AddQuestionForTeacher(TeacherDto teacherDto, QuestionDto questionDto)
        {
            //var teacher= _teacherService.GetTeacherById(teacherId);
            var teacher = GetTeacherByName(teacherDto.TeacherName);
            var newTeacher = _mapper.Map<Teacher>(teacherDto);
            if (teacher == null)
            {
                _teacherDal.Add(newTeacher);
            }
            _questionService.Add(questionDto);
        }

        public CustomResponseDto<NoContentDto> DeleteTeacher(int teacherId)
        {
            var teacher = _teacherDal.Get(x => x.Id == teacherId);
            if (teacher != null)
            {
                _teacherDal.Delete(teacher);
                return CustomResponseDto<NoContentDto>.Success(204);
            }
            return CustomResponseDto<NoContentDto>.Fail(404, Messages.NotFound);
        }

        public List<TeacherDto> GetAll()
        {
           var teachers = _teacherDal.GetList().ToList();
            var result = _mapper.Map<List<TeacherDto>>(teachers);
            return result;
        }

        public Teacher GetTeacherById(int id)
        {
            var teacher = _teacherDal.Get(x => x.Id == id);
            return teacher;
        }

        public TeacherDto GetTeacherByName(string name)
        {
            var teacher = _teacherDal.Get(x=>x.TeacherName == name);
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            return teacherDto;
        }

        public Teacher GetTeacherByNameAndExamId(string name, int examId)
        {
            var teacher = _teacherDal.Get(x=>x.TeacherName == name &&  x.ExamId == examId);
            //var teacherDto = _mapper.Map<TeacherDto>(teacher);
            return teacher;
        }

       

        public TeacherDto TurnListTeacherDtoToTeacherDto(List<TeacherDto> teacherDtos)
        {
            TeacherDto teacherDto = new TeacherDto();
            foreach (var item in teacherDtos)
            {
                 teacherDto = item ;    
            }   
            return teacherDto;
        }

        TeacherDto ITeacherService.GetTeacherById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
