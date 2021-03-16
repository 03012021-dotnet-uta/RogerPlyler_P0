using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class Atopping
    {
        public Atopping()
        {
            AorderedPizzaTopping1Navigations = new HashSet<AorderedPizza>();
            AorderedPizzaTopping2Navigations = new HashSet<AorderedPizza>();
            AorderedPizzaTopping3Navigations = new HashSet<AorderedPizza>();
            AorderedPizzaTopping4Navigations = new HashSet<AorderedPizza>();
            AorderedPizzaTopping5Navigations = new HashSet<AorderedPizza>();
            ApizzaTopping1Navigations = new HashSet<Apizza>();
            ApizzaTopping2Navigations = new HashSet<Apizza>();
            ApizzaTopping3Navigations = new HashSet<Apizza>();
            ApizzaTopping4Navigations = new HashSet<Apizza>();
            ApizzaTopping5Navigations = new HashSet<Apizza>();
        }

        public int Id { get; set; }
        public string ToppingName { get; set; }
        public decimal? ToppingPrice { get; set; }

        public virtual ICollection<AorderedPizza> AorderedPizzaTopping1Navigations { get; set; }
        public virtual ICollection<AorderedPizza> AorderedPizzaTopping2Navigations { get; set; }
        public virtual ICollection<AorderedPizza> AorderedPizzaTopping3Navigations { get; set; }
        public virtual ICollection<AorderedPizza> AorderedPizzaTopping4Navigations { get; set; }
        public virtual ICollection<AorderedPizza> AorderedPizzaTopping5Navigations { get; set; }
        public virtual ICollection<Apizza> ApizzaTopping1Navigations { get; set; }
        public virtual ICollection<Apizza> ApizzaTopping2Navigations { get; set; }
        public virtual ICollection<Apizza> ApizzaTopping3Navigations { get; set; }
        public virtual ICollection<Apizza> ApizzaTopping4Navigations { get; set; }
        public virtual ICollection<Apizza> ApizzaTopping5Navigations { get; set; }
    }
}
