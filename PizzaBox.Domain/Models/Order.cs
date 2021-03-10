using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models{
    public class Order{
        public List<APizza> Pizzas { get; set; }//comment
        double price = 0.00;

    }
}