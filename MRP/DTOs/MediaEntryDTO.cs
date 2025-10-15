namespace MRP.DTO
{
    internal record MediaEntryDTO
    {
        public Guid id { get; init; }
        public Guid creator { get; init; }
        public string title { get; init; } = string.Empty;
        public string description { get; init; } = string.Empty;
        public int ageRestiction { get; init; }
        public DateOnly releaseYear {  get; init; }
    }
}
