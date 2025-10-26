namespace firm_registry_api.DTOs
{
    public class PaginationQuery
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? SectorId { get; set; }
        public int? GroupId { get; set; }
        public string? Search { get; set; }
    }
}
