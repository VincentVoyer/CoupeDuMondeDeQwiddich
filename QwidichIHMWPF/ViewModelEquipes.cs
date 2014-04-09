using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Entities;
using BL;
using System.Windows;

namespace QwidichIHMWPF
{
    public class ViewModelEquipes : ViewModelBase
    {
        private CoupeManager cm =  new CoupeManager();

        public ObservableCollection<ViewModelEquipe> Teams
        {
            get
            {
                return mTeams;
            }
        }
        private ObservableCollection<ViewModelEquipe> mTeams;

        public ViewModelEquipe SelectedTeam
        {
            get
            {
                return mSelectedTeam;
            }
            set
            {
                mSelectedTeam = value;
                OnPropertyChanged("SelectedTeam");
                this.Joueurs = CreateJoueurs(mSelectedTeam.Team.Id);
            }
        }
        private ViewModelEquipe mSelectedTeam;

        public ObservableCollection<ViewModelJoueur> Joueurs
        { 
            get
            {
                return mJoueurs;
            }
            set
            {
                mJoueurs = value;
                OnPropertyChanged("Joueurs");
            }
        }
        private ObservableCollection<ViewModelJoueur> mJoueurs;

        public ViewModelJoueur SelectedJoueur
        {
            get
            {
                return mSelectedJoueur;
            }
            set
            {
                mSelectedJoueur = value;
                OnPropertyChanged("SelectedJoueur");
            }
        }
        private ViewModelJoueur mSelectedJoueur;

        public ViewModelEquipes() {
            mTeams = new ObservableCollection<ViewModelEquipe>();
            foreach (Equipe team in cm.GetListEquipe())
            {
                mTeams.Add(new ViewModelEquipe(team));
            }
        }

        private ObservableCollection<ViewModelJoueur> CreateJoueurs(int idTeam)
        {
            ObservableCollection<ViewModelJoueur> list = new ObservableCollection<ViewModelJoueur>();
            List<Joueur> joueurs = cm.GetListJoueur(idTeam);
            foreach(Joueur j in joueurs)
            {
                list.Add(new ViewModelJoueur(j));
            }

            return list;
        }

        public RelayCommand AddTeam
        {
            get
            {
                if (addTeam == null)
                {
                    addTeam = new RelayCommand(() => this.addTeamCmd());
                }
                return addTeam;
            }
        }
        private RelayCommand addTeam;

        public RelayCommand SuppTeam
        {
            get
            {
                if (suppTeam == null)
                {
                    suppTeam = new RelayCommand(() => this.suppTeamCmd(), () => this.CanSuppTeam());
                }
                return suppTeam;
            }
        }
        private RelayCommand suppTeam;

        private void suppTeamCmd()
        {
            mTeams.Remove(SelectedTeam);
            OnPropertyChanged("Teams");
            OnPropertyChanged("SelectedTeam");
        }

        private Boolean CanSuppTeam()
        {
            return (SelectedTeam != null);
        }

        private void addTeamCmd()
        {
            Equipe t = new Equipe();
            CoupeManager cm = new CoupeManager();

            cm.AddTeam(t);
            mTeams.Add(new ViewModelEquipe(t));
            OnPropertyChanged("Teams");
            SelectedTeam = mTeams.Last();
        }

        public RelayCommand AddJoueur
        {
            get
            {
                if (addJoueur == null)
                {
                    addJoueur = new RelayCommand(() => this.addJoueurCmd());
                }
                return addJoueur;
            }
        }
        private RelayCommand addJoueur;

        public RelayCommand SuppJoueur
        {
            get
            {
                if (suppJoueur == null)
                {
                    suppJoueur = new RelayCommand(() => this.suppJoueurCmd(), () => this.CanSuppJoueur());
                }
                return suppJoueur;
            }
        }
        private RelayCommand suppJoueur;

        private void suppJoueurCmd()
        {
            if(SelectedJoueur != null)
            { 
                CoupeManager cm = new CoupeManager();
                cm.DelJoueur(SelectedJoueur.Player);
                mJoueurs.Remove(SelectedJoueur);
                OnPropertyChanged("Joueurs");
                OnPropertyChanged("SelectedJoueur");
            }
        }

        private Boolean CanSuppJoueur()
        {
            return (SelectedJoueur != null);
        }

        private void addJoueurCmd()
        {
            if (SelectedTeam != null)
            {
                Joueur j = new Joueur();
                CoupeManager cm = new CoupeManager();
                cm.AddJoueur(j);
                j.IdTeam = SelectedTeam.Team.Id;
                Joueurs.Add(new ViewModelJoueur(j));
                OnPropertyChanged("SelectedTeam");
                OnPropertyChanged("Joueurs");
                SelectedJoueur = mJoueurs.Last();
            }
            else
                MessageBox.Show("Veuillez selecionner une equipe");
        }

        public void SaveJoueur()
        {
            cm.SaveJoueur();
        }

        public void SaveEquipes()
        {
            cm.SaveEquipe();
        }
    }
}
