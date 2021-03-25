using System;
using System.Collections.Generic;
using System.Text;

namespace Myconsom.Models
{
    class DonnesComparaison
    {
        public int IdComp { get; set; }
        public DateTime Date { get; set; }
        public int Elect_Hp { get; set; }
        public int Elect_Hc { get; set; }
        public int Gaz { get; set; }
        public double Eau { get; set; }
        public double HpJour { get; set; }
        public double HcJour { get; set; }
        public double gazJour { get; set; }
        public double EauJour { get; set; }
    }
}
