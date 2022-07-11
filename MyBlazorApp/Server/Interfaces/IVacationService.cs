using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Interfaces
{
    public interface IVacationService
    {
        public List<VacationDto> GetVacations();

        public void AddVacation(NewVacationDto vacation);

        public void UpdateVacation(ExistingVacationDto Day);

        public ExistingVacationDto GetVacation(int Id);

        public void DeleteVacation(int Id);
    }
}
