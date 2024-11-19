namespace DecorGearApplication.ValueObj.Pagination;

public static IEnumerable<T> Paginate<T>(
    this IQueryable<T> source,
    SortOrderEnum sortOrder,
    Func<T, IComparable> sorter,
    int skip,
    int limit)
{
    return (sortOrder switch
    {
        SortOrderEnum.None => source,
        SortOrderEnum.Ascending => source.AsEnumerable().OrderBy(sorter).AsQueryable(),
        SortOrderEnum.Descending => source.AsEnumerable().OrderByDescending(sorter).AsQueryable(),
        _ => source,
    }).Skip(skip * limit).Take(limit);
}
