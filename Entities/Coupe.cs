using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entité Coupe.
    /// </summary>
    public class Coupe : EntityObject
    {
        /// <summary>
        /// Année de la coupe.
        /// </summary>
        public int Year
        {
            get
            {
                return _mYear;
            }
            set
            {
                _mYear = value;
            }
        }
        private int _mYear;

        /// <summary>
        /// Libelle de la coupe
        /// </summary>
        public string Libelle
        {
          get { return _mLibelle; }
          set { _mLibelle = value; }
        }

        private string _mLibelle;



        /// <summary>
        /// Contructeur par défaut.
        /// </summary>
        public Coupe()
            :this(-1,0,"Coupe")
        {
        }

        /// <summary>
        /// Constructeur complet.
        /// </summary>
        /// <param name="year"></param>
        public Coupe(int id, int year, string libelle)
            : base()
        {
            Libelle = libelle;
            Id = id;
            _mYear = year;
        }
    }
}
