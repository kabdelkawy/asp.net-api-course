using WebAPICourse.Dtos.CommentDtos;
using WebAPICourse.Models;

namespace WebAPICourse.Mappers;

public static class CommentMappers
{
    public static CommentDto ToCommentDtoFromModel(this Comment commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreatedAt = commentModel.CreatedAt,
            StockId = commentModel.StockId
        };
    }

    public static Comment ToCommentModelFromCreateDto(this CreateCommentDto createCommentDto)
    {
        return new Comment
        {
            Id = Guid.NewGuid().ToString(),
            Title = createCommentDto.Title,
            Content = createCommentDto.Content,
            StockId = createCommentDto.StockId
        };
    }
}
