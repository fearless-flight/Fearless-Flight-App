using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Diagnostics;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using FearlessFlight.XForms.Models;
using FearlessFlight.XForms.Resx;
using Microsoft.Practices.ServiceLocation;

namespace FearlessFlight.XForms.ViewModel
{
    public class TechniquesViewModel : ViewModelBase
    {
        private List<TechniqueModel> _techniques;
        private string _commandText;

        /// <summary>
        /// Initializes a new instance of the <see cref="TechniquesViewModel"/> class.
        /// </summary>
        public TechniquesViewModel()
        {
            _techniques = new List<TechniqueModel>();
            _techniques.Add(new TechniqueModel()
            {
                Title = AppResources.technique_simple_breathing,
                AudioFileName = "simple_breathing.mp3",
                AudioFileLength = "1:11",
                ImageFileName = "simple_breathing.png",
                TechniqueType = TechniqueType.SimpleBreathing
            });

            _techniques.Add(new TechniqueModel()
            {
                Title = AppResources.technique_478,
                AudioFileName = "four78.mp3",
                AudioFileLength = "2:04",
                ImageFileName = "four78.png",
                TechniqueType = TechniqueType.FourSevenEight
            });

            _techniques.Add(new TechniqueModel()
            {
                Title = AppResources.technique_ispy,
                AudioFileName = "i_spy.mp3",
                AudioFileLength = "0:55",
                ImageFileName = "i_spy.png",
                TechniqueType = TechniqueType.ISpy
            });

            _techniques.Add(new TechniqueModel()
            {
                Title = AppResources.technique_rubber_band,
                AudioFileName = "rubber_band.mp3",
                AudioFileLength = "1:22",
                ImageFileName = "rubber_band.png",
                TechniqueType = TechniqueType.RubberBand
            });

            _techniques.Add(new TechniqueModel()
            {
                Title = AppResources.technique_tense_and_relax,
                AudioFileName = "tense_and_relax.mp3",
                AudioFileLength = "4:07",
                ImageFileName = "tense_and_relax.png",
                TechniqueType = TechniqueType.TenseAndRelax
            });

            Techniques = _techniques;
        }

        /// <summary>
        /// Gets or sets the techniques.
        /// </summary>
        /// <value>
        /// The techniques.
        /// </value>
        public List<TechniqueModel> Techniques
        {
            get { return _techniques; }
            set
            {
                if (_techniques != null)
                {
                    _techniques = value;
                    RaisePropertyChanged("Techniques");
                }
            }
        }

        /// <summary>
        /// Gets or sets the command text.
        /// </summary>
        /// <value>
        /// The command text.
        /// </value>
        public string CommandText
        {
            get { return _commandText; }
            set
            {
                _commandText = value;
                RaisePropertyChanged("CommandText");
            }
        }

        /// <summary>
        /// Gets the show technique command.
        /// </summary>
        /// <value>
        /// The show technique command.
        /// </value>
        public RelayCommand<TechniqueModel> ShowTechniqueCommand
        {
            get
            {
                return new RelayCommand<TechniqueModel>(
                    technique =>
                    {
                        var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                        nav.NavigateTo(ViewModelLocator.TechniqueDetailsPageKey, technique);

                        

                    });
            }
        }
    }
}
