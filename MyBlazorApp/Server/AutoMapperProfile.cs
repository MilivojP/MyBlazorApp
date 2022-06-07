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
            //CreateMap<WorkTime, WorkTimeDto>();
            //CreateMap<List<WorkTime>, List<WorkTimeDto>>();

            //CreateMap<List<WorkTimeDto>, List<WorkTime>>();

            // Users:
            CreateMap<User, UserDto>();
            CreateMap<NewUserDto, User>()
                .ForMember(x => x.Id, o => o.Ignore());
            CreateMap<ExistingUserDto, User>()
                 .ForMember(x => x.Password, o => o.Ignore());
            CreateMap<User, ExistingUserDto>();
        }
    }
}
