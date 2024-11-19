using DecorGearDomain.Enum;
using System.Linq;

public static class PaginationExtensions
{
    public static IQueryable<T> Paginate<T>(
        this IQueryable<T> source,
        SortOrderEnum sortOrder,
        Func<T, object> sorter,
        int skip,
        int limit)
    {
        // Sắp xếp theo yêu cầu
        var sortedSource = sortOrder switch
        {
            SortOrderEnum.None => source,
            SortOrderEnum.Ascending => source.OrderBy(x => sorter(x)),
            SortOrderEnum.Descending => source.OrderByDescending(x => sorter(x)),
            _ => source
        };

        // Áp dụng phân trang
        return sortedSource.Skip(skip).Take(limit);
    }
}