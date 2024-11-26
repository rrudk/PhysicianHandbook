using Newtonsoft.Json;
using PhysicianHandbook.Application.Models;
using PhysicianHandbook.Application.Services.Interfaces;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace PhysicianHandbook.Application.Services;

public class DataService : IDataService
{
    private readonly string _diseasesPath;
    private readonly string _medicationsPath;
    private readonly string _prescriptionsPath;

    public DataService(IConfiguration configuration)
    {
        _diseasesPath = configuration["DataPaths:Diseases"];
        _medicationsPath = configuration["DataPaths:Medications"];
        _prescriptionsPath = configuration["DataPaths:Prescriptions"];
    }

    public async Task<List<Disease>> GetDiseasesAsync()
    {
        if (!File.Exists(_diseasesPath))
        {
            return new List<Disease>();
        }

        var json = await File.ReadAllTextAsync(_diseasesPath);
        return JsonConvert.DeserializeObject<List<Disease>>(json) ?? new List<Disease>();
    }

    public async Task SaveDiseasesAsync(List<Disease> diseases)
    {
        var json = JsonConvert.SerializeObject(diseases, Formatting.Indented);

        Directory.CreateDirectory(Path.GetDirectoryName(_diseasesPath)!);
        await File.WriteAllTextAsync(_diseasesPath, json);
    }

    public async Task<List<Medication>> GetMedicationsAsync()
    {
        if (!File.Exists(_medicationsPath))
        {
            return [];
        }

        var json = await File.ReadAllTextAsync(_medicationsPath);
        return JsonConvert.DeserializeObject<List<Medication>>(json) ?? [];
    }

    public async Task SaveMedicationsAsync(List<Medication> medications)
    {
        var json = JsonConvert.SerializeObject(medications, Formatting.Indented);

        Directory.CreateDirectory(Path.GetDirectoryName(_medicationsPath)!);
        await File.WriteAllTextAsync(_medicationsPath, json);
    }

    public async Task<List<Prescription>> GetPrescriptionsAsync()
    {
        if (!File.Exists(_prescriptionsPath))
        {
            return [];
        }

        var json = await File.ReadAllTextAsync(_prescriptionsPath);
        return JsonConvert.DeserializeObject<List<Prescription>>(json) ?? [];
    }

    public async Task SavePrescriptionsAsync(List<Prescription> prescriptions)
    {
        var json = JsonConvert.SerializeObject(prescriptions, Formatting.Indented);

        Directory.CreateDirectory(Path.GetDirectoryName(_prescriptionsPath)!);
        await File.WriteAllTextAsync(_prescriptionsPath, json);
    }
}