namespace SolarSystemSample.Data.Entities;

public class Planet
{
    public Guid Id { get; set; }

    public Guid SolarSystemId { get; set; }
    public SolarSystem SolarSystem { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string Label { get; set; } = default!;        // متن کوچیک روی UI، مثلاً "زمین"
    public string Type { get; set; } = default!;         // سنگی، غول گازی و ...
    public string? Description { get; set; }

    public string? Distance { get; set; }                // الان رشته، اگر خواستی بعداً عدد + واحد جدا
    public string? YearLength { get; set; }              // "۳۶۵ روز"
    public string? DayLength { get; set; }               // "۲۴ ساعت"

    // تنظیمات نمایشی
    public int OrbitRadius { get; set; }                 // px
    public double OrbitDurationSeconds { get; set; }     // ثانیه
    public int Size { get; set; }                        // قطر سیاره در UI
    public string Color { get; set; } = "#ffffff";       // کد رنگ

    public ICollection<Moon> Moons { get; set; } = new List<Moon>();
}