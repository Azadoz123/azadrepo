using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Teacher : BaseEntity, IEntity
    {
        public string TeacherName { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
