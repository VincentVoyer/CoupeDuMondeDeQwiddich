using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entite reservation.
    /// </summary>
    public class Reservation  : EntityObject
    {
        /// <summary>
        /// Match reserve.
        /// </summary>
        public Match Match
        {
            get
            {
                return _mMatch;
            }
            set
            {
                _mMatch = value;
            }
        }
        private Match _mMatch;

        /// <summary>
        /// Nombre de place reservees.
        /// </summary>
        public int NombrePlacesReservees
        {
            get
            {
                return _mNbPlacesReservees;
            }
            set
            {
                _mNbPlacesReservees = value;
            }
        }
        private int _mNbPlacesReservees;

        /// <summary>
        /// le spectateur qui a reserve.
        /// </summary>
        public Spectateur Spectateur
        {
            get
            {
                return _mSpectateur;
            }
            set
            {
                _mSpectateur = value;
            }
        }
        private Spectateur _mSpectateur;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Reservation()
            : this(-1, new Match(), 0, new Spectateur())
        {
        }

        /// <summary>
        /// Constructeur Complet.
        /// </summary>
        /// <param name="match">match reserve.</param>
        /// <param name="nbPlaces">nombre de places reservees.</param>
        /// <param name="spec">spectateur qui reserve.</param>
        public Reservation(int id , Match match, int nbPlaces, Spectateur spec)
            :base()
        {
            _mMatch = match;
            _mNbPlacesReservees = nbPlaces;
            _mSpectateur = spec;
            Id = id;
        }
    }
}
