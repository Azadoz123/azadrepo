using Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AskedQuestionForClientDto
    {
        public string QuestionContent { get; set; }
        public List<AskedQuestionOptionForClientDto> QuestionOptions { get; set; }
    }
}
