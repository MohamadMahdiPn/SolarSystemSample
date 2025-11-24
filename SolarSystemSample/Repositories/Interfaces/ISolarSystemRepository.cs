using SolarSystemSample.Data.Entities;

namespace SolarSystemSample.Repositories.Interfaces;

public interface ISolarSystemRepository
{
    // ---------- SolarSystem ----------

    Task<SolarSystem> AddSolarSystemAsync(SolarSystem solarSystem, CancellationToken cancellationToken = default);

    Task<SolarSystem?> GetSolarSystemAsync(Guid id, bool includeChildren = false, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<SolarSystem>> GetAllSolarSystemsAsync(CancellationToken cancellationToken = default);

    Task<SolarSystem?> UpdateSolarSystemAsync(SolarSystem solarSystem, CancellationToken cancellationToken = default);

    Task<bool> DeleteSolarSystemAsync(Guid id, CancellationToken cancellationToken = default);


    // ---------- Planet ----------

    Task<Planet> AddPlanetAsync(Guid solarSystemId, Planet planet, CancellationToken cancellationToken = default);

    Task<Planet?> GetPlanetAsync(Guid id, bool includeChildren = false, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Planet>> GetPlanetsBySolarSystemAsync(Guid solarSystemId, CancellationToken cancellationToken = default);

    Task<Planet?> UpdatePlanetAsync(Planet planet, CancellationToken cancellationToken = default);

    Task<bool> DeletePlanetAsync(Guid id, CancellationToken cancellationToken = default);


    // ---------- Moon ----------

    Task<Moon> AddMoonAsync(Guid planetId, Moon moon, CancellationToken cancellationToken = default);

    Task<Moon?> GetMoonAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Moon>> GetMoonsByPlanetAsync(Guid planetId, CancellationToken cancellationToken = default);

    Task<Moon?> UpdateMoonAsync(Moon moon, CancellationToken cancellationToken = default);

    Task<bool> DeleteMoonAsync(Guid id, CancellationToken cancellationToken = default);
}