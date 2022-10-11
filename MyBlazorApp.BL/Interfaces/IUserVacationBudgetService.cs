using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.BL.Interfaces
{
    public interface IUserVacationBudgetService
    {
        public List<UserVacationBudgetDto> GetUserVacationsBudget();

        public void AddUserVacationBudget(UserVacationBudgetDto Id);

        public void UpdateUserVacationBudget(UserVacationBudgetDto user);

        public UserVacationBudgetDto GetUserVacationBudgetDto(int Id);

        public void DeleteUserVacationBudgetDto(int Id);
    }
}
