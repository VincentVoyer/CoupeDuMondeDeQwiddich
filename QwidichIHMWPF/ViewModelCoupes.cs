using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using Entities;
using System.Collections.ObjectModel;

namespace QwidichIHMWPF
{
    public class ViewModelCoupes : ViewModelBase
    {
        private CoupeManager cm = new CoupeManager();

        public ObservableCollection<ViewModelCoupe> cups
        {
            get
            {
                return mCups;
            }
            set
            {
                mCups = value;
                OnPropertyChanged("cups");
            }
        }
        private ObservableCollection<ViewModelCoupe> mCups;

        public ViewModelCoupe SelectedCup
        {
            get { return mSelectedCup; }
            set {
                mSelectedCup = value;
                OnPropertyChanged("SelectedCup");
            }
        }
        private ViewModelCoupe mSelectedCup;

        public RelayCommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(() => this.AddCoupe());
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
                    supp = new RelayCommand(() => this.SuppCoupe(), () => this.CanSupp());
                }
                return supp;
            }
        }
        private RelayCommand supp;

        public ViewModelCoupes()
        {
            mCups = new ObservableCollection<ViewModelCoupe>();
            foreach(Coupe c in cm.GetListCoupes())
            {
                mCups.Add(new ViewModelCoupe(c));
            }
        }

        private void SuppCoupe()
        {
            CoupeManager cm = new CoupeManager();
            cm.DelCoupe(SelectedCup.Cup);
            mCups.Remove(SelectedCup);
            OnPropertyChanged("cups");
            OnPropertyChanged("SelectedCup");
        }

        private Boolean CanSupp()
        {
            return (SelectedCup != null);
        }

        private void AddCoupe()
        {
            Coupe c = new Coupe();
            CoupeManager cm = new CoupeManager();

            cm.AddCoupe(c);
            mCups.Add(new ViewModelCoupe(c));
            OnPropertyChanged("cups");
            SelectedCup = mCups.Last();
        }

    }
}
