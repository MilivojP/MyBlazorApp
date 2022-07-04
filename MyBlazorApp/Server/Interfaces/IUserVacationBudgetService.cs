using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Interfaces
{
    public interface IUserVacationBudgetService
    {
        public List<UserVacationBudgetDto> GetUserVacationsBudget();

        public void AddUserVacationBudget(UserVacationBudgetDto user);

        public void UpdateUserVacationBudget(UserVacationBudgetDto user);

        public UserVacationBudgetDto GetUserVacationBudgetDto(int id);

        public void DeleteUserVacationBudgetDto(int id);
    }
}
