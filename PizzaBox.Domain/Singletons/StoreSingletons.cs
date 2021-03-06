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
    public List<ChicagoStore> Stores { get; set; } // print job
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

    /// <summary>
    /// 
    /// </summary>
    private StoreSingleton()
    {
      var fs = new FileStorage();

      if (Stores == null)
      {
        Stores = fs.ReadFromXml<ChicagoStore>().ToList();
      }
    }


/*    public static StoreSingleton GetInstance()
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