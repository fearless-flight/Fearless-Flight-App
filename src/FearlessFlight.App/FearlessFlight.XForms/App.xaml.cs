using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

using FearlessFlight.XForms;
using FearlessFlight.XForms.ViewModel;
using FearlessFlight.XForms.Helpers;
using FearlessFlight.XForms.Views.GroundSchool;
using FearlessFlight.XForms.Views.FlightStage;
using FearlessFlight.XForms.Views.Techniques;
using FearlessFlight.XForms.Views.PracticeFlight;

namespace FearlessFlight.XForms
{
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            try
            {
                InitializeComponent();
            }catch(Exception ex)
            {
                var t = ex.Message;
            }
#if DEBUG
            System.Diagnostics.Debug.WriteLine("====== resource debug info =========");

            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }

            System.Diagnostics.Debug.WriteLine("====================================");
#endif

            // This lookup NOT required for Windows platforms - the Culture will be automatically set
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS || Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                // determine the correct, supported .NET culture
                var currentCultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

                // set the RESX for resource localization
                Resx.AppResources.Culture = currentCultureInfo;

                // set the Thread for locale-aware methods
                DependencyService.Get<ILocalize>().SetLocale(currentCultureInfo); 
            }

            // First time initialization
            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.IntroductionPageKey, typeof(IntroductionPage));
            nav.Configure(ViewModelLocator.FlightStagePageKey, typeof(FlightStagePage));
            nav.Configure(ViewModelLocator.GroundSchoolPageKey, typeof(GroundSchoolPage));
            nav.Configure(ViewModelLocator.GroundSchool_AirlineSafetyPageKey, typeof(GroundSchool_AirlineSafetyPage));

            nav.Configure(ViewModelLocator.WebViewPage, typeof(GroundSchoolWebview));


            nav.Configure(ViewModelLocator.GroundSchool_AirportSecurityPageKey, typeof(GroundSchool_AirportSecurityPage));
            nav.Configure(ViewModelLocator.GroundSchool_ApproachPageKey, typeof(GroundSchool_ApproachPage));
            nav.Configure(ViewModelLocator.GroundSchool_CloudsPageKey, typeof(GroundSchool_CloudsPage));
            nav.Configure(ViewModelLocator.GroundSchool_CruisePageKey, typeof(GroundSchool_CruisePage));
            nav.Configure(ViewModelLocator.GroundSchool_CustomsPageKey, typeof(GroundSchool_CustomsPage));
            nav.Configure(ViewModelLocator.GroundSchool_DeicingPageKey, typeof(GroundSchool_DeicingPage));
            nav.Configure(ViewModelLocator.GroundSchool_EnginesPageKey, typeof(GroundSchool_EnginesPage));
            nav.Configure(ViewModelLocator.GroundSchool_LightningPageKey, typeof(GroundSchool_LightningPage));
            nav.Configure(ViewModelLocator.GroundSchool_MeetThePilotsPageKey, typeof(GroundSchool_MeetThePilotsPage));
            nav.Configure(ViewModelLocator.GroundSchool_TakeoffPageKey, typeof(GroundSchool_TakeoffPage));
            nav.Configure(ViewModelLocator.GroundSchool_TaxiPageKey, typeof(GroundSchool_TaxiPage));
            nav.Configure(ViewModelLocator.GroundSchool_TurbulencePageKey, typeof(GroundSchool_TurbulencePage));
            nav.Configure(ViewModelLocator.TechniquesPageKey, typeof(TechniquesPage));
            nav.Configure(ViewModelLocator.TechniqueDetailsPageKey, typeof(TechniqueDetailsPage));
            nav.Configure(ViewModelLocator.PracticeFlightPageKey, typeof(PracticeFlightPage));
            nav.Configure(ViewModelLocator.AboutPageKey, typeof(AboutPage));

            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var navPage = new NavigationPage(new MainPage());
            nav.Initialize(navPage);

            StaticHelper.SetupItems();

            // The root page of application
            MainPage = navPage;
        }

        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        public static Page GetMainPage()
        {
            return new MainPage();
        }

        protected override void OnStart()
        {
			// Handle when your app starts
			AppCenter.Start("ios=f331a642-b4ea-47d9-848c-83e92d981cae;" +
				   "uwp=ebf6c979-559c-40d7-b922-c8e7c96a3095;" +
				   "android=453a5601-b0e8-4569-bb9d-8e6363bb374e",
				   typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
