using System.Collections.ObjectModel;

namespace PharmaceuticalsApp.Models
{
    public interface IPrescription
    {
        int NumberOfContainers { get; }
        int NumberOfPharmaceuticals { get; }
        ObservableCollection<IPrescriptionItem> PrescriptionItems { get; }

        void AddPrescriptionItem(string pharmaceuticalName, int prescribedDailyDose, int duration, int containerSize, bool? availableOverTheCounter, string comments);
        void ClearPrescription();
        void RemovePrescriptionItem(string pharmaceuticalName);
    }
}