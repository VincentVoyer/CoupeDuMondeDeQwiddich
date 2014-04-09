using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace DAL
{
    public class SQLServeurDataLoader : DataLoader
    {
        public SQLServeurDataLoader()
        {
            ConnectionString = "Data Source=(LocalDB)\\v11.0;Initial Catalog=QuidditchWorldCup;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        }

    
        public override List<Coupe> GetCoupes()
        {
 
            String request = "select * from Coupes";
            Debug.WriteLine(String.Format("{1} -> getCoupe : {0}", request,this.GetType().Name));
            List<Coupe> cups = new List<Coupe>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(request, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cups.Add(new Coupe(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
                    }

                    connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return cups;
        }

        public override List<Match> GetMatchs()
        {
            String request = "select * from Matchs";
            Debug.WriteLine(String.Format("{1} -> getMatch : {0}", request, this.GetType().Name)); List<Match> matchs = new List<Match>();
            List<Coupe> cups = GetCoupes();
            List<Equipe> teams = GetEquipes();
            List<Stade> stades = GetStade();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(request, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Match m = new Match();
                        m.Id = reader.GetInt32(0);
                        m.CoupeId = reader.GetInt32(1);
                        m.Stade = stades.Where(s => s.Id == reader.GetInt32(2)).ToList().First();
                        m.EquipeDomicile = teams.Where(t => t.Id == reader.GetInt32(4)).ToList().First();
                        m.EquipeVisiteur = teams.Where(t => t.Id == reader.GetInt32(5)).ToList().First();
                        m.ScoreEquipeDomicile = reader.GetInt32(6);
                        m.ScoreEquipeVisiteur = reader.GetInt32(7);
                        m.Date = reader.GetDateTime(8);
                        m.Prix = reader.GetDouble(9);

                        matchs.Add(m);
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return matchs;
        }

        public override List<Equipe> GetEquipes()
        {
            String request = "select * from Equipes";
            Debug.WriteLine(String.Format("{1} -> GetEquipe : {0}", request, this.GetType().Name));
            List<Equipe> teams = new List<Equipe>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(request, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Equipe t = new Equipe();
                        t.Id = reader.GetInt32(0);
                        t.Pays = reader.GetString(1);
                        t.Nom = reader.GetString(2);
                        teams.Add(t);
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return teams;
        }

        public override List<Joueur> GetJoueurs()
        {
            String request = "select * from Joueurs";
            Debug.WriteLine(String.Format("{1} -> getJoueur : {0}", request, this.GetType().Name));
            List<Joueur> players = new List<Joueur>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(request, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Joueur j = new Joueur();
                        j.Id = reader.GetInt32(0);
                        j.Prenom = reader.GetString(1);
                        j.Nom = reader.GetString(2);
                        j.DateNaissance = reader.GetDateTime(3);
                        j.IdTeam = reader.GetInt32(4);
                        j.Poste = (PosteJoueur)reader.GetInt32(5);
                        j.Score = reader.GetInt32(7);
                        players.Add(j);

                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return players;

        }

        public override List<Stade> GetStade()
        {
            String request = "select * from Stades";
            Debug.WriteLine(String.Format("{1} -> getStade : {0}", request, this.GetType().Name));
            List<Stade> stades = new List<Stade>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(request, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Stade s = new Stade();
                        s.Id = reader.GetInt32(0);
                        s.Nom = reader.GetString(1);
                        s.Adresse = reader.GetString(2);
                        s.NombrePlaces = reader.GetInt32(3);
                        s.PourcentageCommission = reader.GetFloat(4);
                        stades.Add(s);
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return stades;
        }

        public override List<Reservation> GetReservation()
        {
            String request = "select * from Reservations";
            Debug.WriteLine(String.Format("{1} -> getReservation : {0}", request, this.GetType().Name));
            List<Reservation> reservs = new List<Reservation>();
            List<Spectateur> specs = GetSpectateurs();
            List<Match> matchs = GetMatchs();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(request, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Reservation r = new Reservation();
                        r.Id = reader.GetInt32(0);
                        r.Spectateur = specs.Where(s => s.Id == reader.GetInt32(1)).ToList().First();
                        r.Match = matchs.Where(m => m.Id == reader.GetInt32(2)).ToList().First();
                        r.NombrePlacesReservees = reader.GetInt32(3);
                        reservs.Add(r);
                        Console.WriteLine("resercations : " + reservs.Count);
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return reservs;
        }

        private List<Spectateur> GetSpectateurs()
        {
            String request = "select * from Spectateurs";
            Debug.WriteLine(String.Format("{1} -> getSpectateur : {0}", request, this.GetType().Name));
            List<Spectateur> specs = new List<Spectateur>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(request, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Spectateur s = new Spectateur();
                        s.Id = reader.GetInt32(0);
                        s.Prenom = reader.GetString(1);
                        s.Nom = reader.GetString(2);
                        s.DateNaissance = reader.GetDateTime(3);
                        s.Adresse = reader.GetString(4);
                        s.Email = reader.GetString(5);
                        specs.Add(s);
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return specs;
        }

        /*-------------------------------------------------------------------------------------*/
        public override void InsertCoupe(Coupe cup)
        {
        throw new NotImplementedException();
        }

        public override void InsertJoueur(Joueur joueur)
        {
            String request = String.Format("insert Joueurs (Prenom,Nom,DateNaissance,EquipeID,PosteID,Score) values (\'{0}\',\'{1}\',\'{2}{3:00}{4:00}\',{5},{6},{7})", joueur.Prenom, joueur.Nom, joueur.DateNaissance.Year,joueur.DateNaissance.Month, joueur.DateNaissance.Day, joueur.IdTeam,(int)joueur.Poste,joueur.Score);
            Debug.WriteLine(String.Format("{1} -> InsertJoueur : {0}", request, this.GetType().Name));
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(request, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public override void InsertMatch(Match match)
        {
            String request = String.Format("insert Matchs (CoupeID,StadeID,DomicileID,VisiteurID,ScoreDomicile,ScoreVisiteur,Date,Prix) values ({0},{1},{2},{3},{4},{5},\'{6}{7:00}{8:00}\',{9})",match.CoupeId ,match.Stade.Id ,match.EquipeDomicile.Id , match.EquipeVisiteur.Id,match.ScoreEquipeDomicile,match.ScoreEquipeVisiteur,match.Date.Year,match.Date.Month,match.Date.Day,match.Prix);
            Debug.WriteLine(String.Format("{1} -> InsertMatch : {0}", request, this.GetType().Name));
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(request, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public override void InsertEquipe(Equipe team)
        {
            String request = String.Format("insert Equipes (Pays,Nom) values (\'{0}\',\'{1}\')", team.Pays,team.Nom);
            Debug.WriteLine(String.Format("{1} -> InsertEquipe : {0}", request, this.GetType().Name)); 
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(request, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public override void InsertReservation(Reservation reservation)
        {
        throw new NotImplementedException();
        }

        public override void InsertStade(Stade stade)
        {
            String request = String.Format("insert Stades (Nom,Adresse,NombrePlacesDisponibles,PourcentageCommision) values (\'{0}\',\'{1}\',{2},{3})", stade.Nom, stade.Adresse, stade.NombrePlaces, stade.PourcentageCommission);
            Debug.WriteLine(String.Format("{1} -> InsertStade : {0}", request, this.GetType().Name));
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(request, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        /*-------------------------------------------------------------------------------------*/

        public override void DeleteCoupe(Coupe cup)
        {
            String request = String.Format("delete Coupes where id = {0}",cup.Id);
            Debug.WriteLine(String.Format("{1} -> DeleteCoupe : {0}", request, this.GetType().Name));
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(request, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void DeleteJoueur(Joueur joueur)
        {
            String request = String.Format("delete Joueurs where id = {0}", joueur.Id);
            Debug.WriteLine(String.Format("{1} -> DeleteJoueur : {0}", request, this.GetType().Name));

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(request, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            
        }

        public override void DeleteMatch(Match match)
        {
                String request = String.Format("delete Matchs where id = {0}", match.Id);
                Debug.WriteLine(String.Format("{1} -> DeleteMatch : {0}", request, this.GetType().Name));

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(request, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            
        }

        public override void DeleteEquipe(Equipe team)
        {
            
                String request = String.Format("delete Equipes where id = {0}", team.Id);
                foreach(Joueur j in GetJoueurs())
                {
                    if (j.IdTeam == team.Id)
                        DeleteJoueur(j);
                }
                Debug.WriteLine(String.Format("{1} -> DeleteEquipe : {0}", request, this.GetType().Name));

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(request, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
        }

        public override void DeleteReservation(Reservation reservation)
        {
        throw new NotImplementedException();
        }

        public override void DeleteStade(Stade stade)
        {
                String request = String.Format("delete Stades where id = {0}", stade.Id);
                Debug.WriteLine(String.Format("{1} -> DeleteStade : {0}", request, this.GetType().Name));

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(request, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
        }
        /*-------------------------------------------------------------------------------------*/

        public override void UpDateCoupe(Coupe cup)
        {
            throw new NotImplementedException();
        }

        public override void UpDateJoueur(Joueur joueur)
        {
            String request = String.Format("update Joueurs set Nom = \'{1}\', Prenom = \'{0}\', PosteID = {3}, Score = {4} where id = {2}", joueur.Prenom, joueur.Nom, joueur.Id, (int)joueur.Poste, joueur.Score);
            Debug.WriteLine(String.Format("{1} -> UpdateJoueur : {0}", request, this.GetType().Name));

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(request, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public override void UpDateMatch(Match match)
        {
            try
            {
                String request = String.Format("update Matchs set CoupeId = {1}, StadeID = {2}, DomicileID = {3}, VisiteurID = {4}, ScoreDomicile = {5}, ScoreVisiteur = {6}, Date = \'{7}{8:00}{9:00}\' Prix = {10} where id = {0}", match.Id, match.CoupeId, match.Stade.Id, match.EquipeDomicile.Id, match.EquipeVisiteur.Id, match.ScoreEquipeDomicile, match.ScoreEquipeVisiteur, match.Date.Year, match.Date.Month, match.Date.Day, match.Prix);
                Debug.WriteLine(String.Format("{1} -> UpdateMatch : {0}", request, this.GetType().Name));

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(request, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
        }

        public override void UpDateEquipe(Equipe team)
        {
            try
            {
                String request = String.Format("update Equipes set Pays = \'{1}\',Nom = \'{2}\' where id = {0}", team.Id,team.Pays,team.Nom);
                Debug.WriteLine(String.Format("{1} -> UpdateEquipe : {0}", request, this.GetType().Name));

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(request, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
        }

        public override void UpDateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public override void UpDateStade(Stade stade)
        {
            try
            {
                String request = String.Format("update Stades set Nom = \'{1}\', Adresse = \'{1}\', NombrePlacesDisponibles = {3}, PourcentageCommision = {4} where id = {0}", stade.Id,stade.Nom,stade.Adresse,stade.NombrePlaces,stade.PourcentageCommission);
                Debug.WriteLine(String.Format("{1} -> UpdateStade : {0}", request, this.GetType().Name));

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(request, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
        }
    }
}

