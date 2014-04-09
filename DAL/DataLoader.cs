using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public abstract class DataLoader
    {
        protected String ConnectionString
        {
            get
            {
                return _mConnectionString;
            }
            set
            {
                _mConnectionString = value;
            }
        }
        private String _mConnectionString;

        public abstract List<Coupe> GetCoupes();

        public abstract List<Match> GetMatchs();

        public abstract List<Equipe> GetEquipes();

        public abstract List<Stade> GetStade();

        public abstract List<Joueur> GetJoueurs();

        public abstract List<Reservation> GetReservation();
        /*-----------------------------------------------------------------------------*/
        public abstract void InsertCoupe(Coupe cup);

        public abstract void InsertJoueur(Joueur joueur);

        public abstract void InsertMatch(Match match);

        public abstract void InsertEquipe(Equipe team);

        public abstract void InsertStade(Stade stade);

        public abstract void InsertReservation(Reservation reservation);
        /*-----------------------------------------------------------------------------*/
        public abstract void DeleteCoupe(Coupe cup);

        public abstract void DeleteJoueur(Joueur joueur);

        public abstract void DeleteMatch(Match match);

        public abstract void DeleteEquipe(Equipe team);

        public abstract void DeleteStade(Stade stade);

        public abstract void DeleteReservation(Reservation reservation);
        /*-----------------------------------------------------------------------------*/
        public abstract void UpDateCoupe(Coupe cup);

        public abstract void UpDateJoueur(Joueur joueur);

        public abstract void UpDateMatch(Match match);

        public abstract void UpDateEquipe(Equipe team);

        public abstract void UpDateStade(Stade stade);

        public abstract void UpDateReservation(Reservation reservation);
    }
}
