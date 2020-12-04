using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BookStore.Actions;
using BookStore.Cart;
using BookStore.Delivery;
using BookStore.Promos;
using BookStore.Products;

namespace BookStore
{

    class Program
    {
        static List<IProduct> Library()
        {
            //-------------------------------------------------------------------------------------------
            //Создаем набор книг
            List<IProduct> books = new List<IProduct> ();
            //-------------------------------------------------------------------------------------------
            //Автор - Tolkien
            //Бумажные
            PaperBook TolkienPaperBook1 = new PaperBook("Silmarillion", "Tolkien", 500);
            books.Add(TolkienPaperBook1);
            PaperBook TolkienPaperBook2 = new PaperBook("Hobbit", "Tolkien", 300);
            books.Add(TolkienPaperBook2);
            //Электронные
            EBook TolkienEBook1 = new EBook("Fellowship of the ring", "Tolkien", 300);
            books.Add(TolkienEBook1);
            EBook TolkienEBook2 = new EBook("Two towers", "Tolkien", 300);
            books.Add(TolkienEBook2);
            EBook TolkienEBook3 = new EBook("The Return of the king", "Tolkien", 300);
            books.Add(TolkienEBook3);
            //-------------------------------------------------------------------------------------------
            //Автор - Zelazny
            //Бумажные
            PaperBook ZelaznyPaperBook1 = new PaperBook("Nine Princes in Amber", "Zelazny", 400);
            books.Add(ZelaznyPaperBook1);
            PaperBook ZelaznyPaperBook2 = new PaperBook("The Guns of Avalon", "Zelazny", 500);
            books.Add(ZelaznyPaperBook2);
            PaperBook ZelaznyPaperBook3 = new PaperBook("Sign of the Unicorn", "Zelazny", 700);
            books.Add(ZelaznyPaperBook3);
            //Электронные
            EBook ZelaznyEBook1 = new EBook("The Hand of Oberon", "Zelazny", 400);
            books.Add(ZelaznyEBook1);
            EBook ZelaznyEBook2 = new EBook("The Courts of Chaos", "Zelazny", 900);
            books.Add(ZelaznyEBook2);
            //-------------------------------------------------------------------------------------------
            //Создаем журналы
            PaperJournal WhiteDwarf1 = new PaperJournal("WhiteDwarf1", "GW", 500, 2019, 12);
            books.Add(WhiteDwarf1);
            PaperJournal WhiteDwarf2 = new PaperJournal("WhiteDwarf2", "GW", 500, 2020, 1);
            books.Add(WhiteDwarf2);
            PaperJournal WhiteDwarf3 = new PaperJournal("WhiteDwarf3", "GW", 500, 2019, 4);
            books.Add(WhiteDwarf3);
            PaperJournal WhiteDwarf4 = new PaperJournal("WhiteDwarf4", "GW", 500, 2019, 5);
            books.Add(WhiteDwarf4);
            PaperJournal WhiteDwarf5 = new PaperJournal("WhiteDwarf5", "GW", 500, 2019, 6);
            books.Add(WhiteDwarf5);
            //-------------------------------------------------------------------------------------------
            return books;
        }

        static void FreeEBookAction()
        {           
            List<IProduct> books = new List<IProduct>();

            PaperBook TolkienPaperBook1 = new PaperBook("Silmarillion", "Tolkien", 500);
            books.Add(TolkienPaperBook1);

            PaperBook TolkienPaperBook2 = new PaperBook("Hobbit", "Tolkien", 300);
            books.Add(TolkienPaperBook2);

            EBook TolkienEBook1 = new EBook("Fellowship of the ring", "Tolkien", 300);
            books.Add(TolkienEBook1);

            DeliveryCalculator calculator = new DeliveryCalculator();
            ActionProvider provider = new ActionProvider();
            ShoppingCart cart = new ShoppingCart(calculator, provider);
            List<IPromo> listOfPromos = new List<IPromo>();
            decimal finalPrice = cart.GetTotalPrice(books, listOfPromos);
            Console.WriteLine(finalPrice);
        }

        static void OnlyEBooks()
        {           
            List<IProduct> books = new List<IProduct>();

            EBook ZelaznyEBook1 = new EBook("The Hand of Oberon", "Zelazny", 400);
            books.Add(ZelaznyEBook1);

            EBook ZelaznyEBook2 = new EBook("The Courts of Chaos", "Zelazny", 900);
            books.Add(ZelaznyEBook2);

            EBook TolkienEBook1 = new EBook("Fellowship of the ring", "Tolkien", 300);
            books.Add(TolkienEBook1);

            DeliveryCalculator calculator = new DeliveryCalculator();
            ActionProvider provider = new ActionProvider();
            ShoppingCart cart = new ShoppingCart(calculator, provider);
            List<IPromo> listOfPromos = new List<IPromo>();
            decimal finalPrice = cart.GetTotalPrice(books, listOfPromos);
            Console.WriteLine(finalPrice);
        }

        static void FreeDelivery()
        {
            List<IProduct> books = new List<IProduct>();

            PaperBook TolkienPaperBook1 = new PaperBook("Silmarillion", "Tolkien", 500);
            books.Add(TolkienPaperBook1);

            PaperBook TolkienPaperBook2 = new PaperBook("Hobbit", "Tolkien", 300);
            books.Add(TolkienPaperBook2);

            DeliveryCalculator calculator = new DeliveryCalculator();
            ActionProvider provider = new ActionProvider();
            ShoppingCart cart = new ShoppingCart(calculator, provider);
            IPromo promo = new FreeDeliveryPromo();
            List<IPromo> listOfPromos = new List<IPromo> { promo };
            decimal finalPrice = cart.GetTotalPrice(books, listOfPromos);
            Console.WriteLine(finalPrice);
        }

        static void AbsoluteDiscount()
        {
            List<IProduct> books = new List<IProduct>();

            PaperBook TolkienPaperBook1 = new PaperBook("Silmarillion", "Tolkien", 500);
            books.Add(TolkienPaperBook1);

            PaperBook TolkienPaperBook2 = new PaperBook("Hobbit", "Tolkien", 300);
            books.Add(TolkienPaperBook2);

            DeliveryCalculator calculator = new DeliveryCalculator();
            ActionProvider provider = new ActionProvider();
            ShoppingCart cart = new ShoppingCart(calculator, provider);
            IPromo promo = new AbsoluteDiscountPromo(600);
            List<IPromo> listOfPromos = new List<IPromo> { promo };
            decimal finalPrice = cart.GetTotalPrice(books, listOfPromos);
            Console.WriteLine(finalPrice);
        }

        static void PercentDiscount()
        {
            List<IProduct> books = new List<IProduct>();

            PaperBook TolkienPaperBook1 = new PaperBook("Silmarillion", "Tolkien", 500);
            books.Add(TolkienPaperBook1);

            PaperBook TolkienPaperBook2 = new PaperBook("Hobbit", "Tolkien", 300);
            books.Add(TolkienPaperBook2);

            DeliveryCalculator calculator = new DeliveryCalculator();
            ActionProvider provider = new ActionProvider();
            ShoppingCart cart = new ShoppingCart(calculator, provider);
            IPromo promo = new PercentDiscountPromo(20);
            List<IPromo> listOfPromos = new List<IPromo> { promo };
            decimal finalPrice = cart.GetTotalPrice(books, listOfPromos);
            Console.WriteLine(finalPrice);
        }

        static void FreeBook()
        {
            List<IProduct> books = new List<IProduct>();

            PaperBook TolkienPaperBook1 = new PaperBook("Silmarillion", "Tolkien", 500);
            books.Add(TolkienPaperBook1);

            PaperBook TolkienPaperBook2 = new PaperBook("Hobbit", "Tolkien", 300);
            books.Add(TolkienPaperBook2);

            PaperBook ZelaznyPaperBook1 = new PaperBook("Nine Princes in Amber", "Zelazny", 400);
            books.Add(ZelaznyPaperBook1);

            DeliveryCalculator calculator = new DeliveryCalculator();
            ActionProvider provider = new ActionProvider();
            ShoppingCart cart = new ShoppingCart(calculator, provider);
            IPromo promo = new FreeBookPromo(ZelaznyPaperBook1);
            List<IPromo> listOfPromos = new List<IPromo> { promo };
            decimal finalPrice = cart.GetTotalPrice(books, listOfPromos);
            Console.WriteLine(finalPrice);
        }

        static void CheckBug()
        {
            List<IProduct> books = new List<IProduct>();

            PaperBook TolkienPaperBook1 = new PaperBook("Silmarillion", "Tolkien", 500);
            books.Add(TolkienPaperBook1);

            PaperBook TolkienPaperBook2 = new PaperBook("Hobbit", "Tolkien", 300);
            books.Add(TolkienPaperBook2);

            PaperBook ZelaznyPaperBook1 = new PaperBook("Nine Princes in Amber", "Zelazny", 400);
            books.Add(ZelaznyPaperBook1);

            DeliveryCalculator calculator = new DeliveryCalculator();
            ActionProvider provider = new ActionProvider();
            ShoppingCart cart = new ShoppingCart(calculator, provider);
            List<IPromo> listOfPromos = new List<IPromo> { };
            IPromo promo1 = new PercentDiscountPromo(20);
            listOfPromos.Add(promo1);
            IPromo promo2 = new FreeBookPromo(ZelaznyPaperBook1);
            listOfPromos.Add(promo2);
            decimal finalPrice = cart.GetTotalPrice(books, listOfPromos);
            Console.WriteLine(finalPrice);
        }

        static void TenPercentForJournals()
        {
            List<IProduct> books = new List<IProduct>();
            
            PaperJournal WhiteDwarf1 = new PaperJournal("WhiteDwarf1", "GW", 100, 2020, 1);
            books.Add(WhiteDwarf1);

            PaperJournal WhiteDwarf2 = new PaperJournal("WhiteDwarf2", "GW", 200, 2020, 3);
            books.Add(WhiteDwarf2);

            PaperJournal WhiteDwarf3 = new PaperJournal("WhiteDwarf3", "GW", 300, 2020, 5);
            books.Add(WhiteDwarf3);

            PaperJournal WhiteDwarf4 = new PaperJournal("WhiteDwarf4", "GW", 400, 2020, 6);
            books.Add(WhiteDwarf4);

            PaperJournal WhiteDwarf5 = new PaperJournal("WhiteDwarf5", "GW", 500, 2020, 7);
            books.Add(WhiteDwarf5);

            PaperJournal WhiteDwarf6 = new PaperJournal("WhiteDwarf5", "GW", 500, 2020, 9);
            books.Add(WhiteDwarf6);


            DeliveryCalculator calculator = new DeliveryCalculator();
            ActionProvider provider = new ActionProvider();
            ShoppingCart cart = new ShoppingCart(calculator, provider);
            List<IPromo> listOfPromos = new List<IPromo>();
            decimal finalPrice = cart.GetTotalPrice(books, listOfPromos);
            Console.WriteLine(finalPrice);
        }



        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Одна бесплатная электронная книга за две бумажные книги того же автора");
            Console.Write("Получилась цена - ");
            FreeEBookAction();
            Console.WriteLine("Должна быть - 800");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Только электронные книги - цена доставки = 0 ");
            Console.Write("Получилась цена - ");
            OnlyEBooks();
            Console.WriteLine("Должна быть - 1600");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Промокод на бесплатную доставку");
            Console.Write("Получилась цена - ");
            FreeDelivery();
            Console.WriteLine("Должна быть - 800");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Промокод на скидку в рублях");
            Console.Write("Получилась цена - ");
            AbsoluteDiscount();
            Console.WriteLine("Должна быть - 400");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Промокод на скидку в процентах");
            Console.Write("Получилась цена - ");
            PercentDiscount();
            Console.WriteLine("Должна быть - 840");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Промокод на бесплатную книгу");
            Console.Write("Получилась цена - ");
            FreeBook();
            Console.WriteLine("Должна быть - 800");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Проверка бага, возникавшего при примении купона на скидку в процентах и на бесплатную книгу");
            Console.Write("Получилась цена - ");
            CheckBug();
            Console.WriteLine("Должна быть - 640");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Проверка акции на скидку 10% при покупке трёх или более выпусков журнала, идущих подряд");
            Console.Write("Получилась цена - ");
            TenPercentForJournals();
            Console.WriteLine("Должна быть - 1880");
            Console.WriteLine("----------------------------------------------------------------------");

        }
    }
}
