

namespace BookStore.Products
{
    class PaperBook : IProduct
    {
        public string Name { get; }
        public string Author { get; }
        public decimal Price { get; }
        public ProductType Type = ProductType.PaperBook;
        public PaperBook(string name, string author, decimal price)
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

            if (!(obj is PaperBook))
                return false;

            var otherBook = (PaperBook)obj;

            return Author == otherBook.Author 
                && Name == otherBook.Name 
                && Type == otherBook.Type;
        }
    }
}
