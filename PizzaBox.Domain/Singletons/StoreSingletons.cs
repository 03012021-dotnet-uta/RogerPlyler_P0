using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Domain.Singletons
{
  public class StoreSingleton
  {
    //backing feild - A variable in the class context
   private static StoreSingleton _storeSingleton;
    public List<AStore> Stores { get; set; } // print job
    
    public static StoreSingleton Instance
    {
      get
      {
        if (_storeSingleton == null)
        {
          _storeSingleton = new StoreSingleton(); // printer
        }
        return _storeSingleton;
      }
    }

    private void addStore(AStore newstore){
      if (Stores == null)
      {
        Stores = new List<AStore>();
        Console.WriteLine("In Stores");
      }
      Stores.Add(newstore);
    }

    /// <summary>
    /// 
    /// </summary>
    private StoreSingleton()
    {
      var fs = new FileStorage();
      
      if (Stores == null)
      {
        Stores = new List<AStore>();
        Stores.Add(new ChicagoStore());
        fs.WriteToXml<AStore>(Stores);
        Stores = fs.ReadFromXml<AStore>().ToList();
      }
    }


    /*public static StoreSingleton GetInstance()
    {
      if(storeSingleton == null)
      {
        storeSingleton = new StoreSingleton(); //Printer
      }
      return storeSingleton;
    }
    */

  }
}