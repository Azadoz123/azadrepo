using Core.Data_Access;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IStudentAnswerDal: IEntityRepository<StudentAnswer>
    {
        List<StudentAnswer> AddRange(List<StudentAnswer> studentAnswer);
        List<StudentAnswer> GetAnsweredQuestionsByStudentIdAndExamId(int studentId, int examId);
    }
}
