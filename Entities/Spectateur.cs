using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entité spectateur.
    /// </summary>
    public class Spectateur : Personne
    {
        /// <summary>
        /// L'adresse du spectateur.
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
        /// L'email du spectateur.
        /// </summary>
        public String Email
        {
            get
            {
                return _mEmail;
            }
            set
            {
                _mEmail = value;
            }
        }
        private String _mEmail;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Spectateur()
            :this(-1,"Nom","Prenom","Adresse", "Email")
        {
        }

        /// <summary>
        /// Constructeur complet.
        /// </summary>
        /// <param name="adresse">adresse du spectateur.</param>
        /// <param name="email">email du spectateur.</param>
        public Spectateur(int id , String nom, String prenom ,String adresse, String email)
            :base()
        {
            _mEmail = email;
            _mAdresse = adresse;
            Nom = nom;
            Prenom = prenom;
            Id = id;
        }
    }
}
