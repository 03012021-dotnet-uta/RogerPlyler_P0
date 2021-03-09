using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models{
    public class Order{
        public List<APizza> Pizzas { get; set; }
        public Customer orderCustomer {get; set; }
        public double orderTotal{get; set;}
        public AStore orderStore { get; set; }


    }
}