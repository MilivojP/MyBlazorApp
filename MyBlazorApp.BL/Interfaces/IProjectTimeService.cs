using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Interfaces
{
    public interface IProjectTimeService
    {
        public List<ProjectTimeDto> GetProjectTimes();

        public void AddProjectTimes(NewProjectTimeDto Id);

        public void UpdateProjectTime(ProjectTimeDto Id);

        public ProjectTimeDto GetProjectTime(int Id);

        public void DeleteProjectTime(int Id);
    }
}
