using System.ComponentModel;

namespace PharmaceuticalsApp.Models
{
    public interface IPrescriptionItem : INotifyPropertyChanged
    {
        bool? AvailableOverTheCounter { get; }
        string Comments { get; }
        int ContainerSize { get; }
        int Duration { get; }
        int NumberOfContainers { get; }
        string PharmaceuticalName { get; }
        int PrescribedDailyDose { get; set; }

        void UpdateDuration(int additionalDays);
    }
}