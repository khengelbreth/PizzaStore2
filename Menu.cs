using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PizzaStore2
{
    public class Menu
    {

        private List<Pizza> _menu;
        private int nextId = 1;


        public Menu()
        {
            _menu = new List<Pizza>();
        }

        public List<Pizza> MenuList
        {
            get { return _menu; } 
        }

        #region Methods

        public void CreatePizza(double price, string name, string description)
        {
            Pizza pizza = new Pizza(price, name, description);
            {
                pizza.Id = nextId++;
            };


            _menu.Add(pizza);

        }

        public void CreatePizza(Pizza pizzas)
        {
            Pizza pizza = new Pizza();
            {
                pizza.Id = nextId++;
            };
        }

        public void DeletePizza(int id)
        {       
            Console.WriteLine("Are you sure you want to delete the Pizza? \nPress ID again to proceed.");

            if (Convert.ToString(id) == Console.ReadLine())
            {
                _menu.RemoveAll(p => p.Id == id);
                PrintMenu();

            }
        }

        public void PrintMenu()
        {
            foreach (Pizza pizza in _menu)
            {
                Console.WriteLine("|" + pizza.Id + ") " + pizza.Name + ", " + pizza.Price + " DKK. - " + pizza.Description + " brød.\n ------------------------------------------------------");               
            }
        }

        public Pizza GetPizzaById(int id)
        {
            return _menu[id]; 
        }


        double totalPrice = 0;
        string order;
        public void EnterOrder()
        {
            order = Console.ReadLine();
            if (order.Equals("Done".ToLower())) 
            {
                Console.WriteLine("\n--- You are now finished ordering. Thank you very much! ---\n");
                Console.WriteLine("Your total price will be: | " + totalPrice + " DKK |\n\n");
                
                Console.WriteLine();
                
                for (int i = 10; i > 0; i--)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine(GetPizzaById(Convert.ToInt32(order)-1));
                totalPrice += _menu[Convert.ToInt32(order) - 1].Price;                
                Console.WriteLine("     Type 'done' when finished ordering. :-)\n");                
                EnterOrder();
            }
        }


        #endregion
    }
}
