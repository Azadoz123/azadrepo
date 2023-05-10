using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AskedQuestionOption: BaseEntity, IEntity
    {
        public string QuestionOptionContent { get; set; }
        public char ChoiceOption { get; set; }
        public bool ResponseStatus { get; set; }
        public int AskedQuestionId { get; set; } 
        public AskedQuestion AskedQuestion { get; set; }
    }
}
