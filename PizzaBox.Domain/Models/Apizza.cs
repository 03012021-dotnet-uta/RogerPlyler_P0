using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class Apizza
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public int? Topping1 { get; set; }
        public int? Topping2 { get; set; }
        public int? Topping3 { get; set; }
        public int? Topping4 { get; set; }
        public int? Topping5 { get; set; }
        public int? Size { get; set; }
        public int? Crust { get; set; }
        public decimal? Price { get; set; }

        public virtual Asize CrustNavigation { get; set; }
        public virtual Asize SizeNavigation { get; set; }
        public virtual Atopping Topping1Navigation { get; set; }
        public virtual Atopping Topping2Navigation { get; set; }
        public virtual Atopping Topping3Navigation { get; set; }
        public virtual Atopping Topping4Navigation { get; set; }
        public virtual Atopping Topping5Navigation { get; set; }

        public override string ToString()
        {
            var context = new PizzaBoxContext();
            string toReturn = "";

            toReturn = Id + " " + PizzaName + " Toppings:";
            foreach(var t in Gettops())
            {
                toReturn +=" " + t.ToppingName;
            }
            toReturn += " Crust " + context.Acrusts.Where(c => c.Id == Crust).FirstOrDefault().CrustName;
            toReturn += " Size " + context.Asizes.Where(c => c.Id == Size).FirstOrDefault().SizeName;
            toReturn += " Price :" + GetPizzaPrice();
            return toReturn;
       }  

       public List<Atopping> Gettops()
       {
           List<int?> topsID = new List<int?>(){Topping1,Topping2,Topping3,Topping4,Topping5};
           List<Atopping> toppings = new List<Atopping>();
           var context = new PizzaBoxContext();
           foreach(var i in topsID){
               if(i != null)
               {
                   if(context.Atoppings.Any(t => t.Id == i)){
                    toppings.Add(context.Atoppings.Where(t => t.Id == i).First());
                   }else{
                       throw new Exception("Topping Id in a pizza isn't valid");
                   }
               }
           }
           return toppings;
       }

       public decimal GetPizzaPrice()
       {
           var context = new PizzaBoxContext();
           decimal returnPrice = Price.Value;
           foreach(var t in Gettops()){
               returnPrice += t.ToppingPrice.Value;
           }
           returnPrice += context.Acrusts.Where(c => c.Id == Crust).FirstOrDefault().CrustPrice.Value;
           returnPrice += context.Asizes.Where(c => c.Id == Size).FirstOrDefault().SizePrice.Value;
        return returnPrice;
       }
    }
}
