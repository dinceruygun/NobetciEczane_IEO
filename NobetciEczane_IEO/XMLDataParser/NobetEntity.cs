using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NobetciEczane_IEO.XMLDataParser
{
    public class NobetEntity
    {
        internal NCZNobetciEczane Parse(XmlNode item)
        {
            var eczane = new NCZNobetciEczane();

            if (item == null) return null;
            

            eczane.adres = item.SelectSingleNode("adres").InnerText;
            eczane.ilce = int.Parse(item.SelectSingleNode("ilce").InnerText);
            eczane.tarih = DateTime.ParseExact(item.SelectSingleNode("tarih").InnerText, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            eczane.eczane = item.SelectSingleNode("eczane").InnerText;
            eczane.eczaci = item.SelectSingleNode("eczaci").InnerText;
            eczane.tel = item.SelectSingleNode("tel").InnerText;
            eczane.fax = item.SelectSingleNode("fax").InnerText;
            eczane.eczid = int.Parse(item.SelectSingleNode("eczid").InnerText);
            eczane.bolgeid = int.Parse(item.SelectSingleNode("bolgeid").InnerText);



            return eczane;
        }
    }
}
