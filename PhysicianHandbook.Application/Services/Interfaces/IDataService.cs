using PhysicianHandbook.Application.Models;

namespace PhysicianHandbook.Application.Services.Interfaces;

public interface IDataService
{
    Task<List<Disease>> GetDiseasesAsync();
    Task SaveDiseasesAsync(List<Disease> diseases);
    Task<List<Medication>> GetMedicationsAsync();
    Task SaveMedicationsAsync(List<Medication> medications);
    Task<List<Prescription>> GetPrescriptionsAsync();
    Task SavePrescriptionsAsync(List<Prescription> prescriptions);
}