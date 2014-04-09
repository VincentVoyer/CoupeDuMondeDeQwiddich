using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BL;

namespace QwidichIHMWPF
{
    public class ViewModelReservation : ViewModelBase
    {
        public Reservation Reservation
        {
            get
            {
                return mReservation;
            }
        }
        private Reservation mReservation;

        /// <summary>
        /// Match de la reservation.
        /// </summary>
        public Match Match
        {
            get
            {
                return this.mReservation.Match;
            }
            set
            {
                this.mReservation.Match = value;
                OnPropertyChanged("Match");
                OnPropertyChanged("Prix");
            }
        }

        /// <summary>
        /// nombre de places réservées.
        /// </summary>
        public int NombrePlacesReservees
        {
            get
            {
                return this.mReservation.NombrePlacesReservees;
            }
            set
            {
                this.mReservation.NombrePlacesReservees = value;
                OnPropertyChanged("NombrePlacesReservees");
                OnPropertyChanged("Prix");
            }
        }

        /// <summary>
        /// nom du spectateur.
        /// </summary>
        public String Nom
        {
            get
            {
                return this.mReservation.Spectateur.Nom;
            }
            set
            {
                this.mReservation.Spectateur.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        /// <summary>
        /// Prenom du spectateur.
        /// </summary>
        public String Prenom
        {
            get
            {
                return this.mReservation.Spectateur.Prenom;
            }
            set
            {
                this.mReservation.Spectateur.Prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        /// <summary>
        /// Adresse du spectateur.
        /// </summary>
        public String Adresse
        {
            get
            {
                return this.mReservation.Spectateur.Adresse;
            }
            set
            {
                this.mReservation.Spectateur.Adresse = value;
                OnPropertyChanged("Adresse");
            }
        }

        /// <summary>
        /// Prix de la reservation.
        /// </summary>
        public double Prix
        {
            get
            {
                try
                {
                    int nb = this.mReservation.NombrePlacesReservees;
                    double prixU = this.mReservation.Match.Prix;
                    return nb * prixU;
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                Prix = value;
                OnPropertyChanged("Prix");
            }
        }

        public ViewModelReservation()
            :this(new Reservation())
        {
        }

        public ViewModelReservation(Reservation reserv)
            :base()
        {
            this.mReservation = reserv;
        }

    }
}
