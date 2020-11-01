using System;
using Xamarin.Forms;

namespace FearlessFlight.XForms
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }
            BindingContext = App.Locator.Main;

            var test  = this.FindByName<Button>("btGroundSchool");
            if(test!=null)
                test.Clicked += Test_Clicked;
        }

        private void Test_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.GroundSchool.GroundSchoolPage());
        }
    }
}
