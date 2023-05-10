using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        void AddQuestionForTeacher(TeacherDto teacherDto, QuestionDto questionDto);
        Teacher Add(TeacherDto teacherDto);
        List<TeacherDto> GetAll();
        TeacherDto GetTeacherById(int id);
        TeacherDto GetTeacherByName(string name);
        Teacher GetTeacherByNameAndExamId(string name, int examId);
        TeacherDto TurnListTeacherDtoToTeacherDto(List<TeacherDto> teacherDtos);
        CustomResponseDto<NoContentDto> DeleteTeacher(int teacherId);
        
    }
}
