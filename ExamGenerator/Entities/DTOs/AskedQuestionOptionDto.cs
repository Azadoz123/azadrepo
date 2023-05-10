using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AskedQuestionOptionDto
    {
        public string QuestionOptionContent { get; set; }
        public char ChoiceOption { get; set; }
        public bool ResponseStatus { get; set; }
        public int AskedQuestionId { get; set; }
    }
}
