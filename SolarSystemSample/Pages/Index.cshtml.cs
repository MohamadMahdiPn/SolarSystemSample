using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SolarSystemSample.Repositories.Interfaces;
using System.Text.Json;
using SolarSystemSample.Data.Entities;
using SolarSystemSample.Profiles;

namespace SolarSystemSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISolarSystemRepository _repo;
        private readonly JsonSerializerOptions _jsonOptions;
        public IndexModel(ILogger<IndexModel> logger,ISolarSystemRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };
        }

        public string? SolarSystemJson { get; private set; }



        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            // اگر id نداد، اولین منظومه رو نشون بده
            SolarSystem? solarSystem;

            if (id is null)
            {
                var all = await _repo.GetAllSolarSystemsAsync();
                solarSystem = all.FirstOrDefault();
            }
            else
            {
                solarSystem = await _repo.GetSolarSystemAsync(id.Value, includeChildren: true);
            }

            if (solarSystem is null)
                return NotFound();

            // اگر GetSolarSystemAsync بدون includeChildren بود، اینجا include کن
            if (solarSystem.Planets == null || solarSystem.Planets.Count == 0)
            {
                solarSystem = await _repo.GetSolarSystemAsync(solarSystem.Id, includeChildren: true)
                              ?? solarSystem;
            }

            // مپ به DTO سبک برای فرستادن به JS
            var dto = solarSystem.MapToDto();

            SolarSystemJson = JsonSerializer.Serialize(dto, _jsonOptions);

            return Page();
        }
    }
}
