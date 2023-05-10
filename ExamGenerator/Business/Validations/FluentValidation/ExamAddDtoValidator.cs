using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.FluentValidation
{
    public class ExamAddDtoValidator: AbstractValidator<ExamAddDto>
    {
        public ExamAddDtoValidator()
        {
            RuleFor(x => x.ExamName).NotNull().WithMessage("{PropertyName} alanı gereklidir").NotEmpty().WithMessage("{PropertyName} alanı gereklidir");
            RuleForEach(x => x.Questions).ChildRules(questionDto => questionDto.RuleFor(x => x.QuestionOptions).Must(QuestionOptionsCountMustEqual4).WithMessage("4 adet şık eklenmeli"));
            
        }

        private bool QuestionOptionsCountMustEqual4(List<QuestionOptionDto> arg)
        {
            return arg.Count() == 4;
        }
    }
}
