using ASP_NET_WEB_API.Models;
using ASP_NET_WEB_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_WEB_API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    //Create an instance of the Interface repository
     private readonly IBookRepository _repo;

    public BookController(IBookRepository repo)
    {
        this._repo = repo;
    }
    
    // GET: api/Book
    //* ? This will return All books and a status code 200 => Ok
    [HttpGet]
    [ProducesResponseType(200, Type =typeof(IEnumerable<Book>))]
    public async Task<ActionResult<Book>> GetBooksFromDB()
    {
        try{
            //Calling the repository for retrieving books
            var result = await _repo.GetBooks();
            
            return Ok(result);
        }catch(Exception){
            return StatusCode(StatusCodes.Status500InternalServerError,
            "Error in retrieving books from Database");
        } 
    }

    // GET: api/Book/[id]
    //* ? This will return a book and a status code 200 => Ok
    [HttpGet("{id:int}", Name = nameof(GetBook))] // named route
    [ProducesResponseType(200, Type = typeof(Book))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        try{
            //Calling the repository for retrieving a book
            var book = await _repo.GetBook(id);
            //checking if the book variable return a book
            if(book == null)
                return NotFound();  // 404 Resource not found
            
        return Ok(book);  // 200 OK with book in body

        }catch(Exception){
            return StatusCode(StatusCodes.Status500InternalServerError,
            "Error in retrieving a book from Database");
        } 
    }

    // POST: api/Book
    //* ? This will Create a new book and return status code 201 => Created
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Book))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Book>> CreateBook([FromBody] Book book){
        try{
            //Checking if the object list is not empty
            if(book == null){
                return BadRequest(); // 400 Bad request
            }
            //Checking if the parameters are valid
            if(!ModelState.IsValid){
                return BadRequest(ModelState); // 400 Bad request
            }
            //Calling Add repository
            var create = await _repo.AddBook(book);
            
            //using on Created method for creating a path/link like 
            return CreatedAtAction(nameof(GetBook), 
                    new {id = create.Book_Id}, create );      // 201 OK with book in body

        }catch(Exception){
            return StatusCode(StatusCodes.Status500InternalServerError,
            "Error in Creating a book from Database");
        } 
    }

    // PUT: api/Book/[id]
    //* ? This will Update a book bas on it's ID and return status code 204 => No Content
    [HttpPut("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book book)
    {
        try
        {
            if (book == null)
            {
                return BadRequest(); // 400 Bad request
            }
            if (book.Book_Id != id)
            {
                return BadRequest("Book ID mismatch"); // 400 Bad request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }

            var existingBook = await _repo.GetBook(id);
            if(existingBook == null){
                return NotFound($"Book with Id = {id} Not Found");      // 404 Resource not found
            }

            return await _repo.UpdateBook(id, book);

        }catch(Exception){
            return StatusCode(StatusCodes.Status500InternalServerError,
            "Error in Updating a book from Database");
        } 
    }
    

    // DELETE: api/Book/[id]
      //* ? This will delete a book based on it's ID and return status code 204 => No Content
    // DELETE: api/books/[id]
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        try{

            bool? deleted = await _repo.DeleteBook(id);
            if(deleted == false){
                 return NotFound($"Book with Id = {id} Not Found");      // 404 Resource not found
            }
            return Ok($"Book with Id = {id} deleted successfully");
        }catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
             "Error from deleting " + id + " the Book");
        } 
    }
   
}
