namespace Supermarket.DataTransferModels.Response
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int TotalCount { get; set; }
    }
}

