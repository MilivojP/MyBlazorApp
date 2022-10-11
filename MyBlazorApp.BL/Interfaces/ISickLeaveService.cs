using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Interfaces
{
    public interface ISickLeaveService
    {
        public List<SickLeaveDto> GetSickLeaves();

        public void AddSickLeave(SickLeaveDto sick);

        public void UpdateSickLeave(SickLeaveDto sick);

        public SickLeaveDto GetSickLeave(int Id);

        public void DeleteSickLeave(int Id);
    }
}
