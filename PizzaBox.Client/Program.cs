using System;
using System.Collections.Generic;
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
    static int maxToppings = 3;
    static double maxCost = 250.0;

    static void Main(string[] args)
    {
      
      DisplayToppings();
      var input =  StartMenu();
      switch (input){
        case 1:
          //Select Store
          var selectedStore = SelectStoreMenu("What store's orders do you want to look at");
          //View Orders
          
          break;
        case 2:
          //Select Store
          selectedStore = SelectStoreMenu("What store do you wish to order from"); //WHYYYYYYYYYY
          //Select Pizzas
          var boughtPizzas = PizzaMenu();
          //View Order Total
          Console.WriteLine("You have selected " + selectedStore);
          break;
      }
      
    }

    public static int StartMenu()
    {
      string customerInput;
      int customerEntered;
      Console.WriteLine("Pizza Town is the best way to order Pizza");
      do{
      Console.WriteLine("1 Employee Login\n2 Customer Login");
        customerInput = Console.ReadLine();
      } while(!int.TryParse(customerInput,out customerEntered));
      return customerEntered;
      
    }
    public static AStore SelectStoreMenu(string message)
    {
        Console.WriteLine(message);
        DisplayStores();
        return new ChicagoStore();
    }
    
    public static List<APizza> PizzaMenu(){

      var pizzas = new List<APizza>();
      Console.WriteLine("What Pizza Do you want");
      return pizzas;
    }


    public static void DisplayStores()
    {
      foreach (var store in StoreSingleton.Instance.Stores)
      {
        Console.WriteLine(store);
      }
    }
    public static void DisplayToppings()
    {
      foreach (var topping in ToppingSingleton.Instance.Toppings)
      {
        Console.WriteLine(topping);
      }
    }

    public static List<Topping> SelectToppings(APizza selectedPizza)
    {
      int input = -1;
      while(selectedPizza.Toppings.Count < maxToppings || input != 0){
        Console.WriteLine("What Topping do you want");
        DisplayToppings();
      }
      return null;
    }
  }
}