using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Interfaces
{
    public interface IWorkTimeServices
    {
        public List<WorkTimeDto> GetWorkTimeDetails();

        public void AddWorkTime(WorkTimeDto UserName);

        public void UpdateWorkTimeDetails(WorkTimeDto UserName);

        public WorkTimeDto GetWorkTimeData(int UserId);

        public void DeleteWorkTime(int UserId);
    }
}
