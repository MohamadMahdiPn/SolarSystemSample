namespace SolarSystemSample.Data.Entities;

public class Moon
{
    public Guid Id { get; set; }

    public Guid PlanetId { get; set; }
    public Planet Planet { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string Label { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string? Description { get; set; }

    public string? Distance { get; set; }
    public string? YearLength { get; set; }
    public string? DayLength { get; set; }

    // تنظیمات نمایشی
    public int OrbitRadius { get; set; }
    public double OrbitDurationSeconds { get; set; }
    public int Size { get; set; }
    public string Color { get; set; } = "#e5e5e5";
}