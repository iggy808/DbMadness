using System;
using System.Collections.Generic;

namespace DbMadness.Models
{
    public partial class Creature
    {
        public int CreatureId { get; set; }
        public int? NumberOfLegs { get; set; }
        public int? NumberOfEyeballs { get; set; }
        public int? NumberOfArms { get; set; }
        public string? Size { get; set; }
        public string? TypeName { get; set; }
    }
}
