namespace PhysicianHandbook.Application.Views;

partial class PrescriptionView
{
    private System.ComponentModel.IContainer components = null;

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
        this.SuspendLayout();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.Name = "PrescriptionView";
        this.Size = new System.Drawing.Size(500, 250);
        this.ResumeLayout(false);
    }
}
