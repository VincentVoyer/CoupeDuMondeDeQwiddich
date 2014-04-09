using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    /// <summary>
    /// Stub class
    /// </summary>
    public class DalManager
    {

        DataBaseManager _manager = new ConcretDataBaseManager();
        /* liste des Joueurs */
        List<Joueur> _listJoueurs;
        /* liste des stades */
        List<Stade> _listStades;
        /* liste des matchs */
        List<Match> _listMatchs;
        /* liste des coupes */
        List<Coupe> _listCoupes;
        /* liste des équipes*/ 
        List<Equipe> _listEquipe;
        /* liste des reservations*/
        List<Reservation> _listReservation;

        private static Object _myToken = new Object();

        /**instance de la couche de données.*/
        public static  DalManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock(_myToken)
                    {
                        if(mInstance == null)
                            mInstance = new DalManager();
                    }
                }
                    
                return mInstance;
            }
        }
        private static DalManager mInstance = null;

        /// <summary>
        /// Constructeur de la stub
        /// </summary>
        private DalManager()
        {
            _listCoupes = _manager.GetCoupes();
            _listStades = _manager.GetStades();
            _listEquipe = _manager.GetEquipes();
            _listJoueurs = _manager.GetJoueurs();
            _listMatchs = _manager.GetMatchs();
            _listReservation = _manager.GetReservation();

            foreach(Reservation r in _listReservation)
            {
                r.Match = _listMatchs.Where(m => m.Id == r.Match.Id).ToList().First();
            }

            foreach(Match m in _listMatchs)
            {
                m.Stade = _listStades.Where(s => s.Id == m.Stade.Id).ToList().First();
                m.EquipeDomicile = _listEquipe.Where(t => t.Id == m.EquipeDomicile.Id).ToList().First();
                m.EquipeVisiteur = _listEquipe.Where(t => t.Id == m.EquipeVisiteur.Id).ToList().First();
            }
        }


        /// <summary>
        /// Retourne la liste des joueurs existants.
        /// </summary>
        /// <returns></returns>
        public List<Joueur> GetListJoueurs()
        {
            return _listJoueurs;
        }

        /// <summary>
        /// Retourne la liste des stades existants.
        /// </summary>
        /// <returns></returns>
        public List<Stade> GetListStade()
        {
            return _listStades;
        }

        /// <summary>
        /// Retourne la liste des matchs existants.
        /// </summary>
        /// <returns></returns>
        public List<Match> GetListMatch()
        {
            return _listMatchs;
        }

        /// <summary>
        /// Retourne la liste des coupes existants.
        /// </summary>
        /// <returns></returns>
        public List<Coupe> GetListCoupe()
        {
            return _listCoupes;
        }

        public List<Equipe> GetListEquipe()
        {
            return _listEquipe;
        }

        public List<Reservation> GetListReservation()
        {
            return _listReservation;
        }

        public void AddJoueur(Joueur joueur)
        {
            _manager.InsertJoueur(joueur);
        }

        public void DeleteJoueur(Joueur joueur)
        {
            _manager.DeleteJoueur(joueur);
        }

        public void ModifyJoueur(Joueur joueur)
        {
            _manager.UpDateJoueur(joueur);
        }

        public void AddEquipe(Equipe equipe)
        {
            _manager.InsertEquipe(equipe);
        }

        public void DeleteEquipe(Equipe equipe)
        {
            _manager.DeleteEquipe(equipe);
        }

        public void ModifyEquipe(Equipe equipe)
        {
            _manager.UpDateEquipe(equipe);
        }

        public void AddStade(Stade stade)
        {
            _manager.InsertStade(stade);
        }

        public void DeleteStade(Stade stade)
        {
            _manager.DeleteStade(stade);
        }

        public void ModifyStade(Stade stade)
        {
            _manager.UpDateStade(stade);
        }

        public void AddMatch(Match match)
        {
            _manager.InsertMatch(match);
        }

        public void DeleteMatch(Match match)
        {
            _manager.DeleteMatch(match);
        }

        public void ModifyMatch(Match match)
        {
            _manager.UpDateMatch(match);
        }
    }
}
