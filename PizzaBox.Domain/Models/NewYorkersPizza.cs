using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class NewYorkersPizza : AStore
    {
        public override string ToString(){
            return Name;
        }
    }
}