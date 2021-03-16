using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class AorderedPizza
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PizzaName { get; set; }
        public int? Topping1 { get; set; }
        public int? Topping2 { get; set; }
        public int? Topping3 { get; set; }
        public int? Topping4 { get; set; }
        public int? Topping5 { get; set; }
        public int? Size { get; set; }
        public int? Crust { get; set; }
        public decimal? Price { get; set; }

        public virtual Asize CrustNavigation { get; set; }
        public virtual Aorder Order { get; set; }
        public virtual Asize SizeNavigation { get; set; }
        public virtual Atopping Topping1Navigation { get; set; }
        public virtual Atopping Topping2Navigation { get; set; }
        public virtual Atopping Topping3Navigation { get; set; }
        public virtual Atopping Topping4Navigation { get; set; }
        public virtual Atopping Topping5Navigation { get; set; }
    }
}
