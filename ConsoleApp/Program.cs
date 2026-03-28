using Tracker.WebAPIClient;
using DataModel;
using Microsoft.EntityFrameworkCore;
using DataServices;
using System.Net.Http;
using System.Net.Http.Json;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Track that this app is making an authorised call to the Web API
            ActivityAPIClient.Track(StudentID: "S00250500", StudentName: "Elain Polakova", activityName: "Rad302 FE 2026", Task: "Authorised calling to Web API");

            // Create HttpClient pointed at the WebAPI
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7072/")
            };

            // Create the generic HttpClientService from the RAD302GenericDataService project
            // Pass null for ILocalStorageService in a console app (not required here)
            var clientService = new HttpClientService(httpClient, null);

            // Login with Margaret Millan's credentials and obtain a token
            Console.WriteLine("Logging in as mmillian@itsligo.ie...");
            var loginResult = await clientService.login("mmillian@itsligo.ie", "LibAdmin$1");
            if (!loginResult)
            {
                Console.WriteLine("Login failed. Exiting.");
                return;
            }

            // Retrieve and display token (if stored)
            var token = await clientService.GetTokenAsync();
            if (token != null)
                Console.WriteLine($"Obtained token: {token.AccessToken.Substring(0, Math.Min(50, token.AccessToken.Length))}...");

            // Get a list of all books from the API
            Console.WriteLine("Retrieving list of books...");
            var books = await clientService.getCollection<Book>("api/books");
            Console.WriteLine($"Found {books.Count} books:");
            foreach (var b in books)
            {
                Console.WriteLine($"- [{b.BookID}] {b.Title} by {b.Author} (ISBN: {b.ISBN})");
            }

            // Get a loanee for a book that is known to be out on loan (use book id 1 if seeded)
            int loanedBookId = 1;
            Console.WriteLine($"Retrieving loanee for book id {loanedBookId}...");
            try
            {
                var loanee = await httpClient.GetFromJsonAsync<Member>($"api/books/{loanedBookId}/loanee");
                if (loanee != null)
                    Console.WriteLine($"Book {loanedBookId} is loaned to: {loanee.FirstName} {loanee.SecondName}");
                else
                    Console.WriteLine($"No loanee found for book {loanedBookId}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting loanee: {ex.Message}");
            }

            // Add a new book to the collection
            var newBook = new Book
            {
                BookID = 9,
                Title = "Blazor Trails",
                ISBN = "716746476",
                Author = "Tom Parsons",
                LoanType = LoanType.Restricted,
                LoanDuration = 1
            };

            Console.WriteLine("Adding new book: Blazor Trails...");
            try
            {
                var added = await clientService.Post<Book>("api/books", newBook);
                if (added != null)
                    Console.WriteLine($"Added book with id {added.BookID}: {added.Title}");
                else
                    Console.WriteLine("Failed to add book or no response returned.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
            }

            Console.WriteLine("Done.");
        }
    }
}
