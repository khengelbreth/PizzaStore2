using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2
{
    public class Store
    {
        public void Start()
        {
            Menu _menu = new Menu();

            //Pizza pizza1 = new Pizza(80, "Diavola", "Fuldkorn");
            //Pizza pizza2 = new Pizza(80, "Tom Fury", "Hvid");
            //Pizza pizza3 = new Pizza(99, "Quattro", "Hvid");
            //Pizza pizza4 = new Pizza(10000, "Juleaften", "Fuldkorn");

            _menu.CreatePizza(79, "Margeritta", "Fuldkorns");
            _menu.CreatePizza(100, "Torino", "Hvidt"); 
            _menu.CreatePizza(100, "Diavola", "Hvidt");
            _menu.CreatePizza(100, "Quattro Staggioni", "Hvidt");
            _menu.CreatePizza(95, "Pepperoni", "Hvidt");
            _menu.CreatePizza(110, "Meat Feast", "Hvidt");
            _menu.CreatePizza(89, "Veggi", "Glutenfri");

            Run();
            
            
            Console.WriteLine();


            

            #region helper method


            void Run()
            {
                new UserDialog(_menu).Run();
            }

            #endregion

        }
    }
}
