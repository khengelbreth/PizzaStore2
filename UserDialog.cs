using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2
{
    public class UserDialog
    {
        Menu _menu;
        public UserDialog(Menu menu)
        {
            _menu = menu;
        }

        public void SearchPizza()
        {
            Console.WriteLine("Would you like to Seach for a Pizza?");

            if (Console.ReadLine() == "Yes".ToLower())
            {
                Console.WriteLine("Write the name of a pizza:\n - remember, start with a capital letter ;-) -");

                string name = Console.ReadLine();

                foreach (var pizza in _menu.MenuList)
                {
                    if (name.Equals(pizza.Name) == true)
                    {
                        Console.WriteLine(pizza.ToString());
                        Console.WriteLine("Press any key to go back");
                        Console.ReadLine();
                        return;
                    }

                }             
                
                
                Console.WriteLine("Sorry couldn't find pizza.\nPlease try again: ");
                SearchPizza();
                


            }

        }

        Pizza GetNewPizza()
        {
            Pizza pizzaItem = new Pizza();
            Console.Clear();
            Console.WriteLine("|   CREATING PIZZA   |");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter Pizza name: ");
            pizzaItem.Name = Console.ReadLine();

            string input = "";
            Console.Write("Enter price: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Enter type bread (Hvidt?, Fuldkorn?, Glutenfrit?): ");
            try
            {
                //input = Console.ReadLine();
                //pizzaItem.Id = Int32.Parse(input);
                pizzaItem.Description = Console.ReadLine();
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }
            _menu.CreatePizza(pizzaItem.Price, pizzaItem.Name, pizzaItem.Description);
            return pizzaItem;
        }
        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("|     PIZZAMENU    |");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Options:");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.WriteLine();
            Console.Write("Enter option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            return -1;
        }
        
        bool proceed = true;
        public void Run()
        {
            proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Order",
                "1. Create new pizza",
                "2. Print menu",
                "3. Delete Pizza",
                "4. Search in Pizzas",
                "5. Quit"
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        Console.WriteLine("Ordering..:\n---- Enter PizzaID for ordering ----\n");
                        _menu.PrintMenu();
                        _menu.EnterOrder();
                        Console.WriteLine();
                        break;
                    case 1:
                        try
                        {
                            Pizza pizza = GetNewPizza();
                            _menu.CreatePizza(pizza);
                            Console.WriteLine($"You created: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza created");
                        }
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        _menu.PrintMenu();
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        _menu.PrintMenu();
                        Console.WriteLine("\nWhat Pizza would you like to delete? Insert ID: ");
                        string deleteP = Console.ReadLine();
                        _menu.DeletePizza(Convert.ToInt32(deleteP));
                        break;
                    case 4:
                        SearchPizza();
                        break;
                    case 5:
                        proceed = false;
                        Console.WriteLine($"Quitting...");
                        break;
                    default:
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}
