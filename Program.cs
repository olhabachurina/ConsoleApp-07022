using ConsoleAppсд07022.context;
using ConsoleAppсд07022.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConsoleAppсд07022;

class Program
{
    static void Main(string[] args)
    {
        var dbContext = new context.AppDbcontext();
        var dataAccess = new DataAccess(dbContext);

        // Mетод, который получает список всех книг определенного автора и выводит следующую информацию: 
        // Название книги. 
        //Имя автора. 
        //Название категории. 
        //Цена книги. 
        //Дата выпуска книги.
        //Console.WriteLine("Books by author:");
        //dataAccess.PrintBooksByAuthor(2); 
        //2) Mетод, который производит удаление книги с наименьшей ценой в определенной категории.
        //Console.WriteLine("Deleting cheapest book in category...");
        //dataAccess.DeleteCheapestBookInCategory(1); 
        //Напишите метод, который увеличивает для всех книг стоимость на 5%.
        //Console.WriteLine("Increasing book prices by 5%...");
        //dataAccess.IncreaseBookPricesByFivePercent();

        // метод просмотра списка книг в определенной ценовой категории (к примеру, от 50 до 100$).
        //Console.WriteLine("Books in price range:");
        //var booksInRange = dataAccess.GetBooksByPriceRange(50, 100); 
        //foreach (var book in booksInRange)
        //{
        //    Console.WriteLine($"Title: {book.Title}, Price: {book.Price}");
        //}

        //  метод, для подсчета количества книг каждого автора. Результат вывести, используя анонимную коллекцию или структуру (AuthorId, AuthorName, BooksCount
        //Console.WriteLine("Books count by author:");
        //var booksCountByAuthor = dataAccess.GetBooksCountByAuthor();
        //foreach (var author in booksCountByAuthor)
        //{
        //    Console.WriteLine($"AuthorId: {author.AuthorId}, AuthorName: {author.AuthorName}, BooksCount: {author.BooksCount}");
        //}
        //Console.ReadLine(); 
    }
}





