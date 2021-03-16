using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class Acrust
    {
        public int Id { get; set; }
        public string CrustName { get; set; }
        public decimal? CrustPrice { get; set; }
    }
}
