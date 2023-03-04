using DoctorWho.Db.Entities;
using FluentValidation;

namespace DoctorWho.Db.Validators
{
    public class EpisodeValidator : AbstractValidator<Episode>
    {
        public EpisodeValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.DoctorId).NotEmpty();
            RuleFor(x => x.SeriesNumber.ToString()).Length(10);
            RuleFor(x => x.EpisodeNumber).GreaterThan(0);
        }
    }
}
