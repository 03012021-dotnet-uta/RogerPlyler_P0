using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
//huh
namespace PizzaBox.Domain.Models{
    public class CheesePizza : APizza{
        

        protected override void AddCrust()
        {
            Crust = new Crust();
        }

        protected override void AddSize()
        {
            Size = new Size();
        }

        protected override void AddToppings()
        {
            Toppings = new List<Topping>()
            {
                new Topping(),
                new Topping()
            };
        }
    }
}