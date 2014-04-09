using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Entities;
using BL;

namespace QwidichIHMWPF
{
    public class ViewModelStades : ViewModelBase
    {
        public ObservableCollection<ViewModelStade> Stades
        {
            get
            {
                return mStades;
            }
        }
        private ObservableCollection<ViewModelStade> mStades;

        public ViewModelStade SelectedStade
        {
            get
            {
                return mSelectedStade;
            }
            set
            {
                mSelectedStade = value;
                OnPropertyChanged("SelectedStade");
            }
        }
        private ViewModelStade mSelectedStade;

        public ViewModelStades()
            : this(new List<Stade>()) { }

        public ViewModelStades( List<Stade> stades)
        {
            mStades = new ObservableCollection<ViewModelStade>();
            foreach(Stade stade in stades)
            {
                mStades.Add(new ViewModelStade(stade));
            }
        }

        public RelayCommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(() => this.AddStade());
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
                    supp = new RelayCommand(() => this.SuppStade(), () => this.CanSupp());
                }
                return supp;
            }
        }
        private RelayCommand supp;

        private void SuppStade()
        {
            CoupeManager cm = new CoupeManager();

            cm.DelStade(SelectedStade.Stade);
            mStades.Remove(SelectedStade);
            OnPropertyChanged("Stades");
            OnPropertyChanged("SelectedStade");
        }

        private Boolean CanSupp()
        {
            return (SelectedStade != null);
        }

        private void AddStade()
        {
            Stade s = new Stade();
            CoupeManager cm = new CoupeManager();

            cm.AddStade(s);
            mStades.Add(new ViewModelStade());
            OnPropertyChanged("Stades");
            SelectedStade = mStades.Last();
        }
    
        public void SaveStades()
        {
            CoupeManager cm = new CoupeManager();
            cm.SaveStade();
        }
    
    }
}
