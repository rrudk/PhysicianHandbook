using PhysicianHandbook.Application.Events;
using PhysicianHandbook.Application.Models;
using PhysicianHandbook.Application.Services.Interfaces;
using PhysicianHandbook.Application.Views.Interfaces;

namespace PhysicianHandbook.Application.Presenters;

public class MedicationPresenter
{
    private readonly IMedicationView _view;
    private readonly IDataService _dataService;

    public MedicationPresenter(IMedicationView view, IDataService dataService)
    {
        _view = view;
        _dataService = dataService;

        _view.AddMedicationRequested += OnAddMedicationRequested;
        _view.DeleteMedicationRequested += OnDeleteMedicationRequested;
        _view.EditMedicationRequested += OnEditMedicationRequested;

        LoadMedications();
    }

    private async void LoadMedications()
    {
        var medications = await _dataService.GetMedicationsAsync();
        _view.SetMedications(medications);
    }

    private async void OnAddMedicationRequested(object sender, MedicationEventArgs e)
    {
        var medication = e.Medication;
        medication.Id = Guid.NewGuid();
        var medications = await _dataService.GetMedicationsAsync();
        medications.Add(medication);

        await _dataService.SaveMedicationsAsync(medications);
        _view.SetMedications(medications);
    }

    private async void OnDeleteMedicationRequested(object sender, Guid id)
    {
        await DeleteMedicationAsync(id);
    }

    private async void OnEditMedicationRequested(object sender, MedicationEventArgs e)
    {
        var editedMedication = e.Medication;
        await UpdateMedicationAsync(editedMedication);
    }

    public async Task UpdateMedicationAsync(Medication medication)
    {
        var medications = await _dataService.GetMedicationsAsync();
        var index = medications.FindIndex(m => m.Id == medication.Id);

        if (index != -1)
        {
            medications[index].Name = medication.Name;
            medications[index].Alternatives = medication.Alternatives;

            await _dataService.SaveMedicationsAsync(medications);
            _view.SetMedications(medications);
        }
    }

    public async Task DeleteMedicationAsync(Guid id)
    {
        var medications = await _dataService.GetMedicationsAsync();
        medications.RemoveAll(m => m.Id == id);

        foreach (var med in medications)
        {
            med.Alternatives.RemoveAll(a => a.Id == id);
        }

        await _dataService.SaveMedicationsAsync(medications);
        _view.SetMedications(medications);
    }
}