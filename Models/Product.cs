using System;
using System.Collections.Generic;

#nullable disable

namespace APICoreSample.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int? Price { get; set; }
    }
}
