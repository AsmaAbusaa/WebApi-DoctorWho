using AutoMapper;

namespace DoctorWho.Db.Profiles
{
    public class CompanionProfile : Profile
    {
        public CompanionProfile()
        {
            CreateMap<Models.CompanionDto, Entities.Companion>();
        }
    }
}
