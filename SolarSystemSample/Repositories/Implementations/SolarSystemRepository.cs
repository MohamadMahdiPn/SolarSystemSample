using Microsoft.EntityFrameworkCore;
using SolarSystemSample.Data.Entities;
using System;
using SolarSystemSample.Data.DatabaseContext;
using SolarSystemSample.Repositories.Interfaces;

namespace SolarSystemSample.Repositories.Implementations;

public class SolarSystemRepository : ISolarSystemRepository
{
    private readonly ApplicationDbContext _db;

    public SolarSystemRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    // ================== SolarSystem ==================

    public async Task<SolarSystem> AddSolarSystemAsync(SolarSystem solarSystem, CancellationToken cancellationToken = default)
    {
        if (solarSystem.Id == Guid.Empty)
            solarSystem.Id = Guid.NewGuid();

        await _db.SolarSystems.AddAsync(solarSystem, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);

        return solarSystem;
    }

    public async Task<SolarSystem?> GetSolarSystemAsync(Guid id, bool includeChildren = false, CancellationToken cancellationToken = default)
    {
        IQueryable<SolarSystem> query = _db.SolarSystems;

        if (includeChildren)
        {
            query = query
                .Include(s => s.Planets)
                    .ThenInclude(p => p.Moons);
        }

        return await query.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<SolarSystem>> GetAllSolarSystemsAsync(CancellationToken cancellationToken = default)
    {
        return await _db.SolarSystems
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<SolarSystem?> UpdateSolarSystemAsync(SolarSystem solarSystem, CancellationToken cancellationToken = default)
    {
        var existing = await _db.SolarSystems
            .FirstOrDefaultAsync(s => s.Id == solarSystem.Id, cancellationToken);

        if (existing is null)
            return null;

        // فقط فیلدهای ساده را آپدیت می‌کنیم (نه ناوبری‌ها)
        existing.Name = solarSystem.Name;
        existing.Description = solarSystem.Description;
        existing.StarName = solarSystem.StarName;
        existing.StarType = solarSystem.StarType;
        existing.StarDescription = solarSystem.StarDescription;
        existing.StarSize = solarSystem.StarSize;
        existing.StarColor = solarSystem.StarColor;

        await _db.SaveChangesAsync(cancellationToken);

        return existing;
    }

    public async Task<bool> DeleteSolarSystemAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existing = await _db.SolarSystems
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (existing is null)
            return false;

        _db.SolarSystems.Remove(existing);
        await _db.SaveChangesAsync(cancellationToken);

        return true;
    }

    // ================== Planet ==================

    public async Task<Planet> AddPlanetAsync(Guid solarSystemId, Planet planet, CancellationToken cancellationToken = default)
    {
        var solar = await _db.SolarSystems
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == solarSystemId, cancellationToken);

        if (solar is null)
            throw new InvalidOperationException($"SolarSystem with id {solarSystemId} not found.");

        if (planet.Id == Guid.Empty)
            planet.Id = Guid.NewGuid();

        planet.SolarSystemId = solarSystemId;

        await _db.Planets.AddAsync(planet, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);

        return planet;
    }

    public async Task<Planet?> GetPlanetAsync(Guid id, bool includeChildren = false, CancellationToken cancellationToken = default)
    {
        IQueryable<Planet> query = _db.Planets;

        if (includeChildren)
        {
            query = query.Include(p => p.Moons);
        }

        return await query.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Planet>> GetPlanetsBySolarSystemAsync(Guid solarSystemId, CancellationToken cancellationToken = default)
    {
        return await _db.Planets
            .Where(p => p.SolarSystemId == solarSystemId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Planet?> UpdatePlanetAsync(Planet planet, CancellationToken cancellationToken = default)
    {
        var existing = await _db.Planets
            .FirstOrDefaultAsync(p => p.Id == planet.Id, cancellationToken);

        if (existing is null)
            return null;

        existing.Name = planet.Name;
        existing.Label = planet.Label;
        existing.Type = planet.Type;
        existing.Description = planet.Description;
        existing.Distance = planet.Distance;
        existing.YearLength = planet.YearLength;
        existing.DayLength = planet.DayLength;
        existing.OrbitRadius = planet.OrbitRadius;
        existing.OrbitDurationSeconds = planet.OrbitDurationSeconds;
        existing.Size = planet.Size;
        existing.Color = planet.Color;

        await _db.SaveChangesAsync(cancellationToken);

        return existing;
    }

    public async Task<bool> DeletePlanetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existing = await _db.Planets
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (existing is null)
            return false;

        _db.Planets.Remove(existing);
        await _db.SaveChangesAsync(cancellationToken);

        return true;
    }

    // ================== Moon ==================

    public async Task<Moon> AddMoonAsync(Guid planetId, Moon moon, CancellationToken cancellationToken = default)
    {
        var planet = await _db.Planets
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == planetId, cancellationToken);

        if (planet is null)
            throw new InvalidOperationException($"Planet with id {planetId} not found.");

        if (moon.Id == Guid.Empty)
            moon.Id = Guid.NewGuid();

        moon.PlanetId = planetId;

        await _db.Moons.AddAsync(moon, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);

        return moon;
    }

    public async Task<Moon?> GetMoonAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _db.Moons
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Moon>> GetMoonsByPlanetAsync(Guid planetId, CancellationToken cancellationToken = default)
    {
        return await _db.Moons
            .Where(m => m.PlanetId == planetId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Moon?> UpdateMoonAsync(Moon moon, CancellationToken cancellationToken = default)
    {
        var existing = await _db.Moons
            .FirstOrDefaultAsync(m => m.Id == moon.Id, cancellationToken);

        if (existing is null)
            return null;

        existing.Name = moon.Name;
        existing.Label = moon.Label;
        existing.Type = moon.Type;
        existing.Description = moon.Description;
        existing.Distance = moon.Distance;
        existing.YearLength = moon.YearLength;
        existing.DayLength = moon.DayLength;
        existing.OrbitRadius = moon.OrbitRadius;
        existing.OrbitDurationSeconds = moon.OrbitDurationSeconds;
        existing.Size = moon.Size;
        existing.Color = moon.Color;

        await _db.SaveChangesAsync(cancellationToken);

        return existing;
    }

    public async Task<bool> DeleteMoonAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existing = await _db.Moons
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        if (existing is null)
            return false;

        _db.Moons.Remove(existing);
        await _db.SaveChangesAsync(cancellationToken);

        return true;
    }
}