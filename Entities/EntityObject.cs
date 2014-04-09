using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Entité Générale.
    /// </summary>
    public abstract class EntityObject
    {
        /// <summary>
        /// Identifiant de l'entité.
        /// </summary>
        public int Id
        {
            get
            {
                return _mId;
            }
            set
            {
                _mId = value;
            }

        }
        private int _mId;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public EntityObject()
            :this(-1)
        {
        }

        /// <summary>
        /// Constructeur complet.
        /// </summary>
        /// <param name="id">id de l'entité.</param>
        public EntityObject(int id)
        {
            _mId = id;
        }

        /// <summary>
        /// Protocole d'égalité de l'entité.
        /// </summary>
        /// <param name="other">entité à comparer.</param>
        /// <returns>true si égaux ou false.</returns>
        public bool Equals(EntityObject other)
        {
            if (other != null)
            {
                return _mId == other.Id;
            }

            return false;
        }

        /// <summary>
        /// Donne le hashcode de l'entité.
        /// </summary>
        /// <returns>le hashcode de l'entité.</returns>
        override
        public int GetHashCode()
        {
            return Id.GetHashCode() * 31;
        }
    }
}
