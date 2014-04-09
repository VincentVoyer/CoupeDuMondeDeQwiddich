using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Diagnostics;

namespace BL
{
    public class CoupeManager
    {
        private List<Joueur> _listJoueurs;
        private List<Stade> _listStades;
        private List<Match> _listMatchs;
        private List<Coupe> _listCoupes;
        private List<Equipe> _listEquipes;
        private List<Reservation> _listReservations;

        /// <summary>
        /// Constructeur du manager.
        /// </summary>
        public CoupeManager()
        {
            // récupère les informations depuis la DAL
            DalManager dal = DalManager.Instance;

            _listCoupes = dal.GetListCoupe();
            _listStades = dal.GetListStade();
            _listJoueurs = dal.GetListJoueurs();
            _listEquipes = dal.GetListEquipe();
            _listMatchs = dal.GetListMatch();
            _listReservations = dal.GetListReservation();
        }

        /// <summary>
        /// Retourne la liste des match classé par date.
        /// </summary>
        /// <returns></returns>
        public List<String> GetMatchClasse(Coupe coupe)
        {
            return _listMatchs.Where(m => m.CoupeId == coupe.Id).Select(m => m.ToString()).ToList();
        }

        /// <summary>
        /// Retourne la liste des Stades pour lesquels au moins un Match est programmé.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<String> GetListStadeWithMatch(Coupe coupe)
        {
            return _listMatchs.Where(m => m.CoupeId == coupe.Id).ToList().Select(m => m.Stade.ToString()).ToList();
        }

        /// <summary>
        /// Retourne la liste des Stades.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stade> GetListStade()
        {
            return _listStades;
        }

        /// <summary>
        /// Retourne la liste des attrapeurs qui ont joués à domicile.
        /// </summary>
        /// <returns></returns>
        public List<String> GetListDomicileAttrapeur(Coupe coupe)
        {
            return _listMatchs.Where(m => m.CoupeId == coupe.Id)
                                .Select(m => m.EquipeDomicile)
                                .Select(t => t.Joueurs.Where(j => j.Poste == PosteJoueur.Attrapeur).ToString())
                                .ToList();
            
        }

        /// <summary>
        /// Retourne la liste des coupes.
        /// </summary>
        /// <returns></returns>
        public List<Coupe> GetListCoupes()
        {
            return _listCoupes;
        }

        /// <summary>
        /// Retourne la liste des équipes.
        /// </summary>
        /// <returns></returns>
        public List<Equipe> GetListEquipe()
        {
            return _listEquipes;
        }

        public List<Joueur> GetListJoueur(int idTeam)
        {
            return _listJoueurs.Where(j => j.IdTeam == idTeam).ToList();
        }

        /// <summary>
        /// Retourne la liste des matchs selon la coupe.
        /// </summary>
        /// <param name="coupe"></param>
        /// <returns></returns>
        public IEnumerable<Match> GetListMatch(Coupe coupe)
        {
            return _listMatchs.Where(m => m.CoupeId == coupe.Id).ToList();
        }

        public List<Reservation> GetListReservation()
        {
            return _listReservations
                .OrderBy(r => r.Spectateur.Nom)
                .ToList();
        }

        public void AddMatch(Match match)
        {
            _listMatchs.Add(match);
        }

        public void AddTeam(Equipe equipe)
        {
            _listEquipes.Add(equipe);
        }

        public void AddCoupe(Coupe coupe)
        {
            _listCoupes.Add(coupe);
        }

        public void AddJoueur(Joueur joueur)
        {
                _listJoueurs.Add(joueur);
        }

        public void AddStade(Stade stade)
        {
            _listStades.Add(stade);
        }

        public void AddReservation(Reservation reserv)
        {
            _listReservations.Add(reserv);
        }

        public void DelMatch(Match match)
        {
            try
            {
                if(match.Id != -1)
                    DalManager.Instance.DeleteMatch(match);
                _listMatchs.Remove(match);
            }
            catch (Exception e) { }
        }

        public void DelTeam(Equipe equipe)
        {
            try
            {
                if (equipe.Id != -1)
                    DalManager.Instance.DeleteEquipe(equipe);
                _listEquipes.Remove(equipe);
            }
            catch (Exception e) { }
        }

        public void DelCoupe(Coupe coupe)
        {
            _listCoupes.Remove(coupe);
        }

        public void DelJoueur(Joueur joueur)
        {
            try
            {
                if (joueur.Id != -1)
                    DalManager.Instance.DeleteJoueur(joueur);
                _listJoueurs.Remove(joueur);
            }
            catch (Exception e) { }
        }

        public void DelStade(Stade stade)
        {
            try
            {
                if (stade.Id != -1)
                    DalManager.Instance.DeleteStade(stade);
                _listStades.Remove(stade);
            }
            catch (Exception e) { }
        }

        public void DelReservation(Reservation reserv)
        {
            _listReservations.Remove(reserv);
        }

        public void SaveJoueur()
        {
            Debug.WriteLine(String.Format("SaveJoueur "));
            foreach(Joueur j in _listJoueurs)
            {
                if(j.Id == -1)
                {
                    DalManager.Instance.AddJoueur(j);
                }
                else
                {
                    DalManager.Instance.ModifyJoueur(j);
                }
            }
            _listJoueurs = DalManager.Instance.GetListJoueurs();
        }
    
        public void SaveEquipe()
        {
            foreach (Equipe e in _listEquipes)
            {
                if (e.Id == -1)
                {
                    DalManager.Instance.AddEquipe(e);
                }
                else
                {
                    DalManager.Instance.ModifyEquipe(e);
                }
            }
            _listEquipes = DalManager.Instance.GetListEquipe();
        }

        public void SaveStade()
        {
            foreach (Stade s in _listStades)
            {
                if (s.Id == -1)
                {
                    DalManager.Instance.AddStade(s);
                }
                else
                {
                    DalManager.Instance.ModifyStade(s);
                }
            }
            _listStades = DalManager.Instance.GetListStade();
            foreach(Match m in _listMatchs)
            {
                m.Stade = _listStades.Where(s => s.Id == m.Stade.Id).ToList().First();
            }
        }

        public void SaveMatch()
        {
            foreach (Match m in _listMatchs)
            {
                if (m.Id == -1)
                {
                    DalManager.Instance.AddMatch(m);
                }
                else
                {
                    DalManager.Instance.ModifyMatch(m);
                }
            }
            _listMatchs = DalManager.Instance.GetListMatch();
            foreach (Match m in _listMatchs)
            {
                m.Stade = _listStades.Single(s => s.Id == m.Stade.Id);
                m.EquipeDomicile = _listEquipes.Single(t => t.Id == m.EquipeDomicile.Id);
                m.EquipeVisiteur = _listEquipes.Single(t => t.Id == m.EquipeVisiteur.Id);
            }
        }
    }
}
