using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace FearlessFlight.XForms.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RelayCommand _showIntroductionCommand;
        private RelayCommand _showFlightStageCommand;
        private RelayCommand _showGroundSchoolCommand;
        private RelayCommand _showTechniquesCommand;
        private RelayCommand _showPracticeFlightCommand;
        private RelayCommand _showAboutCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public MainViewModel(INavigationService navigationService)
        {
            Debug.WriteLine("MainViewModel constructor");

            _navigationService = navigationService;
        }

        /// <summary>
        /// Gets the show introduction command.
        /// </summary>
        /// <value>
        /// The show introduction command.
        /// </value>
        public RelayCommand ShowIntroductionCommand
        {
            get
            {
                return _showIntroductionCommand
                    ?? (_showIntroductionCommand = new RelayCommand(
                        () =>
                        {
                            _navigationService.NavigateTo(ViewModelLocator.IntroductionPageKey);
                        }));
            }
        }

        /// <summary>
        /// Gets the show flight stage command.
        /// </summary>
        /// <value>
        /// The show flight stage command.
        /// </value>
        public RelayCommand ShowFlightStageCommand
        {
            get
            {
                return _showFlightStageCommand
                    ?? (_showFlightStageCommand = new RelayCommand(
                        () =>
                        {
                            _navigationService.NavigateTo(ViewModelLocator.FlightStagePageKey);
                        }));
            }
        }

        /// <summary>
        /// Gets the show ground school command.
        /// </summary>
        /// <value>
        /// The show ground school command.
        /// </value>
        public RelayCommand ShowGroundSchoolCommand
        {
            get
            {
                return _showGroundSchoolCommand
                    ?? (_showGroundSchoolCommand = new RelayCommand(
                        () =>
                        {
                            _navigationService.NavigateTo(ViewModelLocator.GroundSchoolPageKey);
                        }));
            }
        }

        /// <summary>
        /// Gets the show techniques command.
        /// </summary>
        /// <value>
        /// The show techniques command.
        /// </value>
        public RelayCommand ShowTechniquesCommand
        {
            get
            {
                return _showTechniquesCommand
                    ?? (_showTechniquesCommand = new RelayCommand(
                        () =>
                        {
                            _navigationService.NavigateTo(ViewModelLocator.TechniquesPageKey);
                        }));
            }
        }

        /// <summary>
        /// Gets the show practice flight command.
        /// </summary>
        /// <value>
        /// The show practice flight command.
        /// </value>
        public RelayCommand ShowPracticeFlightCommand
        {
            get
            {
                return _showPracticeFlightCommand
                    ?? (_showPracticeFlightCommand = new RelayCommand(
                        () =>
                        {
                            _navigationService.NavigateTo(ViewModelLocator.PracticeFlightPageKey);
                        }));
            }
        }

        /// <summary>
        /// Gets the show settings command.
        /// </summary>
        /// <value>
        /// The show settings command.
        /// </value>
        public RelayCommand ShowAboutCommand
        {
            get
            {
                return _showAboutCommand
                    ?? (_showAboutCommand = new RelayCommand(
                        () =>
                        {
                            _navigationService.NavigateTo(ViewModelLocator.AboutPageKey);
                        }));
            }
        }
    }
}
