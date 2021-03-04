using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models{
    public class CheesePizza : APizza{
        public override string ToString()
        {
            return Name;
        }
    }
}