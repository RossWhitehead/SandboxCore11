namespace SandboxCore11.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentValidation;
    using SandboxCore11.Data;

    public class CreateInventoryItemCommandValidator : AbstractValidator<CreateInventoryItemCommand>
    {
        private ApplicationDbContext db;

        public CreateInventoryItemCommandValidator(ApplicationDbContext db)
        {
            this.db = db;

            RuleFor(x => x.BrandId).Must(BeAValidBrand).WithMessage("Brand is not valid.");
            RuleFor(x => x.CategoryId).Must(BeAValidCategory).WithMessage("Category is not valid.");
            RuleFor(x => x.Description).MaximumLength(1000);
            RuleFor(x => x.Name).Length(5, 1000);
            RuleFor(x => x.ReorderLevel).GreaterThan(0);
            RuleFor(x => x.ReorderQuantity).GreaterThan(0);
        }

        private bool BeAValidBrand(int brandId)
        {
            return db.Brands.Where(x => x.BrandId == brandId).Count() == 1;
        }

        private bool BeAValidCategory(int categoryId)
        {
            return db.Categories.Where(x => x.CategoryId == categoryId).Count() == 1;
        }


    }
}
