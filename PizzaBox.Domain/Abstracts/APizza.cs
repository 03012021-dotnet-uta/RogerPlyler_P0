using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizza{

        public string Name { get; set; } // A property

        public Crust Crust { get; set; }
        public Size Size { get; set; }
        public List<Topping> Toppings { get; set; }

        public APizza(){
            Factory();//FactoryConsturctor
        }

        protected virtual void Factory(){
            AddCrust();
            AddSize();
            AddToppings();
        }

        protected abstract void AddCrust();
        protected abstract void AddSize();
        protected abstract void AddToppings();
    }

    
}