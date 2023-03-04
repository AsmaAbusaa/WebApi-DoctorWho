using AutoMapper;

namespace DoctorWho.Db.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Entities.Doctor, Models.DoctorDtoWithoutEpisodes>();//for get doctor
            CreateMap<Entities.Doctor, Models.DoctorDto>();
            CreateMap<Models.DoctorDto, Entities.Doctor>();
            CreateMap<Models.DoctorDtoWithoutEpisodes, Entities.Doctor>();
            CreateMap<Entities.Doctor, Models.DoctorDtoToCreation>();
        }
    }
}
