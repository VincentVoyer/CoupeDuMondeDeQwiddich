using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BL;


namespace QwidichIHMWPF
{
    public class ViewModelStade : ViewModelBase
    {
        public Stade Stade
        {
            get
            {
                return mStade;
            }
        }
        private Stade mStade;

        public String Nom
        {
            get
            {
                return this.mStade.Nom;
            }
            set
            {
                this.mStade.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        public String Adresse
        {
            get
            {
                return this.mStade.Adresse;
            }
            set
            {
                this.mStade.Adresse = value;
                OnPropertyChanged("Adresse");
            }
        }

        public int NombrePlaces
        {
            get
            {
                return this.mStade.NombrePlaces;
            }
            set
            {
                this.mStade.NombrePlaces= value;
                OnPropertyChanged("NombrePlaces");
            }
        }

        public double PourcentageCommission
        {
            get
            {
                return this.mStade.PourcentageCommission;
            }
            set
            {
                this.mStade.PourcentageCommission = value;
                OnPropertyChanged("PourcentageCommission");
            }
        }

        public ViewModelStade()
            :this(new Stade())
        {
        }

        public ViewModelStade(Stade stade)
        {
            mStade = stade;
        }
    }
}
