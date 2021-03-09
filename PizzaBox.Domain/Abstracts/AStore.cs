using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{  
    [XmlInclude(typeof(ChicagoStore))]
    [XmlInclude(typeof(FreddyPizza))]
    public abstract class AStore
    {
        //Typing 'prop' then hitting tab will complete the line below us.
        public string Name { get; set; } // A property
        public override string ToString()
        {
             return Name;
        }
        // protected AStore()
        // {
        //     //Created as protected so that it won't be instanciated. 
        // }
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