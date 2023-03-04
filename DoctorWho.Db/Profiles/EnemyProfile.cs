using AutoMapper;

namespace DoctorWho.Db.Profiles
{
    public class EnemyProfile : Profile
    {
      public EnemyProfile()
        {
            CreateMap<Models.EnemyDto, Entities.Enemy>();
           
        }
    }
}
