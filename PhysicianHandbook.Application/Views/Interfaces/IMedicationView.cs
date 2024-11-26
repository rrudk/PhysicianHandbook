using PhysicianHandbook.Application.Events;
using PhysicianHandbook.Application.Models;

namespace PhysicianHandbook.Application.Views.Interfaces;

public interface IMedicationView
{
    void SetMedications(List<Medication> medications);
    void SetAllMedications(List<Medication> medications);
    void ClearInputFields();

    event EventHandler<MedicationEventArgs> AddMedicationRequested;
    event EventHandler<Guid> DeleteMedicationRequested;
    event EventHandler<MedicationEventArgs> EditMedicationRequested;
}