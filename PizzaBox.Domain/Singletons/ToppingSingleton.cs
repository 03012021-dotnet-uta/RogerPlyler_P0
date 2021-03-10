using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
  public class ToppingSingleton
  {
    public List<Topping> Toppings { get; set; }

    private static ToppingSingleton _toppingSingleton;
    
    public static ToppingSingleton Instance
    {
      get
      {
        if (_toppingSingleton == null)
        {
          _toppingSingleton = new ToppingSingleton(); // printer
        }
        return _toppingSingleton;
      }
    }
    public ToppingSingleton()
    {
      Toppings = new List<Topping>
      {
        new Topping(){Name = "Extra Cheese", Price = 0.50}
      };
    }
  }
}