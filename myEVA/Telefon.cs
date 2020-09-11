using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEVA
{
    struct Telefon
    {
        public string vorwahl;
        public int nummer;

        public Telefon(string v, int n)
        {
            vorwahl = v;
            nummer = n;
        }

        public override string ToString()
        {
            return vorwahl + nummer;
        }
    }
}
