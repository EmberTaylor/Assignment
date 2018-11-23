using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace PharmaceuticalsApp.Models
{
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
                return PrescriptionItems.Select(p => p.PharmaceuticalName).Count();
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
            var oldItem = PrescriptionItems
                .Where(p => p.PharmaceuticalName == pharmaceuticalName)
                .FirstOrDefault();

            //if item not already in list add it
            if (oldItem == null)
            {
                PrescriptionItems.Add(new PrescriptionItem(pharmaceuticalName, prescribedDailyDose, duration,
                containerSize, availableOverTheCounter, comments));
                return;
            }
            
            //update the item
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