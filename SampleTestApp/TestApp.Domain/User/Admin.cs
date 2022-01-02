using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.User
{
    public class Admin:Person
    {
        public string Privilege { get; set; }
    }
}
