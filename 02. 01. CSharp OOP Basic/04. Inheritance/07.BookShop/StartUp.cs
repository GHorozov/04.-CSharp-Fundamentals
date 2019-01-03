namespace _07.BookShop
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var author = Console.ReadLine();
                var title = Console.ReadLine();
                var price = decimal.Parse(Console.ReadLine());

                var book = new Book(author, title, price);
                var goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book);
                Console.WriteLine();
                Console.WriteLine(goldenEditionBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
