using Business.Validations.FluentValidation;
using Core.Entities.Abstract;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Filters
{
    public class ValidateFilterAttribute: ActionFilterAttribute
    {
        //private readonly IValidator _validator;
        //private readonly object _entity;
        //public ValidateFilterAttribute(IValidator validator, object entity)
        //{
        //    _validator = validator;
        //    _entity = entity;
        //}
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(errors);
            }
            //var context1 = new ValidationContext<object>(ExamAddDto);
            //var result = ExamAddDtoValidator.Validate(context1);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            //context.Result = new BadRequestObjectResult(result.Errors);
        }
    }
}
