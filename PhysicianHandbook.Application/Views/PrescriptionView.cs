using PhysicianHandbook.Application.Models;
using PhysicianHandbook.Application.Views.Interfaces;

namespace PhysicianHandbook.Application.Views;

public partial class PrescriptionView : UserControl, IPrescriptionView
{
    private DataGridView dataGridViewPrescriptions;

    public PrescriptionView()
    {
        InitializeComponent();
        InitializePrescriptionForm();
    }

    public void SetPrescriptions(List<Prescription> prescriptions)
    {
        dataGridViewPrescriptions.DataSource = null;
        dataGridViewPrescriptions.AutoGenerateColumns = false;
        dataGridViewPrescriptions.Columns.Clear();
        InitializeDataGridViewColumns();
        dataGridViewPrescriptions.DataSource = prescriptions;
    }

    private void InitializeDataGridViewColumns()
    {
        var idColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Id",
            HeaderText = "Ідентифікатор",
            ReadOnly = true
        };
        dataGridViewPrescriptions.Columns.Add(idColumn);

        var patientColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Patient",
            HeaderText = "Пацієнт"
        };
        dataGridViewPrescriptions.Columns.Add(patientColumn);

        var medicationsColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "MedicationsSummary",
            HeaderText = "Медикаменти",
            ReadOnly = true
        };
        dataGridViewPrescriptions.Columns.Add(medicationsColumn);
    }

    private void InitializePrescriptionForm()
    {
        var labelPatient = new Label
        {
            Text = "Пацієнт:",
            Location = new Point(10, 10),
            AutoSize = true
        };
        var textBoxPatient = new TextBox
        {
            Location = new Point(100, 10),
            Width = 200
        };

        var labelMedications = new Label
        {
            Text = "Медикаменти:",
            Location = new Point(10, 50),
            AutoSize = true
        };
        var listBoxMedications = new ListBox
        {
            Location = new Point(100, 50),
            Width = 200,
            Height = 100
        };

        var buttonSave = new Button
        {
            Text = "Зберегти рецепт",
            Location = new Point(100, 170),
            Width = 150
        };

        dataGridViewPrescriptions = new DataGridView
        {
            Location = new Point(10, 210),
            Width = 480,
            Height = 200,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            AllowUserToAddRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };

        Controls.Add(labelPatient);
        Controls.Add(textBoxPatient);
        Controls.Add(labelMedications);
        Controls.Add(listBoxMedications);
        Controls.Add(buttonSave);
        Controls.Add(dataGridViewPrescriptions);
    }
}