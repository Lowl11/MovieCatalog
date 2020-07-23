using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MovieCatalog.Models
{
    public class Viewer : DbModel
    {

        public string Username { get; set; }
        
        public string Password { get; set; }

    }
}
