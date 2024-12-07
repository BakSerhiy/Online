using AutoMapper;
using MediatR;
using Online.ReviewAndRating.Application.DTOs;
using ReviewAndRating.Domain.Interfaces;

namespace Online.ReviewAndRating.Application.Queries;

public class GetReviewsByProductQueryHandler : IRequestHandler<GetReviewsByProductQuery, IEnumerable<ReviewDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetReviewsByProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewDTO>> Handle(GetReviewsByProductQuery request,
        CancellationToken cancellationToken)
    {
        var reviews = await _unitOfWork.ReviewRepository.GetReviewsByProductIdAsync(request.ProductId);
        return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
    }
}