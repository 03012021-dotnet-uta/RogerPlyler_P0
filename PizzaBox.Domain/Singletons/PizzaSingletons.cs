using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
  public class PizzaSingletons
  {
    public List<APizza> Pizzas { get; set; }
    
    public PizzaSingletons()
    {
      Pizzas = new List<APizza>
      {
        new CheesePizza(){Name = "Cheese Pizza"},
        new SupremePizza(){Name = "Supreme Pizza"},
        new PeperoniPizza(){Name = "Peperoni Pizza"}        
      };
    }
  }
}