using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace QwidichIHMWPF
{
    public class ViewModelCoupe : ViewModelBase
    {
        public Coupe Cup
        {
            get
            {
                return cup;
            }
        }
        private Coupe cup;

        /// <summary>
        /// Année de la coupe.
        /// </summary>
        public int Year
        {
            get
            {
                return this.cup.Year;
            }
            set
            {
                this.cup.Year = value;
                OnPropertyChanged("Year");
            }
        }

        /// <summary>
        /// Libelle de la coupe.
        /// </summary>
        public String Libelle
        {
            get
            {
                return this.cup.Libelle;
            }
            set
            {
                this.cup.Libelle = value;
                OnPropertyChanged("Libelle");
            }
        }

        public ViewModelCoupe()
        :this(new Coupe())
        {
        }

        public ViewModelCoupe(Coupe cup)
        {
            this.cup = cup;
        }
    }
}
