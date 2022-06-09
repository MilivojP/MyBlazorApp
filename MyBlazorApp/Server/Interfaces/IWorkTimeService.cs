using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Interfaces
{
    public interface IWorkTimeService
    {
        public List<WorkTimeDto> GetWorkTimes();

        public void AddWorkTime(NewWorkTimeDto UserId);

        public void UpdateWorkTime(ExistingWorkTimeDto Day);

        public ExistingWorkTimeDto GetWorkTime(int UserId);

        public void DeleteWorkTime(int UserId);
    }
}
