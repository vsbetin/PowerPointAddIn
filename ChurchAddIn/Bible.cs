using System.Collections.Generic;

namespace ChurchAddIn
{
    public class Bible
    {
        public string Version { get; set; }
        public string Direction { get; set; }
        public List<Book> Books { get; set; }
    }
}
