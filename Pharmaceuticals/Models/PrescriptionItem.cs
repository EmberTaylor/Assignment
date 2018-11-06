using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PharmaceuticalsApp.Models
{
    public class PrescriptionItem : ObservableObject, IPrescriptionItem
    {
        [Required]
        public string PharmaceuticalName { get; private set; }

        private int prescribedDailyDose;
        [Range(1, int.MaxValue)]
        public int PrescribedDailyDose
        {
            get
            {
                return prescribedDailyDose;
            }
            set
            {
                if (prescribedDailyDose != value)
                {
                    prescribedDailyDose = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NumberOfContainers));
                }
            }
        }

        private int duration;
        [Range(1, int.MaxValue)]
        public int Duration
        {
            get
            {
                return duration;
            }
            private set
            {
                if (duration != value)
                {
                    duration = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NumberOfContainers));
                }
            }
        }

        [Range(1, int.MaxValue)]
        public int ContainerSize { get; private set; }

        public bool? AvailableOverTheCounter { get; private set; }

        public string Comments { get; private set; }

        public int NumberOfContainers
        {
            get
            {
                var number = (int)Math.Ceiling((PrescribedDailyDose * Duration) / (double)ContainerSize);
                return number <= 0 ? 1 : number;
            }
        }

        public PrescriptionItem(string pharmaceuticalName, int prescribedDailyDose, int duration, 
            int containerSize, bool? availableOverTheCounter, string comments)
        {
            PharmaceuticalName = pharmaceuticalName;
            PrescribedDailyDose = prescribedDailyDose;
            Duration = duration;
            ContainerSize = containerSize;
            AvailableOverTheCounter = availableOverTheCounter;
            Comments = comments;
        }

        public void UpdateDuration(int additionalDays)
        {
            Duration += additionalDays;
        }
    }
}
