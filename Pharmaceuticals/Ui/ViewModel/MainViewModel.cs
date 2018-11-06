﻿using PharmaceuticalsApp.Entities;
using PharmaceuticalsApp.Models;
using PharmaceuticalsApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;

namespace PharmaceuticalsApp.Ui.ViewModel
{
    public class MainViewModel : ObservableObject, IViewModel
    {
        private ICommand addButton;
        public ICommand AddButton
        {
            get
            {
                if (addButton == null)
                {
                    addButton = new RelayCommand
                    (
                        r => AddPharmaceutical(),
                        r => SelectedPharmaceutical != null &&
                             TryValidate() &&
                             ((recomendOverride &&
                             prescribedDailyDose <= SelectedPharmaceutical.RecommendedDailyDose * 2) ||
                             PrescribedDailyDose <= SelectedPharmaceutical.RecommendedDailyDose)
                    );
                }
                return addButton;
            }
        }

        private ICommand removeButton;
        public ICommand RemoveButton
        {
            get
            {
                if (removeButton == null)
                {
                    removeButton = new RelayCommand
                    (
                        r => Remove(),
                        r => SelectedPrescriptionItem != null
                    );
                }
                return removeButton;
            }
        }

        private ICommand clearButton;
        public ICommand ClearButton
        {
            get
            {
                if (clearButton == null)
                {
                    clearButton = new RelayCommand
                    (
                        r => Clear(),
                        r => Prescription.NumberOfPharmaceuticals > 0
                    );
                }
                return clearButton;
            }
        }

        private ICommand exitButton;
        public ICommand ExitButton
        {
            get
            {
                if (exitButton == null)
                {
                    exitButton = new RelayCommand
                    (
                        r => Exit()
                    );
                }
                return exitButton;
            }
        }

        private IEnumerable<Pharmaceutical> pharmaceuticals;
        public IEnumerable<Pharmaceutical> Pharmaceuticals
        {
            get
            {
                return pharmaceuticals;
            }
            set
            {
                if (pharmaceuticals != value)
                {
                    pharmaceuticals = value;
                    OnPropertyChanged();
                }
            }
        }

        private Pharmaceutical selectedPharmaceutical;
        [Required(ErrorMessage ="Please select")]
        public Pharmaceutical SelectedPharmaceutical
        {
            get
            {
                return selectedPharmaceutical;
            }
            set
            {
                if (selectedPharmaceutical != value)
                {
                    selectedPharmaceutical = value;
                    PrescribedDailyDose = Convert.ToInt32(selectedPharmaceutical?.RecommendedDailyDose);
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DisplayRddOverride));
                }
            }
        }

        private IPrescription prescription = new Prescription();
        public IPrescription Prescription
        {
            get
            {
                return prescription;
            }
            set
            {
                if (prescription != value)
                {
                    prescription = value;
                    OnPropertyChanged();
                }
            }
        } 

        private IPrescriptionItem selectedPrescriptionItem;
        public IPrescriptionItem SelectedPrescriptionItem
        {
            get
            {
                return selectedPrescriptionItem;
            }
            set
            {
                if (selectedPrescriptionItem != value)
                {
                    selectedPrescriptionItem = value;
                    OnPropertyChanged();
                }
            }
        }

        private int prescribedDailyDose;
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter a Value")]
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
                    OnPropertyChanged(nameof(DisplayRddOverride));
                }
            }
        }

        private bool recomendOverride;
        public bool RecomendOverride
        {
            get
            {
                return recomendOverride;
            }
            set
            {
                if (recomendOverride != value)
                {
                    recomendOverride = value;
                    OnPropertyChanged();

                    if (recomendOverride)
                    {
                        AddComment = true;
                    }
                }
            }
        }

        private bool addComment;
        public bool AddComment
        {
            get
            {
                return addComment;
            }
            set
            {
                if (addComment != value)
                {
                    addComment = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool DisplayRddOverride
        {
            get
            {
                var display = prescribedDailyDose > SelectedPharmaceutical?.RecommendedDailyDose &&
                              prescribedDailyDose <= SelectedPharmaceutical?.RecommendedDailyDose * 2;

                if (!display)
                {
                    RecomendOverride = false;
                }
                return display;
            }
        }

        private int duration;
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter a Value")]
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (duration != value)
                {
                    duration = value;
                    OnPropertyChanged();
                }
            }
        }

        private readonly IPharmaceuticalRepository pharmaceuticalRepository;

        public MainViewModel(IPharmaceuticalRepository pharmaceuticalRepository)
        {
            this.pharmaceuticalRepository = pharmaceuticalRepository;
            Pharmaceuticals = this.pharmaceuticalRepository.Get();
        }

        private void AddPharmaceutical()
        {
            if (SelectedPharmaceutical == null)
            {
                throw new NullReferenceException("No Pharmaceutical selected to add to Prescription");
            }

            Prescription.AddPrescriptionItem
            (
                SelectedPharmaceutical.PharmaceuticalName,
                PrescribedDailyDose,
                Duration,
                SelectedPharmaceutical.SpecialRequirement.ContainerSize,
                SelectedPharmaceutical.SpecialRequirement.AvailableOverTheCounter,
                SelectedPharmaceutical.FormattedDescription
            );
            OnPropertyChanged(nameof(Prescription));
            OnPropertyChanged(nameof(Prescription.PrescriptionItems));
            ClearUi();
        }

        private void Remove()
        {
            if (SelectedPrescriptionItem == null)
            {
                throw new NullReferenceException("No PrescriptionItem selected to remove from Prescription");
            }

            Prescription.RemovePrescriptionItem(SelectedPrescriptionItem.PharmaceuticalName);
            OnPropertyChanged(nameof(Prescription));
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private void Clear()
        {
            Prescription.ClearPrescription();
            OnPropertyChanged(nameof(Prescription));
            ClearUi();
        }

        private void ClearUi()
        {
            SelectedPrescriptionItem = null;
            SelectedPharmaceutical = null;
            PrescribedDailyDose = 0;
            Duration = 0;
            RecomendOverride = false;
            AddComment = false;
        }
    }
}