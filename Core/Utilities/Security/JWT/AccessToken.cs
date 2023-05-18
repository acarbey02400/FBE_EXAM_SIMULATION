using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
