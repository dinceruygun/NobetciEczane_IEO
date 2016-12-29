using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NobetciEczane_IEO.XMLDataParser
{
    public class IlcelerEntity
    {
        internal NCZIlceCollection Parse(XmlDocument doc)
        {
            var collection = new NCZIlceCollection();

            foreach (XmlNode item in doc.SelectNodes("ilceler/ilce"))
            {
                collection.Add(new IlceEntity().Parse(item));
            }

            return collection;
        }
    }
}
