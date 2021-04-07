using System;
using System.Collections.Generic;

#nullable disable

namespace APICoreSample.Models
{
    public partial class TblEmployee1
    {
        public int Empid { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime? JoiningDate { get; set; }
    }
}
