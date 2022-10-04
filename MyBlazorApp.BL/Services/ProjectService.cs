using AutoMapper;
using MyBlazorApp.BL.Interfaces;
using MyBlazorApp.DAL.Entities;
using MyBlazorApp.Server.Data;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        readonly DatabaseContext _dbContext;

        public ProjectService(IMapper mapper, DatabaseContext databaseContex)
        {
            _mapper = mapper;
            _dbContext = databaseContex;
        }
        
        public void AddProject(NewProjectDto project)
        {
            if (_dbContext.Projects.Any(x => x.UserId == project.UserId && x.ProjectId == project.ProjectId))
            {
                throw new Exception("WorkTime with this UserId and tihs Day already exists!");
            }

            try
            {
                var data = _mapper.Map<Project>(project);

                _dbContext.Projects.Add(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void DeleteProject(int id)
        {
            try
            {
                var data = _dbContext.Projects.Find(id);
                if (data != null)
                {
                    _dbContext.Projects.Remove(data);

                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException($"Projects with id {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public ExistingProjectDto GetProject(int id)
        {
            try
            {
                var data = _dbContext.Projects.Find(id);

                if (data != null)
                {
                    return _mapper.Map<ExistingProjectDto>(data);
                }
                else
                {
                    throw new KeyNotFoundException($"Project with id {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<ProjectDto> GetProjects()
        {
            try
            {
                var data = _dbContext.Projects.OrderBy(x => x.UserId).ThenByDescending(x => x.ProjectId).ToList();

                return _mapper.Map<List<ProjectDto>>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void UpdateProject(ExistingProjectDto ProjectId)
        {
            if (ProjectId is null)
            {
                throw new ArgumentNullException("Parameter 'Id' is null.");
            }
            try
            {
                // TODO: get worktime from data store and then update
                var data = _mapper.Map<Project>(ProjectId);

                _dbContext.Projects.Update(data);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
