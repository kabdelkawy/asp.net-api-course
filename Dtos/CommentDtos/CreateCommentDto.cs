using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICourse.Dtos.CommentDtos;

public class CreateCommentDto
{
    [Required]
    [MaxLength(20,ErrorMessage = "Title should be less than 20 charactares!")]
    [MinLength(5,ErrorMessage = "Title should be more than 5 charactares!")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(280, ErrorMessage = "Content should be less than 280 charactares!")]
    [MinLength(5, ErrorMessage = "Title should be more than 5 charactares!")]

    public string Content { get; set; } = string.Empty;
    [Required]
    public string? StockId { get; set; }
}
