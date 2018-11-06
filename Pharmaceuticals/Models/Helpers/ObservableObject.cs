using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace System.ComponentModel
{
    public abstract class ObservableObject : PropertyValidateModel, INotifyPropertyChanged
    {
        public virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}