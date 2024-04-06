using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICourse.Models;

[Table("Comments")]
public class Comment
{
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime? CreatedAt { get; set; }

    public string? StockId { get; set; }

    public Stock? Stock { get; set; }
}
