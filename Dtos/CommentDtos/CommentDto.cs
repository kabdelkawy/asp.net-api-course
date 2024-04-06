
namespace WebAPICourse.Dtos.CommentDtos;

public class CommentDto
{

    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime? CreatedAt { get; set; }

    public string? StockId { get; set; }

}
