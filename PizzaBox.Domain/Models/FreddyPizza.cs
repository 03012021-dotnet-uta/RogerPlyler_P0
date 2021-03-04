using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class FreddyPizza : AStore
    {
        public override string ToString(){
            return Name;
        }
    }
}