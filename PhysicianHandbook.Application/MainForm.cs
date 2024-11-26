using Microsoft.Extensions.DependencyInjection;
using PhysicianHandbook.Application.Presenters;
using PhysicianHandbook.Application.Views;
using PhysicianHandbook.Application.Views.Interfaces;

namespace PhysicianHandbook.Application;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;

    public MainForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        InitializeTabs();
    }

    private void InitializeTabs()
    {
        var tabDiseases = new TabPage("Хвороби");
        var tabMedications = new TabPage("Медикаменти");
        var tabPrescription = new TabPage("Рецепти");

        var diseaseView = _serviceProvider.GetRequiredService<IDiseaseView>() as DiseaseView;
        var medicationView = _serviceProvider.GetRequiredService<IMedicationView>() as MedicationView;
        var prescriptionView = _serviceProvider.GetRequiredService<IPrescriptionView>() as PrescriptionView;

        diseaseView.Dock = DockStyle.Fill;
        medicationView.Dock = DockStyle.Fill;
        prescriptionView.Dock = DockStyle.Fill;

        tabDiseases.Controls.Add(diseaseView);
        tabMedications.Controls.Add(medicationView);
        tabPrescription.Controls.Add(prescriptionView);

        tabControlMain.TabPages.Add(tabDiseases);
        tabControlMain.TabPages.Add(tabMedications);
        tabControlMain.TabPages.Add(tabPrescription);

        _serviceProvider.GetRequiredService<DiseasePresenter>();
        _serviceProvider.GetRequiredService<MedicationPresenter>();
        _serviceProvider.GetRequiredService<PrescriptionPresenter>();
    }
}