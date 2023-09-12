using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects
{
    public sealed class MenuReviewId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private MenuReviewId(Guid value)
        {
            Value = value;
        }

        private MenuReviewId() { }

        public static MenuReviewId Create(Guid id) => new(id);

        public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}