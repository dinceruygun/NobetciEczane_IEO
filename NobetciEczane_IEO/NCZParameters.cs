using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobetciEczane_IEO
{
    public static class NCZParameters
    {
        static NCZConfigParameters _parameters;

        static NCZParameters()
        {
            _parameters = new NCZConfigParameters();
        }

        public static NCZConfigParameters Parameters
        {
            get
            {
                return _parameters;
            }
        }
    }
}
