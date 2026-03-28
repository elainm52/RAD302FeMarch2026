using Tracker.WebAPIClient;
using DataModel;
using Microsoft.EntityFrameworkCore;
using DataServices;
using System.Net.Http;
using System.Net.Http.Json;
using ViewModels;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00250500", StudentName: "Your Name", activityName: "Rad302 FE 2026", Task: "Calling Of Web API");

            // Create HttpClient for Web API
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7072/");

                // Create HttpClientService
                HttpClientService httpClientService = new HttpClientService(httpClient, null);

                Console.WriteLine("\n Authenticate Web API Key \n");

                // Login using Margaret Millan's credentials
                bool loginSuccess = await httpClientService.login("mmilan@itsligo.ie", "LibAdmin$1");

                if (loginSuccess)
                {
                    Console.WriteLine("✓ Authentication successful!");
                    Console.WriteLine($"Token: {httpClientService.UserToken.Substring(0, Math.Min(50, httpClientService.UserToken.Length))}...\n");

                    // Get all books from the Web API
                    Console.WriteLine(" Fetch All Books \n");

                    try
                    {
                        var books = await httpClientService.getCollection<Book>("api/books");

                        if (books != null && books.Count > 0)
                        {
                            Console.WriteLine($"Total Books in Library: {books.Count}\n");

                            // Get books currently out on loan from local database
                            using (LibraryContext context = new LibraryContext())
                            {
                                var booksOnLoan = context.Loans
                                    .Select(l => l.BookID)
                                    .Distinct()
                                    .ToList();

                                Console.WriteLine("Books Out on Loan \n");

                                foreach (var book in books)
                                {
                                    bool isOnLoan = booksOnLoan.Contains(book.BookID);
                                    string loanStatus = isOnLoan ? "[ ON LOAN ]" : "[ AVAILABLE ]";

                                    Console.WriteLine($"{loanStatus} ID: {book.BookID}");
                                    Console.WriteLine($"  Title: {book.Title}");
                                    Console.WriteLine($"  Author: {book.Author}");
                                    Console.WriteLine($"  ISBN: {book.ISBN}");
                                    Console.WriteLine($"  Type: {book.LoanType} (Duration: {book.LoanDuration} days)");
                                    Console.WriteLine("-------------------------------------------");
                                }

                                // Display detailed information for books on loan
                                Console.WriteLine("\n Loan Info\n");

                                var loansDetail = context.Loans
                                    .Include(l => l.Book)
                                    .Include(l => l.Member)
                                    .OrderBy(l => l.Book.Title)
                                    .ToList();

                                if (loansDetail.Count == 0)
                                {
                                    Console.WriteLine("No books are currently out on loan.");
                                }
                                else
                                {
                                    foreach (var loan in loansDetail)
                                    {
                                        Console.WriteLine($"Book: {loan.Book.Title}");
                                        Console.WriteLine($"Author: {loan.Book.Author}");
                                        Console.WriteLine($"Borrowed by: {loan.Member.FirstName} {loan.Member.SecondName}");
                                        Console.WriteLine($"Loan Date: {loan.LoanIssueDate:dd/MM/yyyy}");
                                        Console.WriteLine($"Loan Duration: {loan.Book.LoanDuration} days");
                                        Console.WriteLine("-------------------------------------------");
                                    }
                                    Console.WriteLine($"\nTotal Books Out on Loan: {loansDetail.Count}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No books found or unable to retrieve books from Web API.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error retrieving books from Web API: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("✗ Authentication failed!");
                    Console.WriteLine($"Status: {httpClientService.UserStatus}");
                    Console.WriteLine($"Error: {httpClientService.UserToken}");
                }
            }
        }
    }
}

