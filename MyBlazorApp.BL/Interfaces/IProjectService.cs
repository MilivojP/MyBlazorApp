using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Interfaces
{
    public interface IProjectService
    {
        public List<ProjectDto> GetProjects();

        public void AddProject(ProjectDto Id);

        public void UpdateProject(ProjectDto Id);

        public ProjectDto GetProject(int Id);

        public void DeleteProject(int Id);
    }
}
