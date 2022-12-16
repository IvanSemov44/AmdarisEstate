using IvanRealEstate.Entities.Models;
using IvanRealEstate.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanRealEstate.IntegrationTests.Helpers
{
    public class Utilities
    {
        public static void InitializeDbForTests(RepositoryContext db)
        {
            //var city = new City
            //{ 
            //    CityName = "Varna"
            //};

            //db.Cities?.Add(city);
            //db.SaveChanges();

            //var city1 = new City { CityName = "Sofia" };
            //db.Cities?.Add(city1);
            //db.SaveChanges();

            //var author1 = new Author("John Smith");
            //var author2 = new Author("Dan Brown");
            //var author3 = new Author("Laura Palmer");

            //db.Authors.AddRange(author1, author2, author3);

            //var book = new Book("Learning C#", "Learn C# Programming Language", DateTime.Today.AddDays(-100), "Cool Publisher", 200, new List<Author> { author1, author3 });

            //db.Books.Add(book);
            //db.SaveChanges();

            //var book2 = new Book("Learning OOP", "Learn OO Principles", DateTime.Today.AddDays(-200), "Cool Publisher", 150, new List<Author> { author1 });

            //db.Books.Add(book2);
            //db.SaveChanges();

            //var book3 = new Book("Learning SQL", "Learn SQL Server", DateTime.Today.AddDays(-150), "Cool Publisher", 250, new List<Author> { author2 });

            //db.Books.Add(book3);
            //db.SaveChanges();
        }
    }
}
