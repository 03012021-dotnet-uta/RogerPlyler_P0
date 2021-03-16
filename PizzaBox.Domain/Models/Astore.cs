using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class Astore
    {
        public Astore()
        {
            Aorders = new HashSet<Aorder>();
        }

        public int Id { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<Aorder> Aorders { get; set; }
        
        public override string ToString()
        {
            return Id + " " + StoreName;
        }  
    }
}
