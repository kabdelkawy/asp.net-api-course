using Microsoft.EntityFrameworkCore;
using WebAPICourse.Data;
using WebAPICourse.Dtos.CommentDtos;
using WebAPICourse.Interfaces;
using WebAPICourse.Models;

namespace WebAPICourse.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly AppDBContext _dbContext;

    public CommentRepository(AppDBContext appDBContext)
    {
        _dbContext = appDBContext;
    }

    public async Task<Comment?> GetCommentAsync(string id)
    {
        return await _dbContext.Comments.FirstOrDefaultAsync(comment=>comment.Id==id);
    }

    public async Task<List<Comment>> GetCommentsAsync()
    {
        return await _dbContext.Comments.ToListAsync();
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        await _dbContext.Comments.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> UpdateCommentAsync(Comment comment, UpdateCommentDto updateCommentDto)
    {
        if(updateCommentDto.Title != null) comment.Title = updateCommentDto.Title;
        if(updateCommentDto.Content != null) comment.Content= updateCommentDto.Content;

        await _dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> DeleteCommentAsync(Comment comment)
    {
        _dbContext.Comments.Remove(comment);
        await _dbContext.SaveChangesAsync();
        return comment;
    }

}
