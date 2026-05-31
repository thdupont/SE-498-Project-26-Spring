using Microsoft.AspNetCore.Mvc;

namespace Project498.WebApi.Controllers;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private static readonly Dictionary<int, Book> Books = new()
    {
        { 1, new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937 }},
        { 2, new Book { Id = 2, Title = "The Fellowship of the Ring", Author = "J.R.R. Tolkien", Year = 1954 }},
        { 3, new Book { Id = 3, Title = "The Two Towers", Author = "J.R.R. Tolkien", Year = 1954 }},
        { 4, new Book { Id = 4, Title = "The Return of the King", Author = "J.R.R. Tolkien", Year = 1955 }},
        { 5, new Book { Id = 5, Title = "The Silmarillion", Author = "J.R.R. Tolkien", Year = 1977 }},    
    };

    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var isSuccess = Books.TryGetValue(id, out var book);

        if (!isSuccess) 
            return NotFound();
        
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public ActionResult<Book> Delete(int id)
    {
        var isSuccess = Books.Remove(id);

        if (!isSuccess) 
            return NotFound();
        
        return Ok();
    }

    [HttpPost]
    public ActionResult<Book> Post([FromBody] Book? book)
    {
        if (book == null)
            return BadRequest("Could not bind book");

        Books[book.Id] = book;
        
        return Ok(book);
    }
}