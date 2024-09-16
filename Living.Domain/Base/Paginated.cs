namespace Living.Domain.Base;
public class Paginated<T>(IEnumerable<T> items, int pageIndex, int pageSize, long totalCount)
{
    public IEnumerable<T> Items { get; } = items;
    public int PageIndex { get; } = pageIndex;
    public int PageSize { get; } = pageSize;
    public long TotalCount { get; } = totalCount;
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
}
