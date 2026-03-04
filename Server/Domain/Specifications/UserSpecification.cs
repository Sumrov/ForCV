using Ardalis.Specification;
using EslOnline.Domain.Aggregates;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Specifications;

public class UserSpecification : Specification<User>, ISingleResultSpecification<User>
{
    public UserSpecification(
        string? language = null,
        string? gmail = null,
        UserId? id = null
        )
    {
        if (!string.IsNullOrWhiteSpace(language))
            Query.Where(u => u.Language == language);

        if (!string.IsNullOrWhiteSpace(gmail))
            Query.Where(u => u.GMail == gmail);

        if (id != null)
            Query.Where(u => u.Id == id);
    }
}
