using FearlessFlight.XForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FearlessFlight.XForms.Views.GroundSchool
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroundSchoolWebview : ContentPage
    {
        public GroundSchoolWebview(HTMLModel html)
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }

            this.BindingContext = html;

        }
    }
}