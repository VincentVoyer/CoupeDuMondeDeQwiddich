using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//test changement
namespace Entities
{
    /// <summary>
    /// Entite match.
    /// </summary>
    public class Match : EntityObject
    {
        /// <summary>
        /// Id de la coupe.
        /// </summary>
        public int CoupeId
        {
            get
            {
                return _mCoupeID;
            }
            set
            {
                _mCoupeID = value;
            }
        }
        private int _mCoupeID;

        /// <summary>
        /// Date du match.
        /// </summary>
        public DateTime Date
               {
            get
            {
                return _mDate;
            }
            set
            {
                _mDate = value;
            }
        }
        private DateTime _mDate;

        /// <summary>
        /// Equipe domicile.
        /// </summary>
        public Equipe EquipeDomicile
        {
            get
            {
                return _mEquipeDomicile;
            }
            set
            {
                _mEquipeDomicile = value;
            }
        }
        private Equipe _mEquipeDomicile;
        
        /// <summary>
        /// Equipe extérieur.
        /// </summary>
        public Equipe EquipeVisiteur
        {
            get
            {
                return _mEquipeVisiteur;
            }
            set
            {
                _mEquipeVisiteur = value;
            }
        }
        private Equipe _mEquipeVisiteur;
        
        /// <summary>
        /// Prix du match.
        /// </summary>
        public double Prix
        {
            get
            {
                return _mPrix;
            }
            set
            {
                _mPrix = value;
            }
        }
        private double _mPrix;
        
        /// <summary>
        /// Score equipe domicile.
        /// </summary>
        public int ScoreEquipeDomicile
        {
            get
            {
                return _mScoreEquipeDomicile;
            }
            set
            {
                _mScoreEquipeDomicile = value;
            }
        }
        private int _mScoreEquipeDomicile;

        /// <summary>
        /// Score equipe visiteur.
        /// </summary>
        public int ScoreEquipeVisiteur
        {
            get
            {
                return _mScoreEquipeVisiteur;
            }
            set
            {
                _mScoreEquipeVisiteur = value;
            }
        }
        private int _mScoreEquipeVisiteur;

        /// <summary>
        /// Stade du match.
        /// </summary>
        public Stade Stade
        {
            get
            {
                return mStade;
            }
            set
            {
                mStade = value;
            }
        }
        private Stade mStade;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Match()
            : this(-1, -1, DateTime.Now, new Equipe(), new Equipe(), 0d, 0, 0, new Stade())
        {
        }

        /// <summary>
        /// Constructeur complet.
        /// </summary>
        /// <param name="coupe">id de la coupe.</param>
        /// <param name="date">date du match.</param>
        /// <param name="domicile">équipe qui joue à domicile.</param>
        /// <param name="visiteur">équipe qui joue à l'extérieur.</param>
        /// <param name="prix">prix du match.</param>
        /// <param name="scoreDomicile">score de l'équipe à domicile.</param>
        /// <param name="scoreVisiteur">score de l'équipe visiteur.</param>
        /// <param name="stade">Stade du match.</param>
        public Match(int id, int coupe, DateTime date, Equipe domicile, Equipe visiteur, double prix, int scoreDomicile, int scoreVisiteur, Stade stade)
        {
            _mCoupeID = coupe;
            _mEquipeDomicile = domicile;
            _mEquipeVisiteur = visiteur;
            _mPrix = prix;
            _mScoreEquipeDomicile = scoreDomicile;
            _mScoreEquipeVisiteur = scoreVisiteur;
            mStade = stade;
            Id = id;
        }

       override
       public String ToString()
       {
           StringBuilder str = new StringBuilder();

           str.Append(_mCoupeID).Append(";")
               .Append(_mDate).Append(";")
               .Append(_mEquipeDomicile).Append(";")
               .Append(_mEquipeVisiteur).Append(";")
               .Append(_mPrix).Append(";")
               .Append(_mScoreEquipeDomicile).Append(";")
               .Append(_mScoreEquipeVisiteur).Append(";")
               .Append(mStade);

           return str.ToString();
       }
    }
}
