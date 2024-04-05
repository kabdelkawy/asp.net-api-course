using Microsoft.AspNetCore.Mvc;
using WebAPICourse.Dtos.CommentDtos;
using WebAPICourse.Interfaces;
using WebAPICourse.Mappers;
using WebAPICourse.Models;

namespace WebAPICourse.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepo) 
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] string id)
        {
            Comment? comment = await _commentRepo.GetCommentAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }


        [HttpGet]
        public async Task<IActionResult> GetComments() 
        {
            var comments = await _commentRepo.GetCommentsAsync();
            var commentsDto = comments.Select(comment => comment.ToCommentDtoFromModel());
            return Ok(commentsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            var comment = createCommentDto.ToCommentModelFromCreateDto();
            await _commentRepo.CreateCommentAsync(comment);
            return AcceptedAtAction(nameof(GetComment), new { id = comment.Id }, comment.ToCommentDtoFromModel());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] string id,[FromBody] UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentRepo.GetCommentAsync(id);
            if (comment == null) return NotFound();
            await _commentRepo.UpdateCommentAsync(comment, updateCommentDto);
            return AcceptedAtAction(nameof(GetComment), new { id = comment.Id }, comment.ToCommentDtoFromModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] string id)
        {
            var comment = await _commentRepo.GetCommentAsync(id);
            if (comment == null) return NotFound();
            await _commentRepo.DeleteCommentAsync(comment);
            return NoContent();
        }
    }
}
