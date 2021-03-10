namespace PizzaBox.Domain.Models
{

  public abstract class AComponent
  {
    public string Name { get; set; }
    public double Price { get; set; }
    public override string ToString()
    {
      return Name + " Cost: ";
    }
  }
}