namespace PhysicianHandbook.Application.Models;

public class Prescription
{
    public int Id { get; set; }
    public string Patient { get; set; } = string.Empty;
    public List<Medication> Medications { get; set; } = [];
    public string MedicationsSummary => string.Join(", ", Medications.Select(m => m.Name));

}