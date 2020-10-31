using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FearlessFlight.XForms.Interfaces;
using FearlessFlight.XForms.iOS.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_iOS))]
namespace FearlessFlight.XForms.iOS.Services
{
    public class BaseUrl_iOS : IBaseUrl
    {
        public string Get()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}