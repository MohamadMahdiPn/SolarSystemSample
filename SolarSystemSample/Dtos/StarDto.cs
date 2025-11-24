namespace SolarSystemSample.Dtos;

public record StarDto
{
    public string Name { get; init; } = default!;
    public string? Type { get; init; }
    public string? Description { get; init; }
    public int Size { get; init; }
    public string? Color { get; init; }
}