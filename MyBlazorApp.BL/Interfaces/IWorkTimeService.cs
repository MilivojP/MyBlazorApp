using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Interfaces
{
    public interface IWorkTimeService
    {
        public List<WorkTimeDto> GetWorkTimes();

        public void AddWorkTime(NewWorkTimeDto Id);

        public void UpdateWorkTime(ExistingWorkTimeDto Day);

        public ExistingWorkTimeDto GetWorkTime(int Id);

        public void DeleteWorkTime(int Id);
    }
}
