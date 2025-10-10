namespace MRP.DTO
{
    /// <summary>
    /// DTO for creating new User
    /// </summary>
    internal record CreateUserDTO
    {
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}
