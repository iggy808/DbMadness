using System;
using System.Collections.Generic;

namespace DbMadness.Models
{
    public partial class FavoriteAnimal
    {
        public FavoriteAnimal()
        {
            Favorites = new HashSet<Favorite>();
        }

        public int Id { get; set; }
        public string Value { get; set; } = null!;

        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
