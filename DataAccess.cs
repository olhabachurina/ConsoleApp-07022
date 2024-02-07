using ConsoleAppсд07022.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using ConsoleAppсд07022.Models;
namespace ConsoleAppсд07022
{
    public class DataAccess
    {
        private readonly AppDbcontext dbContext;

        public DataAccess(AppDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Mетод, который получает список всех книг определенного автора и выводит следующую информацию: 
        // Название книги. 
        //Имя автора. 
        //Название категории. 
        //Цена книги. 
        //Дата выпуска книги.
        public void PrintBooksByAuthor(int authorId)
        {
            var books = GetBooksByAuthor(authorId);
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.AuthorName}, Category: {book.CategoryName}, Price: {book.Price}, Release Date: {book.ReleaseDate}");
            }
        }
        public IEnumerable<dynamic> GetBooksByAuthor(int authorId)
        {
            using (var db = dbContext.GetConnection())
            {
                var sql = @"
            SELECT b.Title, a.Name as AuthorName, c.Name as CategoryName, b.Price, b.ReleaseDate 
            FROM Books b
            INNER JOIN Authors a ON b.AuthorId = a.Id
            INNER JOIN Categories c ON b.CategoryId = c.Id
            WHERE b.AuthorId = @AuthorId";

                return db.Query<dynamic>(sql, new { AuthorId = authorId });
            }
        }
        //2) Mетод, который производит удаление книги с наименьшей ценой в определенной категории.
        public void DeleteCheapestBookInCategory(int categoryId)
        {
            using (var db = dbContext.GetConnection())
            {
                var sql = @"
            DELETE FROM Books
            WHERE Id = (
                SELECT TOP 1 Id FROM Books
                WHERE CategoryId = @CategoryId
                ORDER BY Price ASC
            )";

                db.Execute(sql, new { CategoryId = categoryId });
            }
        }
        //3)метод, который увеличивает для всех книг стоимость на 5%.
        public void IncreaseBookPricesByFivePercent()
        {
            using (var db = dbContext.GetConnection())
            {
                var sql = "UPDATE Books SET Price = Price * 1.05";
                db.Execute(sql);
            }
        }
        //4)метод просмотра списка книг в определенной ценовой категории (к примеру, от 50 до 100$).
        public IEnumerable<Book> GetBooksByPriceRange(decimal minPrice, decimal maxPrice)
        {
            using (var db = dbContext.GetConnection())
            {
                var sql = @"
            SELECT * FROM Books
            WHERE Price BETWEEN @MinPrice AND @MaxPrice";

                return db.Query<Book>(sql, new { MinPrice = minPrice, MaxPrice = maxPrice });
            }
        }
        //метод, для подсчета количества книг каждого автора.Результат вывести, используя анонимную коллекцию или структуру (AuthorId, AuthorName, BooksCount
        public IEnumerable<dynamic> GetBooksCountByAuthor()
        {
            using (var db = dbContext.GetConnection())
            {
                var sql = @"
            SELECT a.Id as AuthorId, a.Name as AuthorName, COUNT(b.Id) as BooksCount
            FROM Authors a
            LEFT JOIN Books b ON a.Id = b.AuthorId
            GROUP BY a.Id, a.Name";

                return db.Query<dynamic>(sql);
            }
        }
    }
}