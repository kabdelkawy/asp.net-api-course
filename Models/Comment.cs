namespace WebAPICourse.Models;

public class Comment
{
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string? StockId { get; set; }

    public Stock? Stock { get; set; }
}
