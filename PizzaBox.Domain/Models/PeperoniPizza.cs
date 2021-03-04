using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models{
    public class PeperoniPizza : APizza{
        public override string ToString()
        {
            return Name;
        }
    }
}