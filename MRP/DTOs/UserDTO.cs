namespace MRP.DTO
{
    internal record UserDTO
    {
        public Guid Id { get; init; }
        public string Username { get; init; } = string.Empty;
    }
}
