﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Products
{
    class EBook : IProduct
    {
        public string Name { get; }
        public string Author { get; }
        public decimal Price { get; }
        public ProductType Type = ProductType.EBook;
        public EBook(string name, string author, decimal price)
        {
            Name = name;
            Author = author;
            Price = price;
        }

        public ProductType CheckType()
        {
            return Type;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is EBook))
                return false;

            var otherBook = (EBook)obj;

            return Author == otherBook.Author 
                && Name == otherBook.Name 
                && Type == otherBook.Type;
        }
    }
}
