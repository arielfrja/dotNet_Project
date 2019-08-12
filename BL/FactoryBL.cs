using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

        public class FactoryBL
        {
            static IBL bl = null;
            private FactoryBL() { }
            static public IBL GetBl()
            {
                if (bl == null)
                    bl = new BL_imp();
                return bl;
            }
        }
}
