namespace SolarSystemSample.Data.Entities;

public class SolarSystem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;         // مثلاً "منظومه شمسی"
    public string? Description { get; set; }

    // مشخصات ستاره مرکزی
    public string StarName { get; set; } = default!;
    public string? StarType { get; set; }                // مثل "G-type star"
    public string? StarDescription { get; set; }
    public int StarSize { get; set; }                    // برای UI
    public string? StarColor { get; set; }               // مثلا کد رنگ

    public ICollection<Planet> Planets { get; set; } = new List<Planet>();
}