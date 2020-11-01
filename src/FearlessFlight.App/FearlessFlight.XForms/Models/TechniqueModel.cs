using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FearlessFlight.XForms.Models
{
    public enum TechniqueType
    {
        SimpleBreathing = 1,
        FourSevenEight = 2,
        ISpy = 3,
        RubberBand = 4,
        TenseAndRelax = 5
    }

    public class TechniqueModel
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string ImageFileName { get; set; }

        public string AudioFileName { get; set; }

        public TechniqueType TechniqueType { get; set; }

        public string AudioFileLength { get; set; }
    }
}
