using System;
using System.Collections.Generic;

#nullable disable

namespace APICoreSample.Models
{
    public partial class Tblemp
    {
        public int Eid { get; set; }
        public string Ename { get; set; }
        public double? Sal { get; set; }
        public DateTime? Doj { get; set; }
        public int? Deptid { get; set; }
    }
}
