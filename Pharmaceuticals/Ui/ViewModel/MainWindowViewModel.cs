using PharmaceuticalsApp.Entities;
using PharmaceuticalsApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;

namespace PharmaceuticalsApp.Ui.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private IViewModel currentViewModel;
        public IViewModel CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                if (currentViewModel != value)
                {
                    currentViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICollection<IViewModel> viewModels = new List<IViewModel>();
        public  ICollection<IViewModel> ViewModels
        {
            get
            {
                return viewModels;
            }
            set
            {
                if (viewModels != value)
                {
                    viewModels = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand _changePageCommand;
        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((Type)p),
                        p => p is Type);
                }

                return _changePageCommand;
            }
        }

        private readonly IPharmaceuticalRepository pharmaceuticalRepository;
        private readonly ISpecialRequirementRepository specialRequirementRepository;

        public MainWindowViewModel()
        {
            var context = new Context();

            pharmaceuticalRepository = new PharmaceuticalRepository(context);
            specialRequirementRepository = new SpecialRequirementRepository(context);

            ChangeViewModel(typeof(MainViewModel));
    }

        private void ChangeViewModel(Type viewModelType)
        {
            if (!typeof(IViewModel).IsAssignableFrom(viewModelType))
            {
                throw new ArgumentException("Not a valid view model type");
            }

            //check if already on this viewModelType
            if (viewModelType.IsAssignableFrom(this.currentViewModel?.GetType()))
            {
                return;
            }

            //check if viewModelType already in memory
            var viewModelFromMemory = ViewModels.Where(v => v.GetType() == viewModelType).FirstOrDefault();

            if (viewModelFromMemory == null)
            {
                //get new viewmodel;
                viewModelFromMemory = GetViewViewModel(viewModelType);

                //add to memory
                ViewModels.Add(viewModelFromMemory);
            }

            this.currentViewModel = viewModelFromMemory;
        }

        //no dependency injection conver to factory
        private IViewModel GetViewViewModel(Type viewModelType)
        {
            if (viewModelType == typeof(MainViewModel))
            {
                return new MainViewModel(pharmaceuticalRepository);
            }
            throw new ArgumentException("View model type not found");
        }
    }
}