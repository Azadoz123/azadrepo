using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentExamService
    {
        StudentExam Add(StudentExamDto studentExamDto);
        StudentExam GetStudentExamByStudentIdAndExamId(int studentId, int examId);
        void Update(StudentExam studentExam);
    }
}
