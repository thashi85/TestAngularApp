using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain
{
    public class Paging
    {
        public int number { get; set; }

        public int size { get; set; }
        public Paging()
        {
            number = 1;
            size = 10;
        }
    }
}
