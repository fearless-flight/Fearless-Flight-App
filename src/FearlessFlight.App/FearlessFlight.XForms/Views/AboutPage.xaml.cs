using GalaSoft.MvvmLight.Command;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FearlessFlight.XForms
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            OpenBrowserCommand = new RelayCommand(openBrowser);
            SendEmailCommand = new RelayCommand(SendEmail);
            BindingContext = this;
        }

        //public string AppVersion
        //{
        //    get
        //    {
        //        var appVersionString = "1.0";// NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        //        var appBuildNumber = "1";// NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();

        //        return $"Version {appVersionString} (build {appBuildNumber})";
        //    }
        //}
            
        public string AppVersion
        {
            get
            {
                Assembly asm = this.GetType().GetTypeInfo().Assembly;
                return $"Version {asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion} (build {asm.GetCustomAttribute<AssemblyFileVersionAttribute>().Version})";
            }
        }

        public ICommand OpenBrowserCommand { get; set;}

        public ICommand SendEmailCommand { get; set; }

        private void openBrowser()
        {
            Device.OpenUri(new Uri("http://FearlessFlightApp.com"));
        }

        private void SendEmail()
        {
            try
            {
                var address = "fearlessflightapp@gmail.com";
                Device.OpenUri(new Uri($"mailto:{address}"));
            }
            catch
            {
                this.DisplayAlert("Error", "No email client setup on device", "OK");
            }
        }
    }
}
