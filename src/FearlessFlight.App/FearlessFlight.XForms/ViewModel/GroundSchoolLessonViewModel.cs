using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using FearlessFlight.XForms.Models;

namespace FearlessFlight.XForms.ViewModels
{
    public class GroundSchoolLessonViewModel : INotifyPropertyChanged
    {
        private GroundSchoolModel _groundSchool = new GroundSchoolModel();

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get { return _groundSchool.Title; }
            set
            {
                if (_groundSchool.Title != value)
                {
                    _groundSchool.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body
        {
            get { return _groundSchool.Body; }
            set
            {
                if (_groundSchool.Body != value)
                {
                    _groundSchool.Body = value;
                    OnPropertyChanged("Body");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
