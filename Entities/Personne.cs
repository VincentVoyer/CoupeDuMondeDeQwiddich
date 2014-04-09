using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entité Personne.
    /// </summary>
    public abstract class Personne : EntityObject
    {
        /// <summary>
        /// Date de naissance de la personne.
        /// </summary>
        public DateTime DateNaissance
        {
            get
            {
                return _mDateNaissance;
            }
            set
            {
                _mDateNaissance = value;
            }
        }
        private DateTime _mDateNaissance;

        /// <summary>
        /// Nom de la personne.
        /// </summary>
        public string Nom
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
        private string _mNom;

        /// <summary>
        /// Prénom de la personne.
        /// </summary>
        public string Prenom
        {
            get
            {
                return _mPrenom;
            }
            set
            {
                _mPrenom = value;
            }
        }
        private string _mPrenom;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Personne()
            :this(-1,"Nom","Prenom",DateTime.Now)
        {
        }

        /// <summary>
        /// COntructeur complet.
        /// </summary>
        /// <param name="nom">nom de la personne.</param>
        /// <param name="prenom">prénom de la personne.</param>
        /// <param name="naissance">date de naissance de la personne.</param>
        public Personne(int id , string nom, string prenom, DateTime naissance)
            :base()
        {
            _mNom = nom;
            _mPrenom = prenom;
            _mDateNaissance = naissance;
            Id = id;
        }
    }
}
