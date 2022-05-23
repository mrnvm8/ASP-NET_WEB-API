/**
 * * The Following Comments was Created by the author: LINDOKUHLE MAGAGULA
 * * This code was created using VSCode
 * * The Comments Formats is using the library (Better Comments) by Aaron Bond
 * * This code was created May 2022
*/

using ASP_NET_WEB_API.Data;
using ASP_NET_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_WEB_API.Repositories;

public class BookRepository : IBookRepository
{
    // Create a database instance
    private readonly DBAccess _context;

    //Add class class constructor and pass database
    public BookRepository(DBAccess context)
    {
        this._context = context;
    }

    /***
     ** ? This Task will Add a Book to the Database.
     ** ? it Will receive list of information about the book
    */
    public async Task<Book> AddBook(Book book)
    {
         // add to database using EF Core
        var db = _context.Books.Add(book);
        //Save the Changes that you just made into the database
        await _context.SaveChangesAsync(); 

        //return an Entity
        return db.Entity;
    }
    /***
     * *? This Method is for Reading(Select) All the information the book table 
     * *? from the database and return them
     * *? just use the Arrow functions that return a list of books
    */
    public async Task<IEnumerable<Book>> GetBooks() =>
            await _context.Books.ToListAsync();

    /***
     * *? Read/Select a specific book by its ID from database and return it.
     * *? just use the Arrow functions taht return a book
    */       
    public async Task<Book> GetBook(int Id) => 
            await _context.Books.FirstOrDefaultAsync(b => b.Book_Id.Equals(Id));
    
    /***
     ** ? Update a specific book by its ID from database.
    */
    public async Task<Book> UpdateBook(int Id, Book book)
    {
        /**
         * *? Checking if the book exists
        */
       var UpdateBook = await _context.Books
            .FirstOrDefaultAsync(b => b.Book_Id.Equals(Id));
        /*
        *? Checking if the return information is not empty
        * if it's not Empty, save the receive information 
        * from the parameters to the to the returned information
        * for update 
        */
        if (UpdateBook != null)
        {
            UpdateBook.Title = book.Title;
            UpdateBook.Author = book.Author;
            UpdateBook.Category = book.Category;

            //Save the changes
            await _context.SaveChangesAsync();
            //return the updated book
            return UpdateBook;
        }
        return null;
    }
    /***
     * ? Delete a specific book by it's ID from database
    */
    public async Task<bool?> DeleteBook(int Id)
    {
        /**
         * *? Checking if the book exists
        */
        var delete = await _context.Books
                    .FirstOrDefaultAsync(b => b.Book_Id.Equals(Id));
        if(delete != null){
            // remove from database
            _context.Books.Remove(delete);
            //Save the changes 
            await _context.SaveChangesAsync();
            //return a true after save 
            return true;
        }
        
        return false;
    }

    
}