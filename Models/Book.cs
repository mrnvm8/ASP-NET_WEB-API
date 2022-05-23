
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_WEB_API.Models;

[Table("Books")]
public class Book
{
    [Key]
    public int Book_Id { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}