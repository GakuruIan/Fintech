using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Fintech
{
    public static class Helper
    {
        public static string ConnectionVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
            
    }
}
