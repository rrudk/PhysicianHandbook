namespace PhysicianHandbook.Application.Views;

partial class MedicationView
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dataGridViewMedications;
    private ContextMenuStrip contextMenuMedications;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private GroupBox groupBoxAddMedication;
    private Label labelName;
    private TextBox textBoxName;
    private Label labelAlternatives;
    private CheckedListBox checkedListBoxAlternatives;
    private Button buttonAddMedication;

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
        this.components = new System.ComponentModel.Container();
        this.dataGridViewMedications = new System.Windows.Forms.DataGridView();
        this.contextMenuMedications = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.groupBoxAddMedication = new System.Windows.Forms.GroupBox();
        this.labelName = new System.Windows.Forms.Label();
        this.textBoxName = new System.Windows.Forms.TextBox();
        this.labelAlternatives = new System.Windows.Forms.Label();
        this.checkedListBoxAlternatives = new System.Windows.Forms.CheckedListBox();
        this.buttonAddMedication = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedications)).BeginInit();
        this.contextMenuMedications.SuspendLayout();
        this.groupBoxAddMedication.SuspendLayout();
        this.SuspendLayout();
        // 
        // dataGridViewMedications
        // 
        this.dataGridViewMedications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridViewMedications.Location = new System.Drawing.Point(10, 10);
        this.dataGridViewMedications.Name = "dataGridViewMedications";
        this.dataGridViewMedications.RowHeadersWidth = 51;
        this.dataGridViewMedications.RowTemplate.Height = 29;
        this.dataGridViewMedications.Size = new System.Drawing.Size(500, 500);
        this.dataGridViewMedications.TabIndex = 0;
        this.dataGridViewMedications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dataGridViewMedications.ContextMenuStrip = this.contextMenuMedications;
        // 
        // contextMenuMedications
        // 
        this.contextMenuMedications.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.contextMenuMedications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
        this.contextMenuMedications.Name = "contextMenuMedications";
        this.contextMenuMedications.Size = new System.Drawing.Size(181, 70);
        // 
        // editToolStripMenuItem
        // 
        this.editToolStripMenuItem.Name = "editToolStripMenuItem";
        this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
        this.editToolStripMenuItem.Text = "Редагувати";
        this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
        // 
        // deleteToolStripMenuItem
        // 
        this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
        this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
        this.deleteToolStripMenuItem.Text = "Видалити";
        this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
        // 
        // groupBoxAddMedication
        // 
        this.groupBoxAddMedication.Controls.Add(this.labelName);
        this.groupBoxAddMedication.Controls.Add(this.textBoxName);
        this.groupBoxAddMedication.Controls.Add(this.labelAlternatives);
        this.groupBoxAddMedication.Controls.Add(this.checkedListBoxAlternatives);
        this.groupBoxAddMedication.Controls.Add(this.buttonAddMedication);
        this.groupBoxAddMedication.Location = new System.Drawing.Point(520, 10);
        this.groupBoxAddMedication.Name = "groupBoxAddMedication";
        this.groupBoxAddMedication.Size = new System.Drawing.Size(500, 500);
        this.groupBoxAddMedication.TabIndex = 1;
        this.groupBoxAddMedication.TabStop = false;
        this.groupBoxAddMedication.Text = "Додати Медикамент";
        // 
        // labelName
        // 
        this.labelName.AutoSize = true;
        this.labelName.Location = new System.Drawing.Point(10, 30);
        this.labelName.Name = "labelName";
        this.labelName.Size = new System.Drawing.Size(63, 20);
        this.labelName.TabIndex = 0;
        this.labelName.Text = "Назва:";
        // 
        // textBoxName
        // 
        this.textBoxName.Location = new System.Drawing.Point(150, 27);
        this.textBoxName.Name = "textBoxName";
        this.textBoxName.Size = new System.Drawing.Size(200, 27);
        this.textBoxName.TabIndex = 1;
        // 
        // labelAlternatives
        // 
        this.labelAlternatives.AutoSize = true;
        this.labelAlternatives.Location = new System.Drawing.Point(10, 70);
        this.labelAlternatives.Name = "labelAlternatives";
        this.labelAlternatives.Size = new System.Drawing.Size(119, 20);
        this.labelAlternatives.TabIndex = 2;
        this.labelAlternatives.Text = "Альтернативи:";
        // 
        // checkedListBoxAlternatives
        // 
        this.checkedListBoxAlternatives.FormattingEnabled = true;
        this.checkedListBoxAlternatives.Location = new System.Drawing.Point(150, 70);
        this.checkedListBoxAlternatives.Name = "checkedListBoxAlternatives";
        this.checkedListBoxAlternatives.Size = new System.Drawing.Size(200, 124);
        this.checkedListBoxAlternatives.TabIndex = 3;
        // 
        // buttonAddMedication
        // 
        this.buttonAddMedication.Location = new System.Drawing.Point(150, 210);
        this.buttonAddMedication.Name = "buttonAddMedication";
        this.buttonAddMedication.Size = new System.Drawing.Size(200, 30);
        this.buttonAddMedication.TabIndex = 4;
        this.buttonAddMedication.Text = "Додати";
        this.buttonAddMedication.UseVisualStyleBackColor = true;
        this.buttonAddMedication.Click += new System.EventHandler(this.buttonAddMedication_Click);
        // 
        // MedicationView
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.Controls.Add(this.dataGridViewMedications);
        this.Controls.Add(this.groupBoxAddMedication);
        this.Name = "MedicationView";
        this.Size = new System.Drawing.Size(1030, 520);
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedications)).EndInit();
        this.contextMenuMedications.ResumeLayout(false);
        this.groupBoxAddMedication.ResumeLayout(false);
        this.groupBoxAddMedication.PerformLayout();
        this.ResumeLayout(false);
    }
}