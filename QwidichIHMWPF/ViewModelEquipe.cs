using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace QwidichIHMWPF
{
    public class ViewModelEquipe : ViewModelBase
    {
        public Equipe Team
        {
            get
            {
                return team;
            }
        }
        private Equipe team;

        public String Nom
        {
            get
            {
                return this.team.Nom;
            }
            set
            {
                this.team.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        public String Pays
        {
            get
            {
                return this.team.Pays;
            }
            set
            {
                this.team.Pays = value;
                OnPropertyChanged("Pays");
            }
        }

        public List<Joueur> Joueurs
        {
            get
            {
                return this.team.Joueurs;
            }
            set
            {
                this.team.Joueurs = value;
                OnPropertyChanged("Joueurs");
            }
        }

        public ViewModelEquipe()
            : this(new Equipe()) { }

        public ViewModelEquipe(Equipe team)
        {
            this.team = team;
        }
    }
}
