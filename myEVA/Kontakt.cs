using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEVA
{
    struct Kontakt
    {
        public int plz;
        public string ort;
        public string strasse;
        public string hausnummer;
        public Telefon tel;
        public string mail;

        
        public Kontakt(int _plz, string _ort, string _strasse, string _hausnummer, Telefon _t, string _mail)
        {
            plz = _plz;
            ort = _ort;
            strasse = _strasse;
            hausnummer = _hausnummer;
            tel = _t;
            mail = _mail;
        }
    }
}
