using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Collections.ObjectModel;
using BL;

namespace QwidichIHMWPF
{
    public class ViewModelReservations : ViewModelBase
    {

        public ObservableCollection<ViewModelReservation> Reservations
        {
            get
            {
                return mReservation;
            }

        }
        private ObservableCollection<ViewModelReservation> mReservation;

        public ViewModelReservation SelectedItem
        {
            get
            {
                return mSelectedItem;
            }
            set
            {
                mSelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        private ViewModelReservation mSelectedItem;

        public RelayCommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(() => this.AddReservation());
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
                    supp = new RelayCommand(() => this.SuppReservation(), () => this.CanReservation());
                }
                return supp;
            }
        }
        private RelayCommand supp;

        public ViewModelReservations()
            :this(new List<Reservation>())
        {}

        public ViewModelReservations(List<Reservation> reservations)
        {
            mReservation = new ObservableCollection<ViewModelReservation>();
            foreach(Reservation current in reservations)
            {
                mReservation.Add(new ViewModelReservation(current));
            }
        }

        private void SuppReservation()
        {
            CoupeManager cm = new CoupeManager();

            cm.AddReservation(SelectedItem.Reservation);
            mReservation.Remove(SelectedItem);
            OnPropertyChanged("Reservations");
            OnPropertyChanged("SelectedItem");
        }

        private Boolean CanReservation()
        {
            return (SelectedItem != null);
        }

        private void AddReservation()
        {
            Reservation r = new Reservation();
            CoupeManager cm = new CoupeManager();

            cm.AddReservation(r);
            mReservation.Add(new ViewModelReservation(r));
            OnPropertyChanged("Reservations");
            SelectedItem = mReservation.Last();
        }

    }
}
