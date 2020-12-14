using System;
using System.Collections.Generic;
using System.Text;

namespace FileScannerApp
{
    
    public class QRAPIResponse
    {
        public string type;
        public List<Symbol> symbol;
       
    }
    public class Symbol
    {
        public int seq;
        public string data;
        public string error;
    }
}
