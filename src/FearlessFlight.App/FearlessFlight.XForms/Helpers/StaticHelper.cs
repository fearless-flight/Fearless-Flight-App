using FearlessFlight.XForms.Models;
using FearlessFlight.XForms.Resx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FearlessFlight.XForms.Helpers
{
    public static class StaticHelper
    {
        // basic test for items in list
        public static ObservableCollection<GroundSchoolModel> GroundschoolItems { get; set; }

        public static async void SetupItems()
        {
            string path = @"images\ground_school\";

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                path = "";


            GroundschoolItems = new ObservableCollection<GroundSchoolModel>();
            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_01_airline_safety_title,
                ImageFilename =  $"{path}safety.png",
                GroundSchoolType = GroundSchoolModule.Safety
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_02_meet_the_pilots_title,
                ImageFilename =  $"{path}meet_the_pilots.png",
                GroundSchoolType = GroundSchoolModule.MeetThePilots
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_03_security_title,
                ImageFilename =  $"{path}security.png",
                GroundSchoolType = GroundSchoolModule.Security
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_04_deicing_title,
                ImageFilename =  $"{path}de_icing.png",
                GroundSchoolType = GroundSchoolModule.DeIcing
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_05_taxi_title,
                ImageFilename =  $"{path}taxi.png",
                GroundSchoolType = GroundSchoolModule.Taxi
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_06_takeoff_title,
                ImageFilename = $"{path}take_off.png",
                GroundSchoolType = GroundSchoolModule.Takeoff
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_07_cruise_title,
                ImageFilename =  $"{path}cruise.png",
                GroundSchoolType = GroundSchoolModule.Cruise
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_08_turbulence_title,
                ImageFilename =  $"{path}turbulence.png",
                GroundSchoolType = GroundSchoolModule.Turbulence
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_09_lightning_title,
                ImageFilename = $"{path}lightning.png",
                GroundSchoolType = GroundSchoolModule.Lightning
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_10_engines_title,
                ImageFilename = $"{path}engines.png",
                GroundSchoolType = GroundSchoolModule.Engines
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_11_clouds_title,
                ImageFilename =  $"{path}clouds.png",
                GroundSchoolType = GroundSchoolModule.Clouds
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_12_approach_and_landing_title,
                ImageFilename =  $"{path}approach_and_landing.png",
                GroundSchoolType = GroundSchoolModule.ApproachAndLanding
            });

            GroundschoolItems.Add(new GroundSchoolModel()
            {
                Title = AppResources.groundschool_13_customs_title,
                ImageFilename =  $"{path}customs.png",
                GroundSchoolType = GroundSchoolModule.Customs
            });
        }
    }
}
