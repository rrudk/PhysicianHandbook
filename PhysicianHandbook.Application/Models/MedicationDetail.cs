using PhysicianHandbook.Application.Models.Enums;

namespace PhysicianHandbook.Application.Models;

public class MedicationDetail
{
    public Medication Medication { get; set; } = new Medication();
    public int Quantity { get; set; }
    public UnitType Unit { get; set; }

    public string MedicationName => Medication?.Name ?? string.Empty;
}