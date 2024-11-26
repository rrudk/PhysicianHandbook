namespace PhysicianHandbook.Application;

partial class EditMedicationForm
{
    private System.ComponentModel.IContainer components = null;
    private Label labelName;
    private TextBox textBoxName;
    private Label labelAlternatives;
    private CheckedListBox checkedListBoxAlternatives;
    private Button buttonOK;
    private Button buttonCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.labelName = new System.Windows.Forms.Label();
        this.textBoxName = new System.Windows.Forms.TextBox();
        this.labelAlternatives = new System.Windows.Forms.Label();
        this.checkedListBoxAlternatives = new System.Windows.Forms.CheckedListBox();
        this.buttonOK = new System.Windows.Forms.Button();
        this.buttonCancel = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // labelName
        // 
        this.labelName.AutoSize = true;
        this.labelName.Location = new System.Drawing.Point(10, 20);
        this.labelName.Name = "labelName";
        this.labelName.Size = new System.Drawing.Size(63, 20);
        this.labelName.TabIndex = 0;
        this.labelName.Text = "Назва:";
        // 
        // textBoxName
        // 
        this.textBoxName.Location = new System.Drawing.Point(100, 17);
        this.textBoxName.Name = "textBoxName";
        this.textBoxName.Size = new System.Drawing.Size(250, 27);
        this.textBoxName.TabIndex = 1;
        // 
        // labelAlternatives
        // 
        this.labelAlternatives.AutoSize = true;
        this.labelAlternatives.Location = new System.Drawing.Point(10, 60);
        this.labelAlternatives.Name = "labelAlternatives";
        this.labelAlternatives.Size = new System.Drawing.Size(119, 20);
        this.labelAlternatives.TabIndex = 2;
        this.labelAlternatives.Text = "Альтернативи:";
        // 
        // checkedListBoxAlternatives
        // 
        this.checkedListBoxAlternatives.FormattingEnabled = true;
        this.checkedListBoxAlternatives.Location = new System.Drawing.Point(100, 60);
        this.checkedListBoxAlternatives.Name = "checkedListBoxAlternatives";
        this.checkedListBoxAlternatives.Size = new System.Drawing.Size(250, 124);
        this.checkedListBoxAlternatives.TabIndex = 3;
        // 
        // buttonOK
        // 
        this.buttonOK.Location = new System.Drawing.Point(100, 200);
        this.buttonOK.Name = "buttonOK";
        this.buttonOK.Size = new System.Drawing.Size(100, 30);
        this.buttonOK.TabIndex = 4;
        this.buttonOK.Text = "Зберегти";
        this.buttonOK.UseVisualStyleBackColor = true;
        this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
        // 
        // buttonCancel
        // 
        this.buttonCancel.Location = new System.Drawing.Point(250, 200);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new System.Drawing.Size(100, 30);
        this.buttonCancel.TabIndex = 5;
        this.buttonCancel.Text = "Відмінити";
        this.buttonCancel.UseVisualStyleBackColor = true;
        this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
        // 
        // EditMedicationForm
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.ClientSize = new System.Drawing.Size(380, 250);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonOK);
        this.Controls.Add(this.checkedListBoxAlternatives);
        this.Controls.Add(this.labelAlternatives);
        this.Controls.Add(this.textBoxName);
        this.Controls.Add(this.labelName);
        this.Name = "EditMedicationForm";
        this.Text = "Редагувати Медикамент";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}