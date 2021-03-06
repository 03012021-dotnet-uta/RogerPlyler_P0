using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Client
{
  /// <summary>
  /// 
  /// </summary>
  class Program
  {

    static void Main(string[] args)
    {
      PlayWithStore();
    }

    public static void PlayWithStore()
    {
      foreach (var store in StoreSingleton.Instance.Stores)
      {
        Console.WriteLine(store);
      }
    }
  }
}