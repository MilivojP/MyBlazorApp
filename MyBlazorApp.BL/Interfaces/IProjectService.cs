using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Interfaces
{
    public interface IProjectService
    {
        public List<ProjectDto> GetProjects();

        public void AddProject(NewProjectDto Id);

        public void UpdateProject(ExistingProjectDto ProjectId);

        public ExistingProjectDto GetProject(int Id);

        public void DeleteProject(int Id);
    }
}
