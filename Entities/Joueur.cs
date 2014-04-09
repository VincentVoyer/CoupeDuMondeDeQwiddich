using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Une Entité joueur.
    /// </summary>
    public class Joueur : Personne
    {
        public int IdTeam
        {
            get
            {
                return _idTeam;
            }
            set
            {
                _idTeam = value;
            }
        }
        private int _idTeam;

        /// <summary>
        /// Nombre de sélection du joueur.
        /// </summary>
        public int NbSelection
        {
            get
            {
                return _mNbSelection;
            }
            set
            {
                _mNbSelection = value;
            }
        }
        private int _mNbSelection;

        /// <summary>
        /// Poste du joueur.
        /// </summary>
        public PosteJoueur Poste
        {
            get
            {
                return _mPoste;
            }
            set
            {
                _mPoste = value;
            }
        }
        private PosteJoueur _mPoste;

        /// <summary>
        /// Score du joueur.
        /// </summary>
        public int Score
        {
            get
            {
                return _mScore;
            }
            set
            {
                _mScore = value;
            }
        }
        private int _mScore;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Joueur()
            :this(-1, "Nom", "Prenom", 0,PosteJoueur.None,0)
        {
        }

        /// <summary>
        /// COnstructeur complet.
        /// </summary>
        /// <param name="nbSelection">nombre de sélection du joueur.</param>
        /// <param name="poste">poste du joueur.</param>
        /// <param name="score">score du joueur.</param>
        public Joueur(int id, String nom , String prenom , int nbSelection, PosteJoueur poste, int score) 
            :base()
        {
            _mNbSelection = nbSelection;
            _mPoste = poste;
            _mScore = score;
            Nom = nom;
            Prenom = prenom;
            Id = id;
        }

        override
        public String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Nom).Append(";")
              .Append(Prenom).Append(";")
              .Append(Poste).Append(";")
              .Append(NbSelection).Append(";")
              .Append(Score);

            return sb.ToString();
        }
    }
}
