using PizzaBox.Domain.Abstracts;
//huh
namespace PizzaBox.Domain.Models{
    public class CheesePizza : APizza{
        public override string ToString()
        {
            return Name;
        }
    }
}