using AudioManager;
using FearlessFlight.XForms.Interfaces;
using FearlessFlight.XForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FearlessFlight.XForms.Views.Techniques
{
    public partial class TechniqueDetailsPage : ContentPage
    {
        bool IsRunning { get; set; }
        public TechniqueDetailsPage(TechniqueModel tech)
        {
          
            BindingContext = this;
            TechModel = tech;
            IsRunning = false;

            InitializeComponent();

            
        }

        //protected override bool OnBackButtonPressed()
        //{


        //    if (IsRunning)
        //    {
        //        if(this.DisplayAlert("Stop Audio","Do you wish to stop the audio and exit?","Yes", "No").Result)
        //        {
        //            return true;
        //        }
        //   }

        //    base.OnBackButtonPressed();
        //    return false;

        //}

        private TechniqueModel _techModel;
            
        public TechniqueModel TechModel
        {
            get { return _techModel; }
            set { _techModel = value; }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (IsRunning)
            {
                DependencyService.Get<IAudioPlayerService>().Pause();
            }
        }

        private /*async*/ void Button_Clicked(object sender, EventArgs e)
        {
            var ButText = this.FindByName<Button>("BtText");
            if(IsRunning)
            {
                IsRunning = false;
                ButText.Text = "Play";
                DependencyService.Get<IAudioPlayerService>().Pause();



            }
            else
            {
                IsRunning = true;
                ButText.Text = "Stop";

                DependencyService.Get<IAudioPlayerService>().Play(TechModel.AudioFileName);

            }
        }
    }
}
