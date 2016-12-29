using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobetciEczane_IEO
{
    public class NCZNobetciEczaneCollection:List<NCZNobetciEczane>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
