using System;
using System.Collections.Generic;

namespace DbMadness.Models
{
    public partial class FavoriteNumber
    {
        public FavoriteNumber()
        {
            Favorites = new HashSet<Favorite>();
        }

        public int Id { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
