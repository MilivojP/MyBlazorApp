using AutoMapper;
using MyBlazorApp.Server.Entities;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // TODO: map calculated field "Work"
            CreateMap<WorkTime, WorkTimeDto>();
            CreateMap<List<WorkTime>, List<WorkTimeDto>>();

            CreateMap<List<WorkTimeDto>, List<WorkTime>>();

            CreateMap<User, UserDto>();
            CreateMap<List<User>, List<UserDto>>();
            CreateMap<List<UserDto>, List<User>>();
        }
    }
}
