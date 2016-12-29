using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NobetciEczane_IEO.XMLDataParser
{
    public class IlceEntity
    {
        internal NCZIlce Parse(XmlNode item)
        {
            var ilce = new NCZIlce();

            if (item == null) return null;


            ilce.ad = item.SelectSingleNode("ad").InnerText;
            ilce.id = int.Parse(item.SelectSingleNode("id").InnerText);



            return ilce;
        }
    }
}
