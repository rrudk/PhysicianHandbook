using PhysicianHandbook.Application.Models;
using System.Windows.Forms;

namespace PhysicianHandbook.Application;

public partial class EditMedicationForm : Form
{
    public Medication Medication { get; private set; }

    public EditMedicationForm(Medication medication, List<Medication> allMedications)
    {
        InitializeComponent();
        // Клонуємо медикамент для уникнення безпосередніх змін
        Medication = new Medication
        {
            Id = medication.Id,
            Name = medication.Name,
            Alternatives = new List<Medication>(medication.Alternatives)
        };
        PopulateFields(allMedications);
    }

    private void PopulateFields(List<Medication> allMedications)
    {
        textBoxName.Text = Medication.Name;

        // Заповнюємо CheckedListBox всіма медикаментами, крім поточного, щоб уникнути циклічних посилань
        var availableMedications = allMedications
            .Where(m => m.Id != Medication.Id)
            .OrderBy(m => m.Name)
            .ToList();

        checkedListBoxAlternatives.Items.Clear();
        foreach (var med in availableMedications)
        {
            bool isChecked = Medication.Alternatives.Any(a => a.Id == med.Id);
            checkedListBoxAlternatives.Items.Add(med, isChecked);
        }
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
        string name = textBoxName.Text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Назва медикаменту не може бути порожньою.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Medication.Name = name;
        Medication.Alternatives.Clear();

        foreach (var checkedItem in checkedListBoxAlternatives.CheckedItems)
        {
            if (checkedItem is Medication med)
            {
                Medication.Alternatives.Add(med);
            }
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}