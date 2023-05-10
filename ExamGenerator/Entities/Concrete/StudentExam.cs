using Core.Entities.Abstract;
using Entities.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    
    public class StudentExam:BaseEntity, IEntity
    {
        public StatusOfExam StatusOfExam { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
