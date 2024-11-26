using PhysicianHandbook.Application.Models;

namespace PhysicianHandbook.Application.Events;

public class DiseaseEventArgs : EventArgs
{
    public Disease Disease { get; set; }
}