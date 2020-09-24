using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticatedMongoDb.ViewModels
{
    public class LoginResponseViewModel
    {
        public string Token { get; set; }
        public string ExpiresIn { get; set; }
    }
}
