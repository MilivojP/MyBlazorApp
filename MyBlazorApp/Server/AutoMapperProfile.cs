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

            CreateMap<User, UserDto>();
            //.ForMember(x => x.Id, o => o.Ignore());

            CreateMap<UserDto, User>()
                .ForMember(x => x.Id, o => o.Ignore());

            CreateMap<User, DeleteUserDto>();
              //  .ForMember(x => x.Id, o => o.Ignore());

            CreateMap<DeleteUserDto, User>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Password, o => o.Ignore());

            CreateMap<User, ExistingUserDto>();
                

            CreateMap<ExistingUserDto, User>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x=> x.Password, o=>o.Ignore());

            //CreateMap<List<User>, List<UserDto>>();
            //CreateMap<List<UserDto>, List<User>>();
        }
    }
}
