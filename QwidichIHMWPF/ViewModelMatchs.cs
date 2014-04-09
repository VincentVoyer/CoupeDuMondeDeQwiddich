using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Entities;
using BL;

namespace QwidichIHMWPF
{
    public class ViewModelMatchs : ViewModelBase
    {

        private CoupeManager cm = new CoupeManager();
        public ObservableCollection<Coupe> cups
        {
            get
            {
                return new ObservableCollection<Coupe>(cm.GetListCoupes());
            }
        }

        public Coupe SelectedCup
        {
            get
            {
                return mSelectedCup;
            }
            set
            {
                this.mSelectedCup = value;
                OnPropertyChanged("SelectedCup");
                this.Matchs = CreateViewModels(cm.GetListMatch(mSelectedCup).ToList());
            }
        }
        private Coupe mSelectedCup;

        public ObservableCollection<ViewModelMatch> Matchs
        {
            get
            {
                return mMatchs;
            }
            set
            {
                mMatchs = value;
                OnPropertyChanged("Matchs");
            }
        }
        private ObservableCollection<ViewModelMatch> mMatchs;

        public ViewModelMatch SelectedMatch
        {
            get
            {
                return mSelectedMatch;
            }
            set
            {
                mSelectedMatch = value;
                OnPropertyChanged("SelectedMatch");
            }
        }
        private ViewModelMatch mSelectedMatch;

        public ViewModelMatchs() {
            mMatchs = new ObservableCollection<ViewModelMatch>();
        }

        private ObservableCollection<ViewModelMatch> CreateViewModels(List<Match> matchs)
        {
            ObservableCollection<ViewModelMatch> list = new ObservableCollection<ViewModelMatch>();
            foreach(Match m in matchs)
            {
                list.Add(new ViewModelMatch(m));
            }

            return list;
        }

        public RelayCommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(() => this.AddMatch());
                }
                return add;
            }
        }
        private RelayCommand add;

        public RelayCommand Supp
        {
            get
            {
                if (supp == null)
                {
                    supp = new RelayCommand(() => this.SuppMatch(), () => this.CanSupp());
                }
                return supp;
            }
        }
        private RelayCommand supp;

        private void SuppMatch()
        {
            CoupeManager cm = new CoupeManager();

            cm.DelMatch(SelectedMatch.Match);
            mMatchs.Remove(SelectedMatch);
            OnPropertyChanged("Matchs");
            OnPropertyChanged("SelectedMatchs");
        }

        private Boolean CanSupp()
        {
            return (SelectedMatch != null);
        }

        private void AddMatch()
        {
            if (SelectedCup != null)
            {
                Match match = new Match();
                match.CoupeId = SelectedCup.Id;
                mMatchs.Add(new ViewModelMatch(match));
                OnPropertyChanged("Matchs");
                SelectedMatch = mMatchs.Last();
            }

        }

        public void SaveMatchs()
        {
            cm.SaveMatch();
        }
    }
}
