using AutoMapper;
using Business.Abstract;
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
    public class StudentExamManager : IStudentExamService
    {
        private readonly IStudentExamDal _studentExamDal;
        private readonly IMapper _mapper;

        public StudentExamManager(IStudentExamDal studentExamDal, IMapper mapper)
        {
            _studentExamDal = studentExamDal;
            _mapper = mapper;
        }

        public StudentExam Add(StudentExamDto studentExamDto)
        {
            var studentExam = _mapper.Map<StudentExam>(studentExamDto);
            _studentExamDal.Add(studentExam);
            return studentExam;
        }

        public StudentExam GetStudentExamByStudentIdAndExamId(int studentId, int examId)
        {
           return _studentExamDal.GetStudentExamByStudentIdAndExamId(studentId, examId);
        }

        public void Update(StudentExam studentExam)
        {
            _studentExamDal.Update(studentExam);
        }
    }
}
