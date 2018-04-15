using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchAddIn2010
{
    public class Bible
    {
        public string Version { get; set; }
        public string Direction { get; set; }
        public List<Book> Books { get; set; }
    }
}
