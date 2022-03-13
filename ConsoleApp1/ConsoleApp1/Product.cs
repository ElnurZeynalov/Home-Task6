using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Product
    {
        public Product(int no , string name ,double price)
            {
              No = no; 
              Name = name;
              Price = price;
            }
        public int No;
        public string Name;
        public double Price;
        public int Count;
    }
}
