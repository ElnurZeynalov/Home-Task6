using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Book:Product
    {
        public Book(int no, string name, double price , string genre):base(no,name,price)
        {
            Genre = genre;
        }
        public string Genre;
        public string GetInfo()
        {
            return $"===============================\nNo: {this.No} -- Kitabin Janiri: {this.Genre} -- Adi: {this.Name}\nQiymeti: {this.Price} Azn -- Sayi: {this.Count}\n===============================\n";
        }
    }
}
