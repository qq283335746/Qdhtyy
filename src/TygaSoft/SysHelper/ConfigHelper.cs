using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TygaSoft.SysHelper
{
    public class ConfigHelper
    {
        public static string[] GetKeyValue(string key)
        {
            return ConfigurationManager.AppSettings[key].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
