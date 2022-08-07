using AutoMapper;
using MyBlazorApp.Server.Entities;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DateOnly, DateTime>().ConvertUsing<DateOnlyToDateTimeConverter>();
            CreateMap<DateTime, DateOnly>().ConvertUsing<DateTimeToDateOnlyConverter>();

            CreateMap<TimeOnly, DateTime>().ConvertUsing<TimeOnlyToDateTimeConverter>();
            CreateMap<DateTime, TimeOnly>().ConvertUsing<DateTimeToTimeOnlyConverter>();

            // UserVacationBudget:
            CreateMap<UserVacationBudget, UserVacationBudgetDto>();
            CreateMap<UserVacationBudgetDto,UserVacationBudget>()
                .ForMember(x => x.Id, o => o.Ignore()); 
            
            // Vacation
            CreateMap<Vacation, VacationDto>();
            CreateMap<NewVacationDto, Vacation>()
                .ForMember(x => x.Id, o => o.Ignore());
            CreateMap<ExistingVacationDto, Vacation>();
            CreateMap<Vacation, ExistingVacationDto>();

            // WorkTime
            CreateMap<WorkTime, WorkTimeDto>();
            CreateMap<NewWorkTimeDto, WorkTime>()
                .ForMember(x => x.Id, o => o.Ignore());
            CreateMap<ExistingWorkTimeDto, WorkTime>();
            CreateMap<WorkTime, ExistingWorkTimeDto>();

            // Users:
            CreateMap<User, UserDto>();
            CreateMap<NewUserDto, User>()
                .ForMember(x => x.Id, o => o.Ignore());
            CreateMap<ExistingUserDto, User>()
                .ForMember(x => x.Password, o => o.Ignore());
            CreateMap<LoginUser, User>()
                .ForMember(x => x.Id, o => o.Ignore()); //Add to later

            CreateMap<User, ExistingUserDto>();

            //Holidays:
            CreateMap<Holiday, HolidayDto>();
            CreateMap<HolidayDto, Holiday>()
                .ForMember(x =>x.Id, o =>o.Ignore());

            //SickLeave:
            CreateMap<SickLeave, SickLeaveDto>();
            CreateMap<SickLeaveDto, SickLeave>()
                .ForMember(x => x.Id, o => o.Ignore());
        }
    }


    public class DateOnlyToDateTimeConverter : ITypeConverter<DateOnly, DateTime>
    {
        public DateTime Convert(DateOnly source, DateTime destination, ResolutionContext context)
        {
            return source.ToDateTime(new TimeOnly());
        }
    }

    public class DateTimeToDateOnlyConverter : ITypeConverter<DateTime, DateOnly>
    {
        public DateOnly Convert(DateTime source, DateOnly destination, ResolutionContext context)
        {
            return new DateOnly(source.Year, source.Month, source.Day);

        }
    }

    public class TimeOnlyToDateTimeConverter : ITypeConverter<TimeOnly, DateTime>
    {
        public DateTime Convert(TimeOnly source, DateTime destination, ResolutionContext context)
        {
            return new DateTime(1, 1, 1, source.Hour, source.Minute, source.Second);
        }
    }

    public class DateTimeToTimeOnlyConverter : ITypeConverter<DateTime, TimeOnly>
    {
        public TimeOnly Convert(DateTime source, TimeOnly destination, ResolutionContext context)
        {
            return new TimeOnly(source.Hour, source.Minute, source.Second);

        }
    }

}
