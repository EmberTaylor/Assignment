using System;
using System.ComponentModel;

namespace PharmaceuticalsApp.Ui.ViewModel
{
    public class CommentViewModel : ObservableObject, IViewModel
    {
        public Type ReturnPage
        {
            get
            {
                return typeof(MainViewModel);
            }
        }

        private string comment;
        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                if (comment != value)
                {
                    comment = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
