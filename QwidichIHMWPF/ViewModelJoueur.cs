using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace QwidichIHMWPF
{
    public class ViewModelJoueur : ViewModelBase
    {
        public Joueur Player
        {
            get
            {
                return mPlayer;
            }
        }
        private Joueur mPlayer;
        
        public Array Postes
        {
            get
            {
                return Enum.GetValues(typeof(PosteJoueur));
            }
        }

        public String Nom
        {
            get
            {
                return this.mPlayer.Nom;
            }
            set
            {
                this.mPlayer.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        public String Prenom
        {
            get
            {
                return this.mPlayer.Prenom;
            }
            set
            {
                this.mPlayer.Prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        public DateTime DateNaissance
        {
            get
            {
                return this.mPlayer.DateNaissance;
            }
            set
            {
                this.mPlayer.DateNaissance = value;
                OnPropertyChanged("DateNaissance");
            }
        }

        public int NbSelection
        {
            get
            {
                return this.mPlayer.NbSelection;
            }
            set
            {
                this.mPlayer.NbSelection = value;
                OnPropertyChanged("NbSelection");
            }
        }

        public PosteJoueur Poste
        {
            get
            {
                return this.mPlayer.Poste;
            }
            set
            {
                this.mPlayer.Poste = value;
                OnPropertyChanged("Poste");
            }
        }

        public int Score
        {
            get
            {
                return this.mPlayer.Score;
            }
            set
            {
                this.mPlayer.Score = value;
                OnPropertyChanged("Score");
            }
        }

        public ViewModelJoueur()
            :this(new Joueur()){}

        public ViewModelJoueur(Joueur joueur)
        {
            mPlayer = joueur;
        }
    }
}
