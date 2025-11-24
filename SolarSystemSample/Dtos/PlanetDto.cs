namespace SolarSystemSample.Dtos;

public record PlanetDto
{
    public Guid Id { get; init; }
    public string Label { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Type { get; init; } = default!;
    public string? Description { get; init; }
    public string? Distance { get; init; }
    public string? Year { get; init; }
    public string? Day { get; init; }

    public int OrbitRadius { get; init; }
    public double OrbitDuration { get; init; }
    public int Size { get; init; }
    public string Color { get; init; } = "#ffffff";

    public List<MoonDto> Moons { get; init; } = new();
}