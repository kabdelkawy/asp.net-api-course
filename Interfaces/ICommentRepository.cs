using WebAPICourse.Dtos.CommentDtos;
using WebAPICourse.Models;

namespace WebAPICourse.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetCommentsAsync();
    Task<Comment?> GetCommentAsync(string id);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<Comment?> UpdateCommentAsync(Comment comment,UpdateCommentDto  updateCommentDto);
    Task<Comment?> DeleteCommentAsync(Comment comment);
    Task<bool> IsStockExist(string? id);

}
