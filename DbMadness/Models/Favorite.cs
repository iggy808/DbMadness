using System;
using System.Collections.Generic;

namespace DbMadness.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Animal { get; set; }
        public int? Color { get; set; }
        public int? Number { get; set; }

        public virtual FavoriteAnimal? AnimalNavigation { get; set; }
        public virtual FavoriteColor? ColorNavigation { get; set; }
        public virtual FavoriteNumber? NumberNavigation { get; set; }
    }
}
