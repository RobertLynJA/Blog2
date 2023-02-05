using AutoMapper;
using DataFacade.Models.Stories;

namespace API.Models;

public class StoriesProfile : Profile
{
    public StoriesProfile() 
    { 
        CreateMap<Story, Models.Stories.Story>();
    }
}
