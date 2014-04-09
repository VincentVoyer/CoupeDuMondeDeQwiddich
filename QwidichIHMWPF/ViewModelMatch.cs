using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BL;

namespace QwidichIHMWPF
{
    public class ViewModelMatch : ViewModelBase
    {
        private CoupeManager cm = new CoupeManager();

        public List<Stade> Stades
        {
            get
            {
                return cm.GetListStade().ToList();
            }
        }

        public List<Equipe> Equipes
        {
            get
            {
                return cm.GetListEquipe().ToList();
            }
        }

        public Match Match
        {
            get
            {
                return mMatch;
            }
        }
        private Match mMatch;

        public DateTime Date
        {
            get
            {
                return this.mMatch.Date;
            }
            set
            {
                this.mMatch.Date = value;
                OnPropertyChanged("Date");
            }
        }

        public double Prix
        {
            get
            {
                return this.mMatch.Prix;
            }
            set
            {
                this.mMatch.Prix = value;
                OnPropertyChanged("Prix");
            }
        }

        public Stade Stade
        {
            get
            {
                return this.mMatch.Stade;
            }
            set
            {
                this.mMatch.Stade = value;
                OnPropertyChanged("Stade");
            }
        }

        public Equipe EquipeVisiteur
        {
            get
            {
                return this.mMatch.EquipeVisiteur;
            }
            set
            {
                this.mMatch.EquipeVisiteur = value;
                OnPropertyChanged("EquipeVisiteur");
            }
        }

        public Equipe EquipeDomicile
        {
            get
            {
                return this.mMatch.EquipeDomicile;
            }
            set
            {
                this.mMatch.EquipeDomicile = value;
                OnPropertyChanged("EquipeDomicile");
            }
        }

        public int ScoreEquipeDomicile
        {
            get
            {
                return this.mMatch.ScoreEquipeDomicile;
            }
            set
            {
                this.mMatch.ScoreEquipeDomicile = value;
                OnPropertyChanged("ScoreEquipeDomicile");
            }
        }

        public int ScoreEquipeVisiteur
        {
            get
            {
                return this.mMatch.ScoreEquipeVisiteur;
            }
            set
            {
                this.mMatch.ScoreEquipeVisiteur = value;
                OnPropertyChanged("ScoreEquipeVisiteur");
            }
        }

        public ViewModelMatch()
            :this(new Match())
        {}

        public ViewModelMatch(Match match)
        {
            mMatch = match;
        }
    }
}
