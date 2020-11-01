using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FearlessFlight.XForms.Models
{
    public enum GroundSchoolModule
    {
        Safety = 1,
        MeetThePilots = 2,
        Security = 3,
        DeIcing = 4,
        Taxi = 5,
        Takeoff = 6,
        Cruise = 7,
        Turbulence = 8,
        Lightning = 9,
        Engines = 10,
        Clouds = 11,
        ApproachAndLanding = 12,
        Customs = 13
    }

    public class GroundSchoolModel
    {
        public string Title { get; set; }

        public string SubTitle { get; set; } = "sample subtitle";

        public string ImageFilename { get; set; }

        public GroundSchoolModule GroundSchoolType { get; set; }
    }
}
