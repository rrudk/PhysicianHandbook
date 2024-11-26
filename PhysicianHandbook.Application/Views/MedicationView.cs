using PhysicianHandbook.Application.Events;
using PhysicianHandbook.Application.Models;
using PhysicianHandbook.Application.Views.Interfaces;

namespace PhysicianHandbook.Application.Views;

public partial class MedicationView : UserControl, IMedicationView
{
    public event EventHandler<MedicationEventArgs> AddMedicationRequested;
    public event EventHandler<Guid> DeleteMedicationRequested;
    public event EventHandler<MedicationEventArgs> EditMedicationRequested;

    private List<Medication> _allMedications = [];

    public MedicationView()
    {
        InitializeComponent();
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridViewMedications.SelectedRows.Count > 0)
        {
            var selectedMedication = dataGridViewMedications.SelectedRows[0].DataBoundItem as Medication;

            if (selectedMedication != null)
            {
                using (var editForm = new EditMedicationForm(selectedMedication, _allMedications))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        var editedMedication = editForm.Medication;

                        EditMedicationRequested?.Invoke(this, new MedicationEventArgs { Medication = editedMedication });
                    }
                }
            }
        }
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridViewMedications.SelectedRows.Count > 0)
        {
            var selectedMedication = dataGridViewMedications.SelectedRows[0].DataBoundItem as Medication;
            if (selectedMedication != null)
            {
                var result = MessageBox.Show($"Ви впевнені, що хочете видалити медикамент '{selectedMedication.Name}'?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteMedicationRequested?.Invoke(this, selectedMedication.Id);
                }
            }
        }
    }

    private void buttonAddMedication_Click(object sender, EventArgs e)
    {
        var name = textBoxName.Text.Trim();

        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Введіть назву медикаменту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var selectedAlternatives = checkedListBoxAlternatives.CheckedItems.Cast<Medication>().ToList();

        var newMedication = new Medication
        {
            Name = name,
            Alternatives = selectedAlternatives
        };

        AddMedicationRequested?.Invoke(this, new MedicationEventArgs { Medication = newMedication });

        ClearInputFields();

        MessageBox.Show("Медикамент успішно додано.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void SetMedications(List<Medication> medications)
    {
        dataGridViewMedications.DataSource = null;
        dataGridViewMedications.DataSource = medications;

        _allMedications = medications;

        var sortedMedications = medications.OrderBy(m => m.Name).ToList();
        checkedListBoxAlternatives.Items.Clear();
        foreach (var med in sortedMedications)
        {
            checkedListBoxAlternatives.Items.Add(med, false);
        }
    }

    public void SetAllMedications(List<Medication> medications)
    {
        _allMedications = medications;

        var sortedMedications = medications.OrderBy(m => m.Name).ToList();
        checkedListBoxAlternatives.Items.Clear();
        foreach (var med in sortedMedications)
        {
            checkedListBoxAlternatives.Items.Add(med, false);
        }
    }

    public void ClearInputFields()
    {
        textBoxName.Clear();

        for (var i = 0; i < checkedListBoxAlternatives.Items.Count; i++)
        {
            checkedListBoxAlternatives.SetItemChecked(i, false);
        }
    }
}