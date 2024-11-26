using PhysicianHandbook.Application.Models;
using PhysicianHandbook.Application.Services.Interfaces;
using PhysicianHandbook.Application.Views.Interfaces;

namespace PhysicianHandbook.Application.Presenters;

public class PrescriptionPresenter
{
    private readonly IPrescriptionView _view;
    private readonly IDataService _dataService;

    public PrescriptionPresenter(IPrescriptionView view, IDataService dataService)
    {
        _view = view;
        _dataService = dataService;

        LoadPrescriptions();
    }

    private async void LoadPrescriptions()
    {
        var prescriptions = await _dataService.GetPrescriptionsAsync();

        _view.SetPrescriptions(prescriptions);
    }

    public async Task AddPrescriptionAsync(Prescription prescription)
    {
        var prescriptions = await _dataService.GetPrescriptionsAsync();
        prescriptions.Add(prescription);

        await _dataService.SavePrescriptionsAsync(prescriptions);
        _view.SetPrescriptions(prescriptions);
    }

    public async Task UpdatePrescriptionAsync(Prescription prescription)
    {
        var prescriptions = await _dataService.GetPrescriptionsAsync();
        var index = prescriptions.FindIndex(p => p.Id == prescription.Id);

        if (index != -1)
        {
            prescriptions[index] = prescription;
            await _dataService.SavePrescriptionsAsync(prescriptions);
            _view.SetPrescriptions(prescriptions);
        }
    }

    public async Task DeletePrescriptionAsync(int id)
    {
        var prescriptions = await _dataService.GetPrescriptionsAsync();
        prescriptions.RemoveAll(p => p.Id == id);

        await _dataService.SavePrescriptionsAsync(prescriptions);
        _view.SetPrescriptions(prescriptions);
    }
}