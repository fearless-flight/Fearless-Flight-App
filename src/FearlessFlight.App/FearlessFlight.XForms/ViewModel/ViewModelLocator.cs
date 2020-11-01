using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace FearlessFlight.XForms.ViewModel
{
    public class ViewModelLocator
    {
        public const string IntroductionPageKey = "IntroductionPage";
        public const string FlightStagePageKey = "FlightStagePage";
        public const string GroundSchoolPageKey = "GroundSchoolPage";
        public const string GroundSchool_AirlineSafetyPageKey = "GroundSchool_AirlineSafetyPage";
        public const string GroundSchool_AirportSecurityPageKey = "GroundSchool_AirportSecurityPage";
        public const string GroundSchool_ApproachPageKey = "GroundSchool_ApproachPage";
        public const string GroundSchool_CloudsPageKey = "GroundSchool_CloudsPage";
        public const string GroundSchool_CruisePageKey = "GroundSchool_CruisePage";
        public const string GroundSchool_CustomsPageKey = "GroundSchool_CustomsPage";
        public const string GroundSchool_DeicingPageKey = "GroundSchool_DeicingPage";
        public const string GroundSchool_EnginesPageKey = "GroundSchool_EnginesPage";
        public const string GroundSchool_LightningPageKey = "GroundSchool_LightningPage";
        public const string GroundSchool_MeetThePilotsPageKey = "GroundSchool_MeetThePilotsPage";
        public const string GroundSchool_TakeoffPageKey = "GroundSchool_TakeoffPage";
        public const string GroundSchool_TaxiPageKey = "GroundSchool_TaxiPage";
        public const string GroundSchool_TurbulencePageKey = "GroundSchool_TurbulencePage";
        public const string TechniquesPageKey = "TechniquesPage";
        public const string TechniqueDetailsPageKey = "TechniqueDetailsPageKey";
        public const string PracticeFlightPageKey = "PracticeFlightPage";
        public const string AboutPageKey = "AboutPage";

        public const string WebViewPage = "GroundSchoolWebview";

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> class.
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)  
            //{  
            // // Create design time view services and models  
            // SimpleIoc.Default.Register<IDataService, DesignDataService>();  
            //}  
            //else  
            //{  
            // // Create run time view services and models  
            // SimpleIoc.Default.Register<IDataService, DataService>();  
            //}  

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<GroundSchoolViewModel>();
        }
        
        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels  
        }
    }
}
