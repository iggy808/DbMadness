using System;
using System.Collections.Generic;

namespace DbMadness.Models
{
    public partial class RegisteredGoblin
    {
        public int GoblinId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FavIcecreamFlavor { get; set; }
        public bool? Liar { get; set; }
    }
}
