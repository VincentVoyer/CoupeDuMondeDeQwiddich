using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConcretDataBaseManager : DataBaseManager
    {
        public ConcretDataBaseManager()
        {
            Data = new SQLServeurDataLoader();
        }
    }
}
