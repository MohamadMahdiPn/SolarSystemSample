using SolarSystemSample.Data.Entities;
using SolarSystemSample.Dtos;

namespace SolarSystemSample.Profiles;

public static class DtoProfiles
{
    public static SolarSystemDto MapToDto(this SolarSystem s)
    {
        return new SolarSystemDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Star = new StarDto
            {
                Name = s.StarName,
                Type = s.StarType,
                Description = s.StarDescription,
                Size = s.StarSize,
                Color = s.StarColor
            },
            Planets = s.Planets
                .OrderBy(p => p.OrbitRadius)
                .Select(p => new PlanetDto
                {
                    Id = p.Id,
                    Label = p.Label,
                    Name = p.Name,
                    Type = p.Type,
                    Description = p.Description,
                    Distance = p.Distance,
                    Year = p.YearLength,
                    Day = p.DayLength,
                    OrbitRadius = p.OrbitRadius,
                    OrbitDuration = p.OrbitDurationSeconds,
                    Size = p.Size,
                    Color = p.Color,
                    Moons = p.Moons
                        .OrderBy(m => m.OrbitRadius)
                        .Select(m => new MoonDto
                        {
                            Id = m.Id,
                            Label = m.Label,
                            Name = m.Name,
                            Type = m.Type,
                            Description = m.Description,
                            Distance = m.Distance,
                            Year = m.YearLength,
                            Day = m.DayLength,
                            OrbitRadius = m.OrbitRadius,
                            OrbitDuration = m.OrbitDurationSeconds,
                            Size = m.Size,
                            Color = m.Color
                        }).ToList()
                }).ToList()
        };
    }

}