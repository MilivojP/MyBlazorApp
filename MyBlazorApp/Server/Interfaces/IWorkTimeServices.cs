using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Interfaces
{
    public interface IWorkTimeServices
    {
        public List<WorkTimeDto> GetWorkTimeDetails();

        public void AddWorkTime(WorkTimeDto UserId);

        public void UpdateWorkTimeDetails(WorkTimeDto UserId);

        public WorkTimeDto GetWorkTimeData(int UserId);

        public void DeleteWorkTime(int UserId);
    }
}
