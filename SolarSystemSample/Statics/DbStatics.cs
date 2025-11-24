using Microsoft.EntityFrameworkCore;
using SolarSystemSample.Data.DatabaseContext;
using SolarSystemSample.Data.Entities;
using System;

namespace SolarSystemSample.Statics;

public static class DbStatics
{
    public static void AppendMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }


    public static async Task MigrateAndSeedAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // مایگریشن‌ها
        await db.Database.MigrateAsync();

        // Seed دیتا
        await SeedAsync(db);
    }

    /// <summary>
    /// Seed دیتا فقط وقتی که در جدول‌ها چیزی نیست.
    /// اینجا نمونه برای SolarSystem/Planet/Moon نوشته شده، هرچی مدل داری اینجا اضافه کن.
    /// </summary>
    private static async Task SeedAsync(ApplicationDbContext db)
    {
        // نمونه: اگر هیچ منظومه‌ای وجود ندارد، یکی بساز
        if (!await db.SolarSystems.AnyAsync())
        {
            // --- ID ها ---
            var solarId = Guid.NewGuid();

            var mercuryId = Guid.NewGuid();
            var venusId = Guid.NewGuid();
            var earthId = Guid.NewGuid();
            var marsId = Guid.NewGuid();
            var jupiterId = Guid.NewGuid();
            var saturnId = Guid.NewGuid();
            var uranusId = Guid.NewGuid();
            var neptuneId = Guid.NewGuid();

            // Moon IDs
            var moonId = Guid.NewGuid();

            var phobosId = Guid.NewGuid();
            var deimosId = Guid.NewGuid();

            var ioId = Guid.NewGuid();
            var europaId = Guid.NewGuid();
            var ganymedeId = Guid.NewGuid();
            var callistoId = Guid.NewGuid();

            var titanId = Guid.NewGuid();
            var enceladusId = Guid.NewGuid();

            var mirandaId = Guid.NewGuid();
            var arielId = Guid.NewGuid();
            var umbrielId = Guid.NewGuid();
            var titaniaId = Guid.NewGuid();
            var oberonId = Guid.NewGuid();

            var tritonId = Guid.NewGuid();


            // --- Solar System ---
            var solar = new SolarSystem
            {
                Id = solarId,
                Name = "منظومه شمسی",
                Description = "مدل کامل شده سیارات + قمرهای اصلی.",
                StarName = "خورشید",
                StarType = "G-Type Star",
                StarDescription = "ستاره مرکزی منظومه شمسی.",
                StarSize = 70,
                StarColor = "#facc15"
            };


            // --- Planets ---
            var planets = new List<Planet>
{
    // MERCURY
    new Planet
    {
        Id = mercuryId,
        SolarSystemId = solarId,
        Name = "عطارد",
        Label = "عطارد",
        Type = "سیاره سنگی",
        Description = "نزدیک‌ترین سیاره به خورشید.",
        Distance = "۵۷.۹ میلیون کیلومتر",
        YearLength = "۸۸ روز",
        DayLength = "۵۹ روز",
        OrbitRadius = 110,
        OrbitDurationSeconds = 5,
        Size = 10,
        Color = "#9ca3af"
    },

    // VENUS
    new Planet
    {
        Id = venusId,
        SolarSystemId = solarId,
        Name = "زهره",
        Label = "زهره",
        Type = "سیاره سنگی",
        Description = "داغ‌ترین سیاره منظومه با جو بسیار غلیظ.",
        Distance = "۱۰۸ میلیون کیلومتر",
        YearLength = "۲۲۵ روز",
        DayLength = "۲۴۳ روز",
        OrbitRadius = 150,
        OrbitDurationSeconds = 8,
        Size = 14,
        Color = "#f97316"
    },

    // EARTH
    new Planet
    {
        Id = earthId,
        SolarSystemId = solarId,
        Name = "زمین",
        Label = "زمین",
        Type = "سیاره سنگی",
        Description = "تنها سیاره دارای حیات شناخته‌شده.",
        Distance = "۱۵۰ میلیون کیلومتر",
        YearLength = "۳۶۵ روز",
        DayLength = "۲۴ ساعت",
        OrbitRadius = 190,
        OrbitDurationSeconds = 10,
        Size = 16,
        Color = "#22c55e"
    },

    // MARS
    new Planet
    {
        Id = marsId,
        SolarSystemId = solarId,
        Name = "مریخ",
        Label = "مریخ",
        Type = "سیاره سنگی",
        Description = "به سیاره سرخ معروف است.",
        Distance = "۲۲۸ میلیون کیلومتر",
        YearLength = "۶۸۷ روز",
        DayLength = "۲۴.۶ ساعت",
        OrbitRadius = 230,
        OrbitDurationSeconds = 14,
        Size = 13,
        Color = "#ef4444"
    },

    // JUPITER
    new Planet
    {
        Id = jupiterId,
        SolarSystemId = solarId,
        Name = "مشتری",
        Label = "مشتری",
        Type = "غول گازی",
        Description = "بزرگ‌ترین سیاره منظومه با لکه سرخ بزرگ.",
        Distance = "۷۷۸ میلیون کیلومتر",
        YearLength = "۱۲ سال",
        DayLength = "۱۰ ساعت",
        OrbitRadius = 290,
        OrbitDurationSeconds = 35,
        Size = 26,
        Color = "#fbbf24"
    },

    // SATURN
    new Planet
    {
        Id = saturnId,
        SolarSystemId = solarId,
        Name = "زحل",
        Label = "زحل",
        Type = "غول گازی",
        Description = "دارای حلقه‌های دیدنی ساخته از یخ و سنگ.",
        Distance = "۱.۴۳ میلیارد کیلومتر",
        YearLength = "۲۹ سال",
        DayLength = "۱۰.۷ ساعت",
        OrbitRadius = 340,
        OrbitDurationSeconds = 55,
        Size = 24,
        Color = "#facc15"
    },

    // URANUS
    new Planet
    {
        Id = uranusId,
        SolarSystemId = solarId,
        Name = "اورانوس",
        Label = "اورانوس",
        Type = "غول یخی",
        Description = "محور چرخشش بسیار کج است.",
        Distance = "۲.۸۷ میلیارد کیلومتر",
        YearLength = "۸۴ سال",
        DayLength = "۱۷ ساعت",
        OrbitRadius = 390,
        OrbitDurationSeconds = 90,
        Size = 18,
        Color = "#38bdf8"
    },

    // NEPTUNE
    new Planet
    {
        Id = neptuneId,
        SolarSystemId = solarId,
        Name = "نپتون",
        Label = "نپتون",
        Type = "غول یخی",
        Description = "بادهای فوق سریع دارد.",
        Distance = "۴.۵ میلیارد کیلومتر",
        YearLength = "۱۶۵ سال",
        DayLength = "۱۶ ساعت",
        OrbitRadius = 440,
        OrbitDurationSeconds = 130,
        Size = 18,
        Color = "#2563eb"
    }
};

            var moons = new List<Moon>
{
    // Earth's Moon
    new Moon
    {
        Id = moonId,
        PlanetId = earthId,
        Name = "ماه",
        Label = "ماه",
        Type = "قمر طبیعی",
        Description = "تنها قمر زمین.",
        Distance = "۳۸۴٬۴۰۰ کیلومتر",
        YearLength = "--",
        DayLength = "۲۷.۳ روز",
        OrbitRadius = 28,
        OrbitDurationSeconds = 4,
        Size = 6,
        Color = "#e5e5e5"
    },

    // Mars – Phobos
    new Moon
    {
        Id = phobosId,
        PlanetId = marsId,
        Name = "فوبوس",
        Label = "فوبوس",
        Type = "قمر مریخ",
        Description = "قمر داخلی، در حال سقوط آرام به مریخ.",
        Distance = "۶۰۰۰ کیلومتر",
        DayLength = "۷.۶ ساعت",
        OrbitRadius = 22,
        OrbitDurationSeconds = 3,
        Size = 4,
        Color = "#cccccc"
    },

    // Mars – Deimos
    new Moon
    {
        Id = deimosId,
        PlanetId = marsId,
        Name = "دیموس",
        Label = "دیموس",
        Type = "قمر مریخ",
        Description = "قمر بیرونی مریخ.",
        Distance = "۲۰٬۰۰۰ کیلومتر",
        DayLength = "۳۰ ساعت",
        OrbitRadius = 32,
        OrbitDurationSeconds = 5,
        Size = 3,
        Color = "#bbbbbb"
    },

    // Jupiter – Io
    new Moon
    {
        Id = ioId,
        PlanetId = jupiterId,
        Name = "آیو",
        Label = "آیو",
        Type = "قمر مشتری",
        Description = "فعال‌ترین جسم آتشفشانی منظومه.",
        Distance = "421,700 km",
        DayLength = "1.8 روز",
        OrbitRadius = 40,
        OrbitDurationSeconds = 4,
        Size = 6,
        Color = "#ffe4b5"
    },

    // Jupiter – Europa
    new Moon
    {
        Id = europaId,
        PlanetId = jupiterId,
        Name = "اروپا",
        Label = "اروپا",
        Type = "قمر مشتری",
        Description = "سطح یخی + احتمال وجود اقیانوس زیر سطح.",
        Distance = "671,000 km",
        DayLength = "3.5 روز",
        OrbitRadius = 55,
        OrbitDurationSeconds = 6,
        Size = 6,
        Color = "#c7d2fe"
    },

    // Jupiter – Ganymede (Largest Moon)
    new Moon
    {
        Id = ganymedeId,
        PlanetId = jupiterId,
        Name = "گانی‌مِد",
        Label = "گانی‌مِد",
        Type = "قمر مشتری",
        Description = "بزرگ‌ترین قمر منظومه.",
        Distance = "1,070,000 km",
        DayLength = "7.1 روز",
        OrbitRadius = 70,
        OrbitDurationSeconds = 8,
        Size = 7,
        Color = "#fde047"
    },

    // Jupiter – Callisto
    new Moon
    {
        Id = callistoId,
        PlanetId = jupiterId,
        Name = "کالیستو",
        Label = "کالیستو",
        Type = "قمر مشتری",
        Description = "یکی از قدیمی‌ترین سطوح منظومه.",
        Distance = "1,880,000 km",
        DayLength = "16.7 روز",
        OrbitRadius = 85,
        OrbitDurationSeconds = 10,
        Size = 6,
        Color = "#bfdbfe"
    },

    // Saturn – Titan
    new Moon
    {
        Id = titanId,
        PlanetId = saturnId,
        Name = "تیتان",
        Label = "تیتان",
        Type = "قمر زحل",
        Description = "دارای جو ضخیم و دریاچه‌های متان.",
        Distance = "1,221,000 km",
        DayLength = "15.9 روز",
        OrbitRadius = 42,
        OrbitDurationSeconds = 4,
        Size = 6,
        Color = "#fef08a"
    },

    // Saturn – Enceladus
    new Moon
    {
        Id = enceladusId,
        PlanetId = saturnId,
        Name = "انسلادوس",
        Label = "انسلادوس",
        Type = "قمر زحل",
        Description = "دارای آبفشان‌های یخی و احتمال حیات.",
        Distance = "238,000 km",
        DayLength = "1.37 روز",
        OrbitRadius = 58,
        OrbitDurationSeconds = 6,
        Size = 5,
        Color = "#e5e7eb"
    },

    // Uranus – 5 major moons
    new Moon { Id = mirandaId,  PlanetId = uranusId, Name="میراندا",  Label="میراندا",  Type="قمر اورانوس", Description="کوچک اما بسیار زخم خورده.", OrbitRadius=32,  OrbitDurationSeconds=4,  Size=5, Color="#e2e8f0"},
    new Moon { Id = arielId,    PlanetId = uranusId, Name="آریل",    Label="آریل",     Type="قمر اورانوس", Description="روشن‌ترین قمر اورانوس.", OrbitRadius=44,  OrbitDurationSeconds=6,  Size=5, Color="#cbd5e1"},
    new Moon { Id = umbrielId,  PlanetId = uranusId, Name="آمبریل",  Label="آمبریل",   Type="قمر اورانوس", Description="تیره و کم‌نور.", OrbitRadius=60,  OrbitDurationSeconds=8,  Size=5, Color="#94a3b8"},
    new Moon { Id = titaniaId,  PlanetId = uranusId, Name="تیتانیا", Label="تیتانیا",  Type="قمر اورانوس", Description="بزرگ‌ترین قمر اورانوس.", OrbitRadius=75, OrbitDurationSeconds=10, Size=6, Color="#a3bffa"},
    new Moon { Id = oberonId,   PlanetId = uranusId, Name="اوبِرون", Label="اوبِرون",  Type="قمر اورانوس", Description="خارجی‌ترین قمر بزرگ.", OrbitRadius=90, OrbitDurationSeconds=14, Size=6, Color="#8da2fb"},

    // Neptune – Triton
    new Moon
    {
        Id = tritonId,
        PlanetId = neptuneId,
        Name = "تریتون",
        Label = "تریتون",
        Type = "قمر نپتون",
        Description = "مدار معکوس، شاید جرم اسیر شده.",
        Distance = "354,000 km",
        DayLength = "5.9 روز",
        OrbitRadius = 30,
        OrbitDurationSeconds =5,
        Size = 6,
        Color = "#f1f5f9"
    }
};


            await db.SolarSystems.AddAsync(solar);
            await db.Planets.AddRangeAsync(planets);
            await db.Moons.AddRangeAsync(moons);

            await db.SaveChangesAsync();
        }

       
    }
}