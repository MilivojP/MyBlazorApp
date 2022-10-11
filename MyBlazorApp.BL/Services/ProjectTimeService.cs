using AutoMapper;
using MyBlazorApp.BL.Interfaces;
using MyBlazorApp.DAL.Entities;
using MyBlazorApp.DAL.Data;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Services
{
    public class ProjectTimeService : IProjectTimeService
    {
        private readonly IMapper _mapper;
        readonly DatabaseContext _dbContext;

        public ProjectTimeService(IMapper mapper, DatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public void AddProjectTimes(NewProjectTimeDto Id)
        {
            if (_dbContext.ProjectTime.Any(x => x.UserId == Id.UserId && x.ProjectId == Id.ProjectId && x.Day == DateOnly.FromDateTime(Id.Day)))
            {
                throw new Exception("WorkTime with this UserId and tihs Day already exists!");
            }

            try
            {
                var data = _mapper.Map<ProjectTime>(Id);

                _dbContext.ProjectTime.Add(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void DeleteProjectTime(int Id)
        {
            try
            {
                var data = _dbContext.ProjectTime.Find(Id);
                if (data != null)
                {
                    _dbContext.ProjectTime.Remove(data);

                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException($"ProjectTime with id {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<ProjectTimeDto> GetProjectTimes()
        {
            try
            {
                var data = _dbContext.ProjectTime.OrderBy(x => x.UserId).ThenBy(x =>x.ProjectId).ThenByDescending(x => x.Day).ToList();

                return _mapper.Map<List<ProjectTimeDto>>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void UpdateProjectTime(ProjectTimeDto Id)
        {
            if (Id is null)
            {
                throw new ArgumentNullException("Parameter 'Id' is null.");
            }
            try
            {
                // TODO: get worktime from data store and then update
                var data = _mapper.Map<ProjectTime>(Id);

                _dbContext.ProjectTime.Update(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new InvalidOperationException(ex.Message);
            }
        }

        ProjectTimeDto IProjectTimeService.GetProjectTime(int Id)
        {
            try
            {
                var data = _dbContext.ProjectTime.Find(Id);

                if (data != null)
                {
                    return _mapper.Map<ProjectTimeDto>(data);
                }
                else
                {
                    throw new KeyNotFoundException($"ProjectTime with id {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
