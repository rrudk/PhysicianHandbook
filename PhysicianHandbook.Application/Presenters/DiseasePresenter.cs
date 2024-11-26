using PhysicianHandbook.Application.Events;
using PhysicianHandbook.Application.Models;
using PhysicianHandbook.Application.Services.Interfaces;
using PhysicianHandbook.Application.Views.Interfaces;

namespace PhysicianHandbook.Application.Presenters;

public class DiseasePresenter
{
    private readonly IDiseaseView _view;
    private readonly IDataService _dataService;

    public DiseasePresenter(IDiseaseView view, IDataService dataService)
    {
        _view = view;
        _dataService = dataService;

        _view.AddDiseaseRequested += OnAddDiseaseRequested;

        LoadDiseases();
        LoadAvailableMedications();
    }

    private async void LoadDiseases()
    {
        var diseases = await _dataService.GetDiseasesAsync();
        _view.SetDiseases(diseases);
    }

    private async void LoadAvailableMedications()
    {
        var medications = await _dataService.GetMedicationsAsync();
        _view.LoadAvailableMedications(medications);
    }
    private async void OnAddDiseaseRequested(object sender, DiseaseEventArgs e)
    {
        var disease = e.Disease;
        disease.Id = Guid.NewGuid();
        var diseases = await _dataService.GetDiseasesAsync();
        
        diseases.Add(disease);

        await _dataService.SaveDiseasesAsync(diseases);
        _view.SetDiseases(diseases);
    }

    public async Task UpdateDiseaseAsync(Disease disease)
    {
        var diseases = await _dataService.GetDiseasesAsync();
        var index = diseases.FindIndex(d => d.Id == disease.Id);

        if (index != -1)
        {
            diseases[index] = disease;
            await _dataService.SaveDiseasesAsync(diseases);
            _view.SetDiseases(diseases);
        }
    }

    public async Task DeleteDiseaseAsync(Guid id)
    {
        var diseases = await _dataService.GetDiseasesAsync();

        diseases.RemoveAll(d => d.Id == id);
        await _dataService.SaveDiseasesAsync(diseases);

        _view.SetDiseases(diseases);
    }
}