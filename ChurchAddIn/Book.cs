using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchAddIn
{
    public class Book
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
}
