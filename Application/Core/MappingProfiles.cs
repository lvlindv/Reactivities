using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Specifie where are we going to map from and where are we going to map to.
            // Mapping from Activity to Activity
            
            CreateMap<Activity, Activity>();
        }
    }
}