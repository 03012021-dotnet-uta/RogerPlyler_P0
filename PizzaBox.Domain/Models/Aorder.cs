using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class Aorder
    {

        public Aorder()
        {
            AorderedPizzas = new HashSet<AorderedPizza>();
        }
        public decimal? TotalPrice(List<Apizza> pizzas)
        {
            Total = 0;
            foreach(var p in pizzas){
                Total += p.GetPizzaPrice();
            }
            return Total;
            
        }

        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime TimeOrdered { get; set; }
        public decimal? Total { get; set; }

        public virtual Acustomer Customer { get; set; }
        public virtual Astore Store { get; set; }
        public virtual ICollection<AorderedPizza> AorderedPizzas { get; set; }
    }
}
