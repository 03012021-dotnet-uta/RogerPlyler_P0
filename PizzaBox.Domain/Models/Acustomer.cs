using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class Acustomer
    {
        public Acustomer()
        {
            Aorders = new HashSet<Aorder>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<Aorder> Aorders { get; set; }
    }
}
