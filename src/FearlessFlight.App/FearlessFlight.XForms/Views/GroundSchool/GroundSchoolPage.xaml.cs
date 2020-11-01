using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

using FearlessFlight.XForms.Models;
using FearlessFlight.XForms.ViewModel;

namespace FearlessFlight.XForms.Views.GroundSchool
{
    public partial class GroundSchoolPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroundSchoolPage"/> class.
        /// </summary>
        public GroundSchoolPage()
        {
            InitializeComponent();

            // now bind view model
            var vm = new GroundSchoolViewModel();
            this.BindingContext = vm;
 

        }
    }
}
