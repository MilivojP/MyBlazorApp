using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Interfaces
{
    public interface IProjectTimeService
    {
        public List<ProjectTimeDto> GetProjectTimes();

        public void AddProjectTime(NewProjectTimeDto projectTime);

        public void UpdateProjectTime(ProjectTimeDto projectTime);

        public ProjectTimeDto GetProjectTime(int projectTime);

        public void DeleteProjectTime(int id);
    }
}
