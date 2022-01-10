using System.Collections.Generic;

namespace ChurchAddIn
{
    public class Book
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
}
