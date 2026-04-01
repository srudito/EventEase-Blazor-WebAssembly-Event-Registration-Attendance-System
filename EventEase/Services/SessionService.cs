namespace EventEase.Services;

public class SessionService
{
    public string? CurrentUserName { get; set; }

    // Tracks event IDs the current user registered for (optional but harmless)
    public HashSet<int> RegisteredEvents { get; } = new();
}