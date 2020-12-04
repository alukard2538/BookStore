using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Products
{
    class PaperJournal : IProduct
    {
        public string Name { get; }
        public string Author { get; }
        public decimal Price { get; }
        public int Year { get; }
        public int Month { get; }
        public bool IsDelivery { get; }
        public int DateInMonths { get; }
        public ProductType Type = ProductType.PaperJournal;
        public PaperJournal(string name, string author, decimal price, int year, int month)
        {
            Name = name;
            Author = author;
            Price = price;
            Year = year;
            Month = month;
            DateInMonths = year * 12 + month;
            IsDelivery = true;
    }
        public ProductType CheckType()
        {
            return Type;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is PaperJournal))
                return false;

            var otherProduct = (PaperJournal)obj;

            return Author == otherProduct.Author 
                && Name == otherProduct.Name 
                && Type == otherProduct.Type
                && Year == otherProduct.Year
                && Month == otherProduct.Month;
        }

    }
}
