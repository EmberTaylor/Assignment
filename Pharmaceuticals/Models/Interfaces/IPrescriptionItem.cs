using System.ComponentModel;

namespace PharmaceuticalsApp.Models
{
    //set up so I can check if all the needed Properties and Methods exist
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