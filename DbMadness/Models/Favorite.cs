using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DbMadness.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Animal { get; set; }
        public int? Color { get; set; }
        public int? Number { get; set; }

        [DisplayName("Favorite Animal")]
        public virtual FavoriteAnimal? AnimalNavigation { get; set; }
        [DisplayName("Favorite Color")]
        public virtual FavoriteColor? ColorNavigation { get; set; }
        [DisplayName("Favorite Number")]
        public virtual FavoriteNumber? NumberNavigation { get; set; }
    }
}
