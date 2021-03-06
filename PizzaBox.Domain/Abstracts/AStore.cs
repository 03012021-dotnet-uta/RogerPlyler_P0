using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AStore
    {
        //Typing 'prop' then hitting tab will complete the line below us.
        public string Name { get; set; } // A property
        public override string ToString()
        {
             return Name;
        }
       // public List<Order> Orders { get; set; }
       /* public string Name { 
            get{
                return name;
            }
            set{
                if(string.IsNullOrWhiteSpace(value)){
                    name = value;
                }
            } 
            }*/
    // same as the prop above
       /* private string name;
        public string GetName(){return name;}
        public void SetName(string n){
            
            if(string.IsNullOrWhiteSpace(n)){
                name = n;
            }
        }*/
        
    }
}