namespace CQRSExample.Domain;

public class ProfileEntity
{
    public int Id { get; set; }
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public string Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}