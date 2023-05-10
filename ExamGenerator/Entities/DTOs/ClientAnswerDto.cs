using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ClientAnswerDto
    {
        public int examId { get; set; }
        public int StudentId { get; set; }
        public char[] charArr { get; set; }
    }
}
