using PhysicianHandbook.Application.Models;

namespace PhysicianHandbook.Application.Views.Interfaces;

public interface IPrescriptionView
{
    void SetPrescriptions(List<Prescription> prescriptions);
}