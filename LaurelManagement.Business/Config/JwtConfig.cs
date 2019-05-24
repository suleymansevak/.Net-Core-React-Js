using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaurelManagement.Config
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int Expires { get; set; }

    }
}
