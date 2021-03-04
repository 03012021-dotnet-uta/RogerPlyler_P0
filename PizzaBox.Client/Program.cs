using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      PlayWithStore();
    }

    public static void PlayWithStore()
    {
      var storeSingleton = new StoreSingleton();
      var pizzaSingleton = new PizzaSingletons();

      foreach (var store in storeSingleton.Stores)
      {
        Console.WriteLine(store);
      }
      foreach (var pizza in pizzaSingleton.Pizzas)
      {
          Console.WriteLine(pizza);
      }
    }
  }
}