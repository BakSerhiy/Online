using MediatR;
using Microsoft.AspNetCore.Mvc;
using Online.ReviewAndRating.Application.Commands;

using MediatR;

namespace ReviewAndRating.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Review
    [HttpGet]
    public async Task<IActionResult> GetAllReviews()
    {
        var reviews = await _mediator.Send(new GetReviewsQuery());
        return Ok(reviews);
    }

    // POST: api/Review
    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAllReviews), new { id = result.Id }, result);
    }
}

public class GetReviewsQuery : IRequest<object?>
{
}