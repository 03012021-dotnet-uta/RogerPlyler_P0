using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class Asize
    {
        public Asize()
        {
            AorderedPizzaCrustNavigations = new HashSet<AorderedPizza>();
            AorderedPizzaSizeNavigations = new HashSet<AorderedPizza>();
            ApizzaCrustNavigations = new HashSet<Apizza>();
            ApizzaSizeNavigations = new HashSet<Apizza>();
        }

        public int Id { get; set; }
        public string SizeName { get; set; }
        public decimal? SizePrice { get; set; }

        public virtual ICollection<AorderedPizza> AorderedPizzaCrustNavigations { get; set; }
        public virtual ICollection<AorderedPizza> AorderedPizzaSizeNavigations { get; set; }
        public virtual ICollection<Apizza> ApizzaCrustNavigations { get; set; }
        public virtual ICollection<Apizza> ApizzaSizeNavigations { get; set; }
    }
}
