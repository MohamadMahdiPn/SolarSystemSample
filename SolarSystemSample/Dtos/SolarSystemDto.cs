namespace SolarSystemSample.Dtos;

public record SolarSystemDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public StarDto Star { get; init; } = default!;
    public List<PlanetDto> Planets { get; init; } = new();
}