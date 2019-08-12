using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        static Idal dal = null;
        private FactoryDal(){}
        static public Idal getDal()
        {
            if (dal == null)
                dal = new Dal_XML_imp();
            return dal;
        }
    }
}
