using AutoMapper;

namespace DoctorWho.Db.Profiles
{
    class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Entities.Episode, Models.EpisodeDtoWithoutCompEnem>();
            CreateMap<Models.EpisodeDtoWithoutCompEnem, Entities.Episode>();
            CreateMap<Entities.Episode, Models.EpisodeDto>();
            CreateMap<Entities.Episode, Models.EpisodeDtoToCreation>();
        }

    }
}
