using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace PharmaceuticalsApp.Models
{
    //todo
    //Note any particular pharmaceutical should only appear in the prescription once.
    //If there is a pharmaceutical already in the prescription 
    //and the practitioner tries to add the same thing again, 
    //the new duration should be added to the existing entry’s duration 
    //and the prescribed daily dose should be either the 
    //PrescriptionItem’s PrescribedDailyDose or the value of the control used by the 
    //practitioner to select the Prescribed Daily Dose, whichever is the greater.

    public class Prescription : ObservableObject, IPrescription
    {
        private ObservableCollection<IPrescriptionItem> prescriptionItems
            = new ObservableCollection<IPrescriptionItem>();
        public ObservableCollection<IPrescriptionItem> PrescriptionItems
        {
            get
            {
                return prescriptionItems;
            }
            private set
            {
                if (prescriptionItems != value)
                {
                    prescriptionItems = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NumberOfPharmaceuticals));
                    OnPropertyChanged(nameof(NumberOfContainers));
                }
            }
        }
           

        public int NumberOfPharmaceuticals
        {
            get
            {
                return PrescriptionItems.Select(p => p.PharmaceuticalName).Distinct().Count();
            }
        }

        public int NumberOfContainers
        {
            get
            {
                return PrescriptionItems.Sum(p => p.NumberOfContainers);
            }
        }

        public void AddPrescriptionItem(string pharmaceuticalName, int prescribedDailyDose, int duration,
            int containerSize, bool? availableOverTheCounter, string comments)
        {

            if (!PrescriptionItems.Any(p => p.PharmaceuticalName == pharmaceuticalName))
            {
                PrescriptionItems.Add(new PrescriptionItem(pharmaceuticalName, prescribedDailyDose, duration,
                containerSize, availableOverTheCounter, comments));
                return;
            }

            var oldItem = PrescriptionItems
                .Where(p => p.PharmaceuticalName == pharmaceuticalName)
                .FirstOrDefault();

            oldItem.UpdateDuration(duration);

            oldItem.PrescribedDailyDose = oldItem.PrescribedDailyDose > prescribedDailyDose ?
                oldItem.PrescribedDailyDose : prescribedDailyDose;

        }

        public void RemovePrescriptionItem(string pharmaceuticalName)
        {
            PrescriptionItems.Remove
            (
                PrescriptionItems.Where(p => p.PharmaceuticalName == pharmaceuticalName).FirstOrDefault()
            );
        }

        public void ClearPrescription()
        {
            PrescriptionItems = new ObservableCollection<IPrescriptionItem>();
        }
    }
}