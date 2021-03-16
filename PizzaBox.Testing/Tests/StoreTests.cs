using PizzaBox.Domain.Models;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    [Fact]
    public void CheeseToppingTest()
    {
      var context = new PizzaBoxContext();
      // arrange
      Atopping sut = context.Atoppings.Where(t =>t.Id == 1).FirstOrDefault();
      var expected = "Cheese";

      // act
      var actual = sut.ToppingName;

      // assert
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Cheese",1)]
    [InlineData("Pepperoni",2)]
    public void ToppingName(string expected,int testID)
    {
      var context = new PizzaBoxContext();
      // arrange
      Atopping sut = context.Atoppings.Where(t =>t.Id == testID).FirstOrDefault();

      // act
      var actual = sut.ToppingName;

      // assert
      Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(0.0,1)]
    [InlineData(0.5,2)]
    public void Test_Topping_Price(decimal expected,int testID)
    {
      var context = new PizzaBoxContext();
      // arrange
      Atopping sut = context.Atoppings.Where(t =>t.Id == testID).FirstOrDefault();

      // act
      var actual = sut.ToppingPrice;

      // assert
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0.0,1)]
    [InlineData(0.0,2)]
    public void Test_Crust_Price(decimal expected,int testID)
    {
      var context = new PizzaBoxContext();
      // arrange
      var sut = context.Acrusts.Where(t =>t.Id == testID).FirstOrDefault();

      // act
      var actual = sut.CrustPrice;

      // assert
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Thin",1)]
    [InlineData("Regular",2)]
    [InlineData("Deep Dish",3)]
    public void Test_Crust_Name(string expected,int testID)
    {
      var context = new PizzaBoxContext();
      // arrange
      var sut = context.Acrusts.Where(t =>t.Id == testID).FirstOrDefault();

      // act
      var actual = sut.CrustName;

      // assert
      Assert.Equal(expected, actual);
    }
  }
}