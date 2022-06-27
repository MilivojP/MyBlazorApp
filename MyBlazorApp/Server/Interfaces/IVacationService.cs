﻿using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Interfaces
{
    public interface IVacationService
    {
        public List<VacationDto> GetVacations();

        public void AddVacation(NewVacationDto vacation);

        public void UpdateVacation(ExistingVacationDto vacation);

        public ExistingVacationDto GetVacation(int id);

        public void DeleteVacation(int id);
    }
}
