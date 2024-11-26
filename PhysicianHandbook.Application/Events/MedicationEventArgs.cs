using PhysicianHandbook.Application.Models;

namespace PhysicianHandbook.Application.Events;

public class MedicationEventArgs : EventArgs
{
    public Medication Medication { get; set; }
}