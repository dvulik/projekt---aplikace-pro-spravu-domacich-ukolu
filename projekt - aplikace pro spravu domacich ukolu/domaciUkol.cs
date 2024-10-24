using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt___aplikace_pro_spravu_domacich_ukolu
{
    public class domaciUkol
    {
        public string Nazev { get; set; }
        public string Popis { get; set; }
        public DateTime Termin { get; set; }

        public override string ToString()
        {
            return $"název: {Nazev}, popis: {Popis}, termín: {Termin.ToShortDateString()} ";
        }
    }

}
