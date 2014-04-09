using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entité Equipe.
    /// </summary>
    public class Equipe :EntityObject
    {
        /// <summary>
        /// Liste des joueurs de l'equipe.
        /// </summary>
        public List<Joueur> Joueurs
        {
            get
            {
                return _mJoueurs;
            }
            set
            {
                _mJoueurs = value;
            }
        }
        private List<Joueur> _mJoueurs;

        /// <summary>
        /// Nom de l'equipe.
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
        /// Pays de l'equipe.
        /// </summary>
        public String Pays
        {
            get
            {
                return _mPays;
            }
            set
            {
                _mPays = value;
            }
        }
        private String _mPays;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Equipe()
            :this(-1,"Nom","Pays",new List<Joueur>())
        {
        }

        /// <summary>
        /// Constructeur complet.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="pays"></param>
        public Equipe(int id ,String nom, String pays, List<Joueur> listJoueurs)
            :base()
        {
            _mJoueurs = listJoueurs;
            _mNom = nom;
            _mPays = pays;
            Id = id;
        }

        override
        public String ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(_mNom).Append(";")
                .Append(_mPays).Append(";");
            foreach(Joueur j in Joueurs)
            {
                str.Append(j.ToString()).Append(";");
            }
                
            return str.ToString();
        }

        public void Add(Joueur j)
        {
            _mJoueurs.Add(j);
        }
    }
}
