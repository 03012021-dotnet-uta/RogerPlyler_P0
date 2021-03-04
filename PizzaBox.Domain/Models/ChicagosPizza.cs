using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class ChicagosPizza : AStore
    {
        public override string ToString(){
            return Name;
        }
    }
}