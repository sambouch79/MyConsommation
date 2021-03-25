using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myconsom.Models
{
 
    public class Reference
    { 
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
 
        public DateTime Date { get; set; }
        public int Elect_Hp { get; set; }
        public int Elect_Hc { get; set; }
        public int Gaz { get; set; }
        public double Eau { get; set; }


    }
}
