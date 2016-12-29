using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NobetciEczane_IEO.CHZDataEntity;

namespace NobetciEczane_IEO.XMLDataParser
{
    public class NCZXMLDataParser
    {
        public NCZNobetciEczaneCollection Parse(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;

            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var entity = new NobetlerEntity();
            NCZNobetciEczaneCollection _collection = entity.Parse(doc);

            return _collection;
        }

        internal NCZIlceCollection ParseIlceler(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;

            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var entity = new IlcelerEntity();
            NCZIlceCollection _ilce = entity.Parse(doc);

            return _ilce;
        }
    }
}
