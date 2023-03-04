using DoctorWho.Db.Entities;
using FluentValidation;

namespace DoctorWho.Db.Validators
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.DoctorName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.DoctorNumber).NotEmpty();
            RuleFor(x => x.LastEpisodeDate).GreaterThanOrEqualTo(x => x.FirstEpisodeDate);
        }
    }
}
