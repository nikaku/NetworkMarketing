using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkMarketing.BL
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SqlServerHostName { get; set; }
        public string SqlServerPort { get; set; }
        public string SqlServerCatalog { get; set; }
        public string SqlServerUser { get; set; }
        public string SqlServerPassword { get; set; }
        public bool EnableSSL { get; set; } 
        public string PostgreConnectionString { get; set; }
    }
    
}
