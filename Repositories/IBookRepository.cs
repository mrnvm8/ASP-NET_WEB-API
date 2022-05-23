/**
* * The Following Comments was Created by the author: LINDOKUHLE MAGAGULA
* * This code was created using VSCode
* * The Comments Formats is using the library (Better Comments) by Aaron Bond
* * This code was created May 2022
*/

using ASP_NET_WEB_API.Models;
namespace ASP_NET_WEB_API.Repositories;
public interface IBookRepository
{
    //? Interface for the Abstraction Data Access Layer
    //? This Interface will hide how Data is Access and Modified in the Database.
    //? The Data Access details will be in the respective repository.
    //? This repository will hold operation method for CRUD the Database.
    //? And will contain what to do operations, not how to do them.

    Task<Book> AddBook(Book book);
    Task<IEnumerable<Book>> GetBooks();
    Task<Book> GetBook(int Id);
    Task<Book> UpdateBook(int Id, Book book);
    Task<bool?> DeleteBook(int Id);

}