using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiCrud.Database.Seeder
{
    public static class DataSeeder
    {
        public static void Seed(DataContext context)
        {
            // Criação de gêneros
            if (!context.Genres.Any())
            {
                var genres = new List<Genre>
                {
                    new Genre { Name = "Fiction" },
                    new Genre { Name = "Non-Fiction" },
                    new Genre { Name = "Fantasy" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Biography" }
                };

                context.Genres.AddRange(genres);
                context.SaveChanges();
            }

            // Criação de autores
            if (!context.Authors.Any())
            {
                var authors = new List<Author>
                {
                    new Author { Name = "Douglas", LastName = "Feuser", BirthDate = new DateTime(1994, 2, 2) },
                    new Author { Name = "Lucas", LastName = "Rand", BirthDate = new DateTime(1995, 7, 31) },
                    new Author { Name = "Andre", LastName = "Demo", BirthDate = new DateTime(1996, 2, 22) },
                    new Author { Name = "Isaac", LastName = "Asimov", BirthDate = new DateTime(1920, 1, 2) }
                };

                context.Authors.AddRange(authors);
                context.SaveChanges();
            }

            // Criação de clientes
            if (!context.Clients.Any())
            {
                var clients = new List<Client>
                {
                    new Client { Name = "Will", LastName = "Smith" },
                    new Client { Name = "Douglas", LastName = "Feuser" },
                    new Client { Name = "Bob", LastName = "Johnson" },
                    new Client { Name = "Charlie", LastName = "Brown" }
                };

                context.Clients.AddRange(clients);
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                var books = new List<Book>
                {
                    new Book { Title = "1984", AuthorId = 1, GenreId = 1 },
                    new Book { Title = "Test", AuthorId = 1, GenreId = 2 },
                    new Book { Title = "Harry Potter and the Sorcerer's Stone", AuthorId = 2, GenreId = 3 },
                    new Book { Title = "Foundation", AuthorId = 3, GenreId = 4 }
                };

                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }
    }
}
