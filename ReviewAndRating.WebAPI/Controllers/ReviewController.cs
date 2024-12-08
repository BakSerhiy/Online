using MediatR;
using Microsoft.AspNetCore.Mvc;
using Online.ReviewAndRating.Application.Commands;
using Online.ReviewAndRating.Application.DTOs;
using Online.ReviewAndRating.Application.Queries;

namespace ReviewAndRating.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ReviewController> _logger;

    public ReviewController(IMediator mediator, ILogger<ReviewController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Отримати список відгуків для продукту.
    /// </summary>
    [HttpGet("{productId:guid}")]
    public async Task<IActionResult> GetReviews(Guid productId)
    {
        try
        {
            var query = new GetReviewsByProductQuery(productId);
            var reviews = await _mediator.Send(query);
            return Ok(reviews);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Помилка при отриманні відгуків для продукту з ID {ProductId}", productId);
            return StatusCode(500, "Виникла помилка на сервері.");
        }
    }

    /// <summary>
    /// Створити новий відгук.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var reviewId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetReviews), new { productId = command.ProductId }, reviewId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Помилка при створенні відгуку.");
            return StatusCode(500, "Виникла помилка на сервері.");
        }
    }
}