using PhysicianHandbook.Application.Events;
using PhysicianHandbook.Application.Models;

namespace PhysicianHandbook.Application.Views.Interfaces;

public interface IDiseaseView
{
    void SetDiseases(List<Disease> diseases);
    void LoadAvailableMedications(List<Medication> medications);
    void ClearInputFields();

    event EventHandler<DiseaseEventArgs> AddDiseaseRequested;
}