using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NobetciEczane_IEO.XMLDataParser
{
    public class NobetlerEntity
    {
        internal NCZNobetciEczaneCollection Parse(XmlDocument doc)
        {
            var collection = new NCZNobetciEczaneCollection();

            foreach (XmlNode item in doc.SelectNodes("nobetler/nobet"))
            {
                collection.Add(new NobetEntity().Parse(item));
            }

            return collection;
        }
    }
}
