using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Interfaces
{
    public interface ISickLeaveService
    {
        public List<SickLeaveDto> GetSickLeaves();

        public void AddSickLeave(SickLeaveDto sick);

        public void UpdateSickeLeave(SickLeaveDto sick);

        public SickLeaveDto GetSickLeave(int Id);

        public void DeleteSickLeave(int Id);
    }
}
