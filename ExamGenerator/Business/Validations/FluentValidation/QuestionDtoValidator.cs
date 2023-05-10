using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.FluentValidation
{
    public class QuestionDtoValidator: AbstractValidator<Question>
    {
        public QuestionDtoValidator()
        {
            RuleFor(x=>x.QuestionOptions).NotEmpty();
            RuleFor(x => x.QuestionOptions).Must(QuestionOptionsCountMustEqual4).WithMessage("4 adet şık eklenmeli");
        }

        private bool QuestionOptionsCountMustEqual4(List<QuestionOption> arg)
        {
            return arg.Count() == 4;
        }
    }
}
