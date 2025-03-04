using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Validators;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz");
            RuleFor(x=>x.CategoryName).MinimumLength(2).WithMessage("Kategori adı 2 karakterden fazla olmalıdır");
            RuleFor(x=>x.CategoryName).MaximumLength(50).WithMessage("Kategori adı 50 karakterden az olmalıdır");
            RuleFor(x=>x.CategoryDescription).MinimumLength(2).WithMessage("Açıklama 2 karakterden fazla olmalıdır");
            RuleFor(x=>x.CategoryDescription).MaximumLength(50).WithMessage("Açıklama 50 karakterden az olmalıdır");
        }
    }
}
