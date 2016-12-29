using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobetciEczane_IEO
{
    public class NCZNobetciEczane
    {
        public int ilce { get; set; }
        public DateTime tarih { get; set; }
        public string eczane { get; set; }
        public string eczaci { get; set; }
        public string adres { get; set; }
        public string tel { get; set; }
        public string fax { get; set; }
        public int eczid { get; set; }
        public int bolgeid { get; set; }
        public bool isFind { get; set; } = true;

        internal string ToHTML()
        {
            var result = new StringBuilder();
            result.Append("<tr>");
            result.Append($"<td>{this.eczid}</td>");
            result.Append($"<td>{this.eczane}</td>");
            result.Append($"<td>{this.eczaci}</td>");
            result.Append($"<td>{this.tel}</td>");
            result.Append($"<td>{this.tarih.ToShortDateString()}</td>");
            result.Append($"<td>{this.adres}</td>");
            result.Append("</tr>");


            return result.ToString();
        }
    }
}
