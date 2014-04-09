using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entité Stade.
    /// </summary>
    public class Stade : EntityObject
    {
        /// <summary>
        /// Adresse du stade.
        /// </summary>
        public String Adresse
        {
            get
            {
                return _mAdresse;
            }
            set
            {
                _mAdresse = value;
            }
        }
        private String _mAdresse;

        /// <summary>
        /// Nom du stade.
        /// </summary>
        public String Nom
        {
            get
            {
                return _mNom;
            }
            set
            {
                _mNom = value;
            }
        }
        private String _mNom;

        /// <summary>
        /// Nombre de place du stade.
        /// </summary>
        public int NombrePlaces
        {       
            get
            {
                return _mNbPlaces;
            }
            set
            {
                _mNbPlaces = value;
            }
        }
        private int _mNbPlaces;

        /// <summary>
        /// Pourcentage de commission du stade.
        /// </summary>
        public double PourcentageCommission
{
            get
            {
                return _mPourcentageCommission;
            }
            set
            {
                _mPourcentageCommission = value;
            }
        }
        private double _mPourcentageCommission;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Stade()
            :this(-1,"Adresse","Nom",-1,0)
        {
        }

        /// <summary>
        /// Constructeur complet.
        /// </summary>
        /// <param name="adresse">Adresse du stade.</param>
        /// <param name="nom">Nom du stade.</param>
        /// <param name="nombrePlaces">Nombre de place du stade.</param>
        /// <param name="pourcentageCommission">Commission du stade en pourcentage.</param>
        public Stade(int id, String adresse, String nom, int nombrePlaces, double pourcentageCommission)
            :base()
        {
            Id = id;
            _mAdresse = adresse;
            _mNom = nom;
            _mNbPlaces = nombrePlaces;
            _mPourcentageCommission = pourcentageCommission;
        }

        override
        public String ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(_mNom).Append(";")
                .Append(_mNbPlaces).Append(";")
                .Append(_mAdresse).Append(";")
                .Append(_mPourcentageCommission);

            return str.ToString();
        }
    }
}
