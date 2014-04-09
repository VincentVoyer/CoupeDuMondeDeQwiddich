using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public abstract class DataBaseManager
    {
        public DataLoader Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        private DataLoader data;

        public List<Coupe> GetCoupes()
        {
            return data.GetCoupes();
        }

        public List<Match> GetMatchs()
        {
            return data.GetMatchs();
        }

        public List<Equipe> GetEquipes()
        {
            return data.GetEquipes();
        }

        public List<Joueur> GetJoueurs()
        {
            return data.GetJoueurs();
        }

        public List<Reservation> GetReservation()
        {
            return data.GetReservation();
        }

        public List<Stade> GetStades()
        {
            return data.GetStade();
        }
        /*-----------------------------------------------------------------------------*/
        public void InsertCoupe(Coupe cup)
        {
            data.InsertCoupe(cup);
        }

        public void InsertJoueur(Joueur joueur)
        {
            data.InsertJoueur(joueur);
        }

        public void InsertMatch(Match match)
        {
            data.InsertMatch(match);
        }

        public void InsertEquipe(Equipe team)
        {
            data.InsertEquipe(team);
        }
        public void InsertReservation(Reservation reservation)
        {
            data.InsertReservation(reservation);
        }

        public void InsertStade(Stade stade)
        {
            data.InsertStade(stade);
        }
        /*-----------------------------------------------------------------------------*/
        public void DeleteCoupe(Coupe cup)
        {
            data.DeleteCoupe(cup);
        }

        public void DeleteJoueur(Joueur joueur)
        {
            data.DeleteJoueur(joueur);
        }

        public void DeleteMatch(Match match)
        {
            data.DeleteMatch(match);
        }

        public void DeleteEquipe(Equipe team)
        {
            data.DeleteEquipe(team);
        }

        public void DeleteReservation(Reservation reservation)
        {
            data.DeleteReservation(reservation);
        }

        public void DeleteStade(Stade stade)
        {
            data.DeleteStade(stade);
        }
        /*-----------------------------------------------------------------------------*/
        public void UpDateCoupe(Coupe cup)
        {
            data.UpDateCoupe(cup);
        }

        public void UpDateJoueur(Joueur joueur)
        {
            data.UpDateJoueur(joueur);
        }

        public void UpDateMatch(Match match)
        {
            data.UpDateMatch(match);
        }

        public void UpDateEquipe(Equipe team)
        {
            data.UpDateEquipe(team);
        }

        public void UpDateReservation(Reservation reservation)
        {
            data.UpDateReservation(reservation);
        }

        public void UpDateStade(Stade stade)
        {
            data.UpDateStade(stade);
        }
    }
}
