using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobetciEczane_IEO
{
    public class NCZConfigParameters
    {
        private Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public string this[string key]
        {
            get
            {
                if (string.IsNullOrEmpty(key)) return "";

                if (_parameters.ContainsKey(key))
                    return _parameters[key];
                else
                {
                    var _val = ConfigurationManager.AppSettings[key]?.ToString();
                    if (!string.IsNullOrEmpty(_val))
                    {
                        _parameters.Add(key, _val);
                        return _val;
                    }
                }

                return "";
            }
        }

    }
}
