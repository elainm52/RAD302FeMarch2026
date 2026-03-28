using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DataModel;
using Tracker.WebAPIClient;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    // API controller to manage Book resources.
    // Only users in the "Head Librarian" role are authorized to call these endpoints.
    // Uses the IBookRepository<Book> implementation to perform data operations.
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Head Librarian")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository<Book> _bookRepository;
        private readonly ILogger<BooksController> _logger;

        // Constructor - receives repository and logger via dependency injection.
        // Also sends an activity track call to the tracker service.
        public BooksController(IBookRepository<Book> bookRepository, ILogger<BooksController> logger)
        {
            ActivityAPIClient.Track(StudentID: "S00250500", StudentName: "Elain Polakova", activityName: "Rad302 FE 2026", Task: " Testing BooksController");

            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _logger = logger;
        }

        // GET api/books
        // Returns all books in the library.
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            try
            {
                var books = _bookRepository.GetAll();
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving books: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/books/{id}
        // Returns a single book by id.
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            try
            {
                var book = _bookRepository.Get(id);
                if (book == null)
                    return NotFound($"Book with id {id} not found");
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving book {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/books
        // Adds a new book to the library.
        [HttpPost]
        public ActionResult<Book> Create([FromBody] Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest("Book cannot be null");

                _bookRepository.Add(book);
                return CreatedAtAction(nameof(Get), new { id = book.BookID }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating book: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/books/range
        // Adds multiple books in a single request.
        [HttpPost("range")]
        public IActionResult CreateRange([FromBody] IEnumerable<Book> books)
        {
            try
            {
                if (books == null)
                    return BadRequest("Books collection cannot be null");

                _bookRepository.AddRange(books);
                return Ok(new { message = "Books added successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating books: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //DELETE api/books/{id}
        // Deletes a book by id.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var book = _bookRepository.Get(id);
                if (book == null)
                    return NotFound($"Book with id {id} not found");

                _bookRepository.Remove(book);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting book {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/books/{id}/loanee
        // Returns the member who currently has the specified book on loan, or NotFound if not on loan.
        [HttpGet("{id}/loanee")]
        public ActionResult<Member> GetLoanee(int id)
        {
            try
            {
                var member = _bookRepository.GetBookLoanee(id);
                if (member == null)
                    return NotFound($"Book {id} is not currently on loan");
                return Ok(member);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving loanee for book {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
