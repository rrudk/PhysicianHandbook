namespace PhysicianHandbook.Application.Models;

public class Medication
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public List<Medication> Alternatives { get; set; } = new List<Medication>();
    public string AlternativesSummary => string.Join(", ", Alternatives.Select(a => a.Name));
}