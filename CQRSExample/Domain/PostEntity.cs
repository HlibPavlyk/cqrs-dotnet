namespace CQRSExample.Domain;

public class PostEntity
{
    public int Id { get; set; }
    public string Author { get; set; } 
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
}