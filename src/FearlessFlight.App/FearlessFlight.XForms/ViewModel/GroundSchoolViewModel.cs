using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Diagnostics;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using FearlessFlight.XForms.Models;
using FearlessFlight.XForms.Resx;
using Microsoft.Practices.ServiceLocation;
using FearlessFlight.XForms.Helpers;
using FearlessFlight.XForms.Views.GroundSchool;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace FearlessFlight.XForms.ViewModel
{
    public class GroundSchoolViewModel : ViewModelBase
    {
        private ObservableCollection<GroundSchoolModel> _groundschoolLessons;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroundSchoolViewModel" /> class.
        /// </summary>
        public GroundSchoolViewModel()
        {
            _groundschoolLessons = StaticHelper.GroundschoolItems;
        }

        //private async void SetupItems()
        //{
        //    string path = @"images\ground_school\";

        //    if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
        //        path = "";


        //    GroundSchoolLessons = new ObservableCollection<GroundSchoolModel>();
        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_01_airline_safety_title,
        //        ImageFilename = $"{path}safety.jpg",
        //        GroundSchoolType = GroundSchoolModule.Safety
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_02_meet_the_pilots_title,
        //        ImageFilename = $"{path}meet_the_pilots.jpg",
        //        GroundSchoolType = GroundSchoolModule.MeetThePilots
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_03_security_title,
        //        ImageFilename = $"{path}security.jpg",
        //        GroundSchoolType = GroundSchoolModule.Security
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_04_deicing_title,
        //        ImageFilename = $"{path}de_icing.jpg",
        //        GroundSchoolType = GroundSchoolModule.DeIcing
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_05_taxi_title,
        //        ImageFilename = $"{path}taxi.jpg",
        //        GroundSchoolType = GroundSchoolModule.Taxi
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_06_takeoff_title,
        //        ImageFilename = $"{path}take_off.png",
        //        GroundSchoolType = GroundSchoolModule.Takeoff
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_07_cruise_title,
        //        ImageFilename = $"{path}cruise.jpg",
        //        GroundSchoolType = GroundSchoolModule.Cruise
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_08_turbulence_title,
        //        ImageFilename = $"{path}turbulence.jpg",
        //        GroundSchoolType = GroundSchoolModule.Turbulence
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_09_lightning_title,
        //        ImageFilename = $"{path}lightning.png",
        //        GroundSchoolType = GroundSchoolModule.Lightning
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_10_engines_title,
        //        ImageFilename = $"{path}engines.png",
        //        GroundSchoolType = GroundSchoolModule.Engines
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_11_clouds_title,
        //        ImageFilename = $"{path}clouds.jpg",
        //        GroundSchoolType = GroundSchoolModule.Clouds
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_12_approach_and_landing_title,
        //        ImageFilename = $"{path}approach_and_landing.jpg",
        //        GroundSchoolType = GroundSchoolModule.ApproachAndLanding
        //    });

        //    GroundSchoolLessons.Add(new GroundSchoolModel()
        //    {
        //        Title = AppResources.groundschool_13_customs_title,
        //        ImageFilename = $"{path}customs.jpg",
        //        GroundSchoolType = GroundSchoolModule.Customs
        //    });
        //}

        private GroundSchoolModel _Selected;

        public GroundSchoolModel Selected
        {
            get { return _Selected; }
            set {
                _Selected = value;

                if(value!=null)
                {
                    var t = value;
                }

            }
        }


        /// <summary>
        /// Gets or sets the ground school lessons.
        /// </summary>
        /// <value>
        /// The ground school lessons.
        /// </value>
        public ObservableCollection<GroundSchoolModel> GroundSchoolLessons
        {
            get
            {
                if (_groundschoolLessons == null)
                {
                    _groundschoolLessons = new ObservableCollection<GroundSchoolModel>();
                }
                return _groundschoolLessons;
            }
            set
            {
                if (_groundschoolLessons != null)
                {
                    Set <ObservableCollection<GroundSchoolModel>>(ref _groundschoolLessons, value, "GroundSchoolLessons");
                }
            }
        }

        /// <summary>
        /// Gets the show ground school command.
        /// </summary>
        /// <value>
        /// The show ground school command.
        /// </value>
        public RelayCommand<GroundSchoolModel> ShowGroundSchoolCommand
        {
            get
            {
                return new RelayCommand<GroundSchoolModel>(
                    groundSchool =>
                    {
                        var nav = ServiceLocator.Current.GetInstance<INavigationService>();

                        switch (groundSchool.GroundSchoolType)
                        {
                            case GroundSchoolModule.Safety:

                                var htmlMdl = new HTMLModel { FileName = "aircraftsafety.html", title = "Airline Safety" };
                                nav.NavigateTo(nameof(GroundSchoolWebview), htmlMdl);
                                break;
                            case GroundSchoolModule.MeetThePilots:
                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                    new HTMLModel { FileName = "meetpilots.html", title = "Meet the Pilots" });
                                break;
                            case GroundSchoolModule.Security:
                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                 new HTMLModel { FileName = "airportsecurity.html", title = "Airport Security" });

                      //          nav.NavigateTo(ViewModelLocator.GroundSchool_AirportSecurityPageKey);
                                break;
                            case GroundSchoolModule.DeIcing:

                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                   new HTMLModel { FileName = "deicing.html", title = "De-Icing" });

//                                nav.NavigateTo(ViewModelLocator.GroundSchool_DeicingPageKey);
                                break;
                            case GroundSchoolModule.Taxi:

                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                     new HTMLModel { FileName = "taxi.html", title = "Taxi" });


//                                nav.NavigateTo(ViewModelLocator.GroundSchool_TaxiPageKey);
                                break;
                            case GroundSchoolModule.Takeoff:

                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                    new HTMLModel { FileName = "takeoff.html", title = "Takeoff" });


                                //nav.NavigateTo(ViewModelLocator.GroundSchool_TakeoffPageKey);
                                break;
                            case GroundSchoolModule.Cruise:

                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                     new HTMLModel { FileName = "cruise.html", title = "Cruise" });

                                //                                nav.NavigateTo(ViewModelLocator.GroundSchool_CruisePageKey);
                                break;
                            case GroundSchoolModule.Turbulence:

                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                  new HTMLModel { FileName = "turbulencetext.html", title = "Turbulence" });

//                                nav.NavigateTo(ViewModelLocator.GroundSchool_TurbulencePageKey);
                                break;
                            case GroundSchoolModule.Lightning:
                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                 new HTMLModel { FileName = "lightningtext.html", title = "Lightning" });

                                // nav.NavigateTo(ViewModelLocator.GroundSchool_LightningPageKey);
                                break;
                            case GroundSchoolModule.Engines:
                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                 new HTMLModel { FileName = "Enginestext.html", title = "Engines" });

                                // nav.NavigateTo(ViewModelLocator.GroundSchool_EnginesPageKey);
                                break;
                            case GroundSchoolModule.Clouds:
                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                new HTMLModel { FileName = "cloudstext.html", title = "Clouds" });

                                //nav.NavigateTo(ViewModelLocator.GroundSchool_CloudsPageKey);
                                break;
                            case GroundSchoolModule.ApproachAndLanding:
                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                 new HTMLModel { FileName = "approachtext.html", title = "Approach and Landing" });

                                // nav.NavigateTo(ViewModelLocator.GroundSchool_ApproachPageKey);
                                break;
                            case GroundSchoolModule.Customs:
                                nav.NavigateTo(nameof(GroundSchoolWebview),
                                 new HTMLModel { FileName = "customstext.html", title = "Customs" });

                                // nav.NavigateTo(ViewModelLocator.GroundSchool_CustomsPageKey);
                                break;
                        }
                        
                    });
            }
        }
    }
}
