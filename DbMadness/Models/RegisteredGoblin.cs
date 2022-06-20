using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DbMadness.Models
{
    public partial class RegisteredGoblin
    {
        public int GoblinId { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [DisplayName("Favorite Ice Cream")]
        public string? FavIcecreamFlavor { get; set; }
        [DisplayName("Do They Lie?")]
        public bool? Liar { get; set; }

        public virtual Favorite? Favorite { get; set; }
    }
}
