using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    class Program
    {
        static int hourLimit = 2;
        static int hourStoreLimit = 24;
        static int maxPizzaCount = 50;
        static decimal maxPizzaOrder = 250m;
        
        static void Main(string[] args)
        {
            
            checkDatabase();
            
            Console.WriteLine("Press 1 for Customer\nPress 2 for Store Menu\nPress 0 to exit");
            int.TryParse(Console.ReadLine(),out var option);
            switch(option){
                case 1:
                    var selectedCust = SelectCustomer();
                    
                    Console.WriteLine($"What do you want to do {selectedCust.CustomerName}\n1Place A New Order\n2View Past Orders");
                    int.TryParse(Console.ReadLine(),out var custoption);
                    switch(custoption){
                        case 1:
                            if(checkCustomerTime(selectedCust,hourLimit))
                            {
                                break;
                            }
                            var orderStore = SelectStores();
                            if(checkCustomerStore(selectedCust,orderStore,hourStoreLimit)){
                                break;
                            }
                            CreateOrder(orderStore,selectedCust);                            break;
                        case 2:
                            ViewOrders(selectedCust);
                            break;
                        default :
                            Console.WriteLine("Pick valid option");
                            break;
                    }
                break;

                case 2:
                    var selectedStore = SelectStores();
                    ViewOrders(selectedStore);
                break;
                
                default:
                    Console.WriteLine("Please pic a valid option");
                break;
            }
            



        }

        static bool checkCustomerTime(Acustomer checkCust,int customerHourLimit)
        {
            var context = new PizzaBoxContext();
            var query = context.Aorders.Where(c => c.CustomerId == checkCust.Id);
            if(query.Any(t => t.TimeOrdered >= DateTime.Now.AddHours(-customerHourLimit)))
            {
                Console.WriteLine("You have ordered in the last " + customerHourLimit+ " hours");
                return true;
            }else{
                 Console.WriteLine("Welcome " + checkCust.CustomerName);
                 return false;
            }
        }

        //Checks to see if the customer has used this store within a time frame
        static bool checkCustomerStore(Acustomer checkCust,Astore checkStore,int storeLimit)
        {
            var context = new PizzaBoxContext();
            var query = context.Aorders.Where(c => c.CustomerId == checkCust.Id);
            var queriable = query.Where(d => d.StoreId == checkStore.Id);
            if(queriable.Any(t => t.TimeOrdered >= DateTime.Now.AddHours(-storeLimit)))
            {
                Console.WriteLine("You have ordered in the last "+storeLimit + " hours");
                return true;
            }else{
                 
                 return false;
            }
        }

        //Displays stores and allows you to pick one
        static Astore SelectStores(){
            var context = new PizzaBoxContext();
            List<Astore> stores = context.Astores.ToList();
            foreach (var s in stores){
                Console.WriteLine(s);
            }
            int input = -1;
            
            do{ 
                int.TryParse(Console.ReadLine(),out input);
                
            }while(!context.Astores.Any(p => p.Id == input));
            Astore store = context.Astores.Where(p => p.Id == input).First();
            Console.WriteLine(store.StoreName + " Selected");
            return store;
        }
        //Allows you to select a pizza
        static Apizza SelectPizza(){
            DisplayPizzas();
            var context = new PizzaBoxContext();
            int input = -1;
            do{ 
                int.TryParse(Console.ReadLine(),out input);
            }while(!context.Apizzas.Any(p => p.Id == input));
            Apizza pizza = context.Apizzas.Where(p => p.Id == input).First();
            Console.Write(pizza.PizzaName + " Selected");
            pizza.Gettops();
            return pizza;
        }

        static void DisplayPizzas(){
            var context = new PizzaBoxContext();

            List<Apizza> pizzas = context.Apizzas.ToList();
            foreach (var p in pizzas){
                Console.WriteLine(p.ToString());
            }
        }

        static Acustomer SelectCustomer(){
            var context = new PizzaBoxContext();
            Console.WriteLine("What is your name");
            var name = Console.ReadLine();
            if(context.Acustomers.Any(c => c.CustomerName == name)){
               return context.Acustomers.Where(c => c.CustomerName == name).First();
            }else{
                var cust = new Acustomer(){
                    Id = context.Acustomers.Max(c => c.Id) + 1,
                    CustomerName = name
                };
                context.Acustomers.Add(cust);
                context.SaveChanges();
                return cust;
            }
        }

        static void CreateOrder(Astore orderingStore, Acustomer orderingCustomer){
            var context = new PizzaBoxContext();
            int input = -1; 
            List<Apizza> pizzas = new List<Apizza>();
            var newOrder = new Aorder(){
                OrderId= (context.Aorders.Any(o => o.OrderId == 1))?context.Aorders.Max(o => o.OrderId) +1: 1,
                CustomerId = orderingCustomer.Id,
                StoreId = orderingStore.Id,
                TimeOrdered = DateTime.Now
            };
            Console.WriteLine("What Pizza Do you want in your order");
            do{
                if(input != 2 ){
                pizzas.Add(SelectPizza());
                ModifyPizza(pizzas[pizzas.Count - 1 ]);
                }else{
                    RemovePizza(pizzas);
                }
                Console.WriteLine("Order Total $: " + newOrder.TotalPrice(pizzas).Value);

                if(pizzas.Count >= maxPizzaCount || newOrder.TotalPrice(pizzas) >  maxPizzaOrder)
                {
                    input = 0;
                    Console.WriteLine("You have reached the limit of your order");
                }else{
                    Console.WriteLine("Do you want another pizza. 0 for no 1 for yes 2 to remove pizza");
                    int.TryParse(Console.ReadLine(),out input);
                }
            }while(!(input == 0));

            foreach(var p in pizzas){
                Console.WriteLine(p.ToString());
            }
            var totalPrice = 0m;
            foreach(var p in pizzas){
                totalPrice += p.GetPizzaPrice();
            }


            SubmitOrder(newOrder,pizzas);
        }

        static void ModifyPizza(Apizza PizzaToModify){
            PizzaToModify.Size = SelectSize().Id;
            PizzaToModify.Crust = SelectCrust().Id;
            SelectToppings(PizzaToModify);
            Console.WriteLine(PizzaToModify.ToString());
        }

        //Allows the user to have a new crust
        static Acrust SelectCrust(){
            var context = new PizzaBoxContext();
            Console.WriteLine("What Crust would you like");
            List<Acrust> crust = context.Acrusts.ToList();
            foreach (var c in crust){
                Console.WriteLine($"{c.Id} {c.CrustName}  $ {c.CrustPrice}");
            }
            int input = -1;
            do{ 
                int.TryParse(Console.ReadLine(),out input);
            }while(!context.Acrusts.Any(p => p.Id == input));
            Acrust crus = context.Acrusts.Where(p => p.Id == input).First();
            return crus;
        }

        //Takes in an object and allows you to modityf a pizza
        static void SelectToppings(Apizza PizzaToModify)
        {
            var context = new PizzaBoxContext();
            Console.WriteLine("What Toppings would you like to add");
            List<Atopping> top = context.Atoppings.ToList();
            foreach (var t in top){
                Console.WriteLine($"{t.Id} {t.ToppingName} ${t.ToppingPrice}");
            }
            var input = 0;
            do{
                //Takes in user input
                Console.WriteLine("Which Topping would you like to add\n enter 0 to leave");
                int.TryParse(Console.ReadLine(),out input);
                int newTop = 0;
                //Checks to see if topping exists
                if(context.Atoppings.Any(p => p.Id == input))
                {
                    newTop = context.Atoppings.Where(p => p.Id == input).First().Id;
                }
                
                if(input !=0){
                Console.WriteLine("Which Topping do you wanna change");
                int.TryParse(Console.ReadLine(),out int changeTop);
                switch(changeTop){
                    case 1:
                        PizzaToModify.Topping1 = newTop;
                    break;
                    case 2:
                        PizzaToModify.Topping2 = newTop;
                    break;
                    case 3:
                        PizzaToModify.Topping3 = newTop;
                    break;
                    case 4:
                        PizzaToModify.Topping4 = newTop;
                    break;
                    case 5:
                        PizzaToModify.Topping5 = newTop;
                    break;
                    default:
                        Console.WriteLine("Pick a valid option next time!");
                    break;

                }
                }
            }while(input != 0);
            
        }
            //Allows you to select a new size for the pizza
            static Asize SelectSize(){
            var context = new PizzaBoxContext();
            Console.WriteLine("What Size would you like");
            List<Asize> sizes = context.Asizes.ToList();
            foreach (var s in sizes){
                Console.WriteLine($"{s.Id} {s.SizeName} ${s.SizePrice}");
            }
            int input = -1;
            do{ 
                int.TryParse(Console.ReadLine(),out input);
            }while(!context.Asizes.Any(p => p.Id == input));
            Asize siz = context.Asizes.Where(p => p.Id == input).First();
            return siz;
        }

        //Creates info on the submitted order table
        static void SubmitOrder(Aorder submittedOrder,List<Apizza> submittedPizzas){
            var context = new PizzaBoxContext();
            Console.WriteLine("Order #" + submittedOrder.OrderId + " $" + submittedOrder.Total);
            context.Aorders.Add(submittedOrder);
            context.SaveChanges();
            //Takes each of the orders for the pizza and displays them and the price and moves them to the submitted order pizza
            foreach(var p in submittedPizzas){
                var orderedPizzas = new AorderedPizza(){
                    Id = (context.AorderedPizzas.Any(o => o.Id == 1))?context.AorderedPizzas.Max(o => o.Id) +1: 1,
                    OrderId = submittedOrder.OrderId,
                    PizzaName = p.PizzaName,
                    Topping1 = p.Topping1,
                    Topping2 = p.Topping2,
                    Topping3 = p.Topping3,
                    Topping4 = p.Topping4,
                    Topping5 = p.Topping5,
                    Size = p.Size,
                    Crust = p.Crust,
                    Price = p.GetPizzaPrice()
                };
                Console.WriteLine("    " + p.ToString());
                context.AorderedPizzas.Add(orderedPizzas);
                context.SaveChanges();
            }
        }

        //This will view orders for a customer
        static void ViewOrders(Acustomer cust){
            var context = new PizzaBoxContext();
            List<Aorder> ord = context.Aorders.Where(o => o.CustomerId == cust.Id).ToList();
            foreach(var o in ord){
               Console.WriteLine("Order # " +o.OrderId + " " + o.TimeOrdered + " $" + o.Total);
               List<AorderedPizza> piz = context.AorderedPizzas.Where(pi => pi.OrderId == o.OrderId).ToList();
               foreach(var p in piz)
               {
                   Console.WriteLine("    " + p.ToString());
               }
            }
        }

        //Overloaded function
        //This will view the orders of a store based on the input from the user
        static void ViewOrders(Astore stor)
        {
            Console.WriteLine("How many days back do you want to veiw orders :");
            int.TryParse(Console.ReadLine(),out int input);
            var context = new PizzaBoxContext();
            var queriable = context.Aorders.Where(o => o.StoreId == stor.Id).ToList();
            var ord = queriable.Where(o=> o.TimeOrdered >= DateTime.Now.AddDays(-input));
            foreach(var o in ord){
               Console.WriteLine("Order # " +o.OrderId + " " + o.TimeOrdered + " $" + o.Total);
               List<AorderedPizza> piz = context.AorderedPizzas.Where(pi => pi.OrderId == o.OrderId).ToList();
               foreach(var p in piz)
               {
                    Console.WriteLine("    " + p.ToString());
               }
            }
           
        }
        
        //Removes Pizza From a list
        static void RemovePizza(List<Apizza> pizzas){
            Console.WriteLine("Which pizza do you wish to remove\nEnter 0 if you don't wish to remove any");
            for (int i = 0; i < pizzas.Count; i++){
                Console.WriteLine(i + 1 +" " + pizzas[i]);
            }
            //This will parse the input of the person and make it so that it will not cause an out of bounds error
            int.TryParse(Console.ReadLine(),out var input);
            if(input >0 && input <= pizzas.Count){
            pizzas.Remove(pizzas[input-1]);
            }else{
                Console.WriteLine("No pizzas were removed");
            }
        }

        /*
            This will check the database for any item that isn't part of anything that generates
            and will give it default values
        */
        static void checkDatabase(){
            var context = new PizzaBoxContext();
            if(!context.Astores.Any())
            {
                var top = new Astore(){
                    Id = 1,
                    StoreName = "Freddys Pizza"
                };
                context.Astores.Add(top);
                context.SaveChanges();
                 top = new Astore(){
                    Id = 1,
                    StoreName = "Chicago Pizza"
                };
                context.Astores.Add(top);
                context.SaveChanges();
            }
            if(!context.Atoppings.Any())
            {
                var top = new Atopping(){
                    ToppingName = "Cheese",
                    ToppingPrice = 0m,
                    Id = 1
                };
                context.Atoppings.Add(top);
                context.SaveChanges();
                top = new Atopping(){
                    ToppingName = "Peporoni",
                    ToppingPrice = 0.5m,
                    Id = 2
                };
                context.Atoppings.Add(top);
                context.SaveChanges();
            }
            if(!context.Acrusts.Any())
            {
                var top = new Acrust(){
                    CrustName = "Thin",
                    CrustPrice = 0m,
                    Id = 1
                };
                context.Acrusts.Add(top);
                context.SaveChanges();
                top = new Acrust(){
                    CrustName = "Regular",
                    CrustPrice = 0m,
                    Id = 2
                };
                context.Acrusts.Add(top);
                context.SaveChanges();
                top = new Acrust(){
                    CrustName = "Deep Dish",
                    CrustPrice = 1m,
                    Id = 3
                };
                context.Acrusts.Add(top);
                context.SaveChanges();
                top = new Acrust(){
                    CrustName = "Stuff Crust",
                    CrustPrice = 2m,
                    Id = 4
                };
                context.Acrusts.Add(top);
                context.SaveChanges();
                
            }
            if(!context.Asizes.Any())
            {
                var top = new Asize(){
                    SizeName = "Small",
                    SizePrice = 0m,
                    Id = 1
                };
                context.Asizes.Add(top);
                context.SaveChanges();
                top = new Asize(){
                    SizeName = "Medium",
                    SizePrice = 1m,
                    Id = 2
                };
                context.Asizes.Add(top);
                context.SaveChanges();
                top = new Asize(){
                    SizeName = "Large",
                    SizePrice = 2m,
                    Id = 3
                };
                context.Asizes.Add(top);
                context.SaveChanges();
            }
            if(!context.Apizzas.Any())
            {
                var top = new Apizza(){
                    Id = 1,
                    PizzaName = "Cheese Pizza",
                    Topping1 = 1,
                    Topping2 = 1,
                    Size = 1,
                    Crust = 1,
                    Price = 10.0m
                };
                context.Apizzas.Add(top);
                context.SaveChanges();
                top = new Apizza(){
                    Id = 2,
                    PizzaName = "Peporoni",
                    Topping1 = 1,
                    Topping2 = 2,
                    Size = 1,
                    Crust = 1,
                    Price = 12.0m
                };
                context.Apizzas.Add(top);
                context.SaveChanges();

            }
            
        }

    }
}
/*
TO DO
    *Make it so every topping can be edited *done*
    *Remove Pizza From Order *done*
    *Select Times For Viewing Orders *Done*
    *Fix 24 Hour and 2 Hour Restriction *Done*
*/
