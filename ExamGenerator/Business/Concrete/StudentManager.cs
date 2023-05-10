using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public CustomResponseDto<NoContentDto> DeleteStudent(int studentId)
        {
            var student = _studentDal.Get(x => x.Id == studentId);
            if (student != null)
            {
                _studentDal.Delete(student);
                return CustomResponseDto<NoContentDto>.Success(204);
            }

            return CustomResponseDto<NoContentDto>.Fail(404, Messages.NotFound);
        }
    }
}
