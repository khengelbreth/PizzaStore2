using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2
{
    public class Pizza
    {
        private int _id;
        private double _price;
        private string _name;
        private string _description;
        public int nextId = 1;
        public Pizza(double price, string name, string description)
        {
            _price = price;
            _name = name;
            _description = description;
        }

        public Pizza() { }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description 
        { 
            get { return _description; }
            set { _description = value; }
        }

        public override string ToString()
        {
            return $"{Id}) {Name}, {Price}, {Description}";
        }

    }












    
}
