using PhysicianHandbook.Application.Events;
using PhysicianHandbook.Application.Models;
using PhysicianHandbook.Application.Models.Enums;
using PhysicianHandbook.Application.Views.Interfaces;
using System.ComponentModel;

namespace PhysicianHandbook.Application.Views;

public partial class DiseaseView : UserControl, IDiseaseView
{
    private List<Medication> _availableMedications = new List<Medication>();
    private BindingList<MedicationDetail> _medicationDetails = new BindingList<MedicationDetail>();

    public event EventHandler<DiseaseEventArgs> AddDiseaseRequested;

    public DiseaseView()
    {
        InitializeComponent();
        dataGridViewDiseases.AutoGenerateColumns = false;
        InitializeDataGridViewDiseases();
        InitializeDataGridViewMedicationDetails();
    }

    private void InitializeDataGridViewDiseases()
    {
        dataGridViewDiseases.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Name",
            HeaderText = "Назва"
        });

        dataGridViewDiseases.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Symptoms",
            HeaderText = "Симптоми"
        });

        dataGridViewDiseases.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Procedures",
            HeaderText = "Процедури"
        });

        dataGridViewDiseases.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "MedicationsSummary",
            HeaderText = "Медикаменти"
        });
    }

    private void InitializeDataGridViewMedicationDetails()
    {
        dataGridViewMedicationDetails.AutoGenerateColumns = false;
        dataGridViewMedicationDetails.DataSource = _medicationDetails;

        dataGridViewMedicationDetails.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "MedicationName",
            HeaderText = "Медикамент",
            ReadOnly = true
        });

        dataGridViewMedicationDetails.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Quantity",
            HeaderText = "Кількість"
        });

        var unitColumn = new DataGridViewComboBoxColumn
        {
            DataPropertyName = "Unit",
            HeaderText = "Одиниця",
            DataSource = Enum.GetValues(typeof(UnitType)),
            FlatStyle = FlatStyle.Flat
        };
        dataGridViewMedicationDetails.Columns.Add(unitColumn);
    }

    public void LoadAvailableMedications(List<Medication> medications)
    {
        _availableMedications = medications;
        listBoxMedications.DataSource = _availableMedications;
        listBoxMedications.DisplayMember = "Name";
        listBoxMedications.ValueMember = "Id";
    }

    public void SetDiseases(List<Disease> diseases)
    {
        dataGridViewDiseases.DataSource = null;
        dataGridViewDiseases.DataSource = diseases;
    }

    public void ClearInputFields()
    {
        textBoxName.Clear();
        textBoxSymptoms.Clear();
        textBoxProcedures.Clear();
        _medicationDetails.Clear();
    }

    private void buttonAddMedication_Click(object sender, EventArgs e)
    {
        var selectedMedications = listBoxMedications.SelectedItems.Cast<Medication>().ToList();
        foreach (var med in selectedMedications)
        {
            if (!_medicationDetails.Any(m => m.Medication.Id == med.Id))
            {
                var detail = new MedicationDetail
                {
                    Medication = med,
                    Quantity = 1,
                    Unit = UnitType.Шт
                };
                _medicationDetails.Add(detail);
            }
        }
    }

    private void buttonSaveDisease_Click(object sender, EventArgs e)
    {
        var name = textBoxName.Text.Trim();
        var symptoms = textBoxSymptoms.Text.Trim();
        var procedures = textBoxProcedures.Text.Trim();

        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Введіть назву хвороби.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_medicationDetails.Count == 0)
        {
            MessageBox.Show("Додайте хоча б один медикамент.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var newDisease = new Disease
        {
            Name = name,
            Symptoms = symptoms,
            Procedures = procedures,
            Medications = _medicationDetails.ToList()
        };

        AddDiseaseRequested?.Invoke(this, new DiseaseEventArgs { Disease = newDisease });

        ClearInputFields();

        MessageBox.Show("Хворобу успішно додано.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}