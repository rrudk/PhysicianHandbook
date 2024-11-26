namespace PhysicianHandbook.Application.Models;

public class Disease
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Symptoms { get; set; } = string.Empty;
    public string Procedures { get; set; } = string.Empty;
    public List<MedicationDetail> Medications { get; set; } = new List<MedicationDetail>();

    public string MedicationsSummary => string.Join(", ", Medications.Select(m => $"{m.Medication.Name} ({m.Quantity} {m.Unit})"));
}