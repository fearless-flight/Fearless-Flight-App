using FearlessFlight.XForms.Interfaces;
using FearlessFlight.XForms.Views.GroundSchool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FearlessFlight.XForms.Models
{
    public class HTMLModel
    {
        public HTMLModel()
        {

        }
        public string HTML { get; set; }

        public string FileName
        {
            set
            {

                var txtpath = DependencyService.Get<IBaseUrl>().Get();

                var sourcex = new UrlWebViewSource { Url = Path.Combine(txtpath, value) };

                WebUriSource = sourcex;
            }
        }

        public UrlWebViewSource WebUriSource { get; set; }
        

        public string title { get; set; }
    }
}
