namespace ReviewAndRating.Domain.ValueObjects;

public class RatingValue
{
    public int Value { get; }

    public RatingValue(int value)
    {
        if (value < 1 || value > 5)
            throw new ArgumentException("Rating must be between 1 and 5.");
            
        Value = value;
    }
}