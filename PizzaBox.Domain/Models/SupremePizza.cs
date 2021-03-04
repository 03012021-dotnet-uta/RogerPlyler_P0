using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models{
    public class SupremePizza : APizza{

        public SupremePizza(){
            Name = "Supreme Pizza";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}