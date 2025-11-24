// -----------------------------
// ۱. تعریف داده‌ها (مدل منظومه)
// -----------------------------
const systemConfig = {
    star: {
        id: "sun",
        label: "خورشید",
        name: "خورشید (Sun)",
        type: "ستاره نوع G",
        description: "ستاره‌ی مرکزی منظومه شمسی و منبع اصلی نور و گرما برای سیاره‌ها.",
        distance: "مرکز منظومه",
        year: "--",
        day: "حدود ۲۷ روز (چرخش استوایی)",
        size: 70,
        style: {
            background: "radial-gradient(circle at center, #facc15, #ea580c)"
        }
    },
    planets: [
        {
            id: "mercury",
            label: "عطارد",
            name: "عطارد (Mercury)",
            type: "سیاره سنگی",
            description: "نزدیک‌ترین سیاره به خورشید با جو بسیار نازک و اختلاف دمای شدید.",
            distance: "۵۷٫۹ میلیون کیلومتر از خورشید",
            year: "۸۸ روز",
            day: "۵۹ روز",
            orbitRadius: 110,
            orbitDuration: 5,
            size: 10,
            color: "#9ca3af",
            moons: []
        },
        {
            id: "venus",
            label: "زهره",
            name: "زهره (Venus)",
            type: "سیاره سنگی",
            description: "داغ‌ترین سیاره منظومه با جو غلیظ و ابرهای اسیدی بازتاب‌دهنده نور.",
            distance: "۱۰۸ میلیون کیلومتر از خورشید",
            year: "۲۲۵ روز",
            day: "۲۴۳ روز",
            orbitRadius: 150,
            orbitDuration: 8,
            size: 14,
            color: "#f97316",
            moons: []
        },
        {
            id: "earth",
            label: "زمین",
            name: "زمین (Earth)",
            type: "سیاره سنگی",
            description: "خانه ما و تنها سیاره‌ای که تاکنون حیات فعال روی آن دیده شده است.",
            distance: "۱۵۰ میلیون کیلومتر از خورشید",
            year: "۳۶۵ روز",
            day: "۲۴ ساعت",
            orbitRadius: 190,
            orbitDuration: 10,
            size: 16,
            color: "#22c55e",
            moons: [
                {
                    id: "moon",
                    label: "ماه",
                    name: "ماه (Moon)",
                    type: "قمر طبیعی زمین",
                    description: "تنها قمر زمین که روی جزر و مد و پایداری محور چرخش اثر می‌گذارد.",
                    distance: "میانگین ۳۸۴٬۴۰۰ کیلومتر از زمین",
                    year: "--",
                    day: "۲۷٫۳ روز (دور گردش مداری)",
                    orbitRadius: 28,
                    orbitDuration: 4,
                    size: 6,
                    color: "#e5e5e5"
                }
            ]
        },
        {
            id: "mars",
            label: "مریخ",
            name: "مریخ (Mars)",
            type: "سیاره سنگی",
            description: "سیاره سرخ با دره‌ها و کوه‌های عظیم و شواهدی از آب در گذشته.",
            distance: "۲۲۸ میلیون کیلومتر از خورشید",
            year: "۶۸۷ روز",
            day: "۲۴٫۶ ساعت",
            orbitRadius: 230,
            orbitDuration: 14,
            size: 13,
            color: "#ef4444",
            moons: [
                {
                    id: "phobos",
                    label: "فوبوس",
                    name: "فوبوس (Phobos)",
                    type: "قمر مریخ",
                    description: "قمر درونی و نزدیک مریخ که به‌تدریج در حال سقوط به سمت سیاره است.",
                    distance: "حدود ۶۰۰۰ کیلومتر از مریخ",
                    year: "--",
                    day: "۷٫۶ ساعت (دور مریخ)",
                    orbitRadius: 22,
                    orbitDuration: 3,
                    size: 4,
                    color: "#cccccc"
                },
                {
                    id: "deimos",
                    label: "دیموس",
                    name: "دیموس (Deimos)",
                    type: "قمر مریخ",
                    description: "قمر کوچک‌تر و دورتر مریخ با مدار آرام‌تر.",
                    distance: "حدود ۲۰٬۰۰۰ کیلومتر از مریخ",
                    year: "--",
                    day: "۳۰٫۳ ساعت (دور مریخ)",
                    orbitRadius: 32,
                    orbitDuration: 5,
                    size: 3,
                    color: "#bbbbbb"
                }
            ]
        },
        {
            id: "jupiter",
            label: "مشتری",
            name: "مشتری (Jupiter)",
            type: "غول گازی",
            description: "بزرگ‌ترین سیاره منظومه با طوفان عظیم «لکه سرخ بزرگ» و ده‌ها قمر.",
            distance: "۷۷۸ میلیون کیلومتر از خورشید",
            year: "۱۱٫۹ سال",
            day: "۱۰ ساعت",
            orbitRadius: 290,
            orbitDuration: 35,
            size: 26,
            color: "#fbbf24",
            moons: [
                {
                    id: "io",
                    label: "آیو",
                    name: "آیو (Io)",
                    type: "قمر مشتری",
                    description: "فعال‌ترین جسم آتشفشانی منظومه شمسی.",
                    distance: "قمر درونی بزرگ مشتری",
                    year: "--",
                    day: "۱٫۸ روز (دور مشتری)",
                    orbitRadius: 40,
                    orbitDuration: 4,
                    size: 6,
                    color: "#ffe4b5"
                },
                {
                    id: "europa",
                    label: "اروپا",
                    name: "اروپا (Europa)",
                    type: "قمر مشتری",
                    description: "سطح یخی و احتمال وجود اقیانوس زیر سطح؛ نامزد جستجوی حیات.",
                    distance: "مدار میانی مشتری",
                    year: "--",
                    day: "۳٫۵ روز (دور مشتری)",
                    orbitRadius: 55,
                    orbitDuration: 6,
                    size: 6,
                    color: "#c7d2fe"
                }
            ]
        },
        {
            id: "saturn",
            label: "زحل",
            name: "زحل (Saturn)",
            type: "غول گازی",
            description: "معروف به حلقه‌های زیبا، متشکل از یخ و سنگ.",
            distance: "۱٫۴۳ میلیارد کیلومتر از خورشید",
            year: "۲۹٫۵ سال",
            day: "۱۰٫۷ ساعت",
            orbitRadius: 340,
            orbitDuration: 55,
            size: 24,
            color: "#facc15",
            moons: [
                {
                    id: "titan",
                    label: "تیتان",
                    name: "تیتان (Titan)",
                    type: "قمر زحل",
                    description: "دارای جو ضخیم و دریاچه‌های متان مایع.",
                    distance: "بزرگ‌ترین قمر زحل",
                    year: "--",
                    day: "۱۵٫۹ روز (دور زحل)",
                    orbitRadius: 42,
                    orbitDuration: 4,
                    size: 6,
                    color: "#fef08a"
                }
            ]
        },
        {
            id: "uranus",
            label: "اورانوس",
            name: "اورانوس (Uranus)",
            type: "غول یخی",
            description: "با محور چرخش بسیار کج؛ گویی روی پهلو می‌غلتد.",
            distance: "۲٫۸۷ میلیارد کیلومتر از خورشید",
            year: "۸۴ سال",
            day: "۱۷ ساعت",
            orbitRadius: 390,
            orbitDuration: 90,
            size: 18,
            color: "#38bdf8",
            moons: []
        },
        {
            id: "neptune",
            label: "نپتون",
            name: "نپتون (Neptune)",
            type: "غول یخی",
            description: "دورترین سیاره شناخته‌شده با بادهایی بسیار تند.",
            distance: "۴٫۵ میلیارد کیلومتر از خورشید",
            year: "۱۶۵ سال",
            day: "۱۶ ساعت",
            orbitRadius: 440,
            orbitDuration: 130,
            size: 18,
            color: "#2563eb",
            moons: [
                {
                    id: "triton",
                    label: "تریتون",
                    name: "تریتون (Triton)",
                    type: "قمر نپتون",
                    description: "قمر بزرگ نپتون با مدار معکوس؛ احتمالاً جرم اسیرشده.",
                    distance: "بزرگ‌ترین قمر نپتون",
                    year: "--",
                    day: "۵٫۹ روز (دور نپتون)",
                    orbitRadius: 30,
                    orbitDuration: 5,
                    size: 6,
                    color: "#f1f5f9"
                }
            ]
        }
    ]
};

// -----------------------------------------
// ۲. کلاس اصلی برای ساخت منظومه از روی داده
// -----------------------------------------
class SolarSystem {
    constructor(config, rootElement, infoUI) {
        this.config = config;
        this.root = rootElement;
        this.infoUI = infoUI;
        this.selectedElement = null;
    }

    init() {
        if (this.config.star) {
            this.createStar(this.config.star);
            // پیش‌فرض: خورشید انتخاب شده باشد
            this.showInfo(this.config.star);
        }
        this.config.planets.forEach(planet => this.createPlanet(planet));
    }

    createStar(starConfig) {
        const star = document.createElement("div");
        star.className = "star";
        star.style.width = `${starConfig.size}px`;
        star.style.height = `${starConfig.size}px`;
        star.style.background = starConfig.style?.background || "#facc15";

        const label = document.createElement("div");
        label.className = "star-label";
        label.textContent = starConfig.label;
        star.appendChild(label);

        star.addEventListener("click", () => {
            this.highlight(star);
            this.showInfo(starConfig);
        });

        this.root.appendChild(star);
    }

    createPlanet(planetConfig) {
        const orbit = document.createElement("div");
        orbit.className = "orbit";
        orbit.style.width = `${planetConfig.orbitRadius}px`;
        orbit.style.height = `${planetConfig.orbitRadius}px`;
        orbit.style.animationDuration = `${planetConfig.orbitDuration}s`;

        const planet = document.createElement("div");
        planet.className = "planet";
        planet.style.width = `${planetConfig.size}px`;
        planet.style.height = `${planetConfig.size}px`;
        planet.style.background = planetConfig.color;

        const label = document.createElement("span");
        label.className = "planet-label";
        label.textContent = planetConfig.label;
        planet.appendChild(label);

        planet.addEventListener("click", (e) => {
            e.stopPropagation();
            this.highlight(planet);
            this.showInfo(planetConfig);
        });

        if (Array.isArray(planetConfig.moons)) {
            planetConfig.moons.forEach(moonConfig => {
                const moonOrbit = document.createElement("div");
                moonOrbit.className = "moon-orbit";
                moonOrbit.style.width = `${moonConfig.orbitRadius}px`;
                moonOrbit.style.height = `${moonConfig.orbitRadius}px`;
                moonOrbit.style.animationDuration = `${moonConfig.orbitDuration}s`;

                const moon = document.createElement("div");
                moon.className = "moon";
                moon.style.width = `${moonConfig.size}px`;
                moon.style.height = `${moonConfig.size}px`;
                moon.style.background = moonConfig.color;

                moon.addEventListener("click", (e) => {
                    e.stopPropagation();
                    this.highlight(moon);
                    this.showInfo(moonConfig);
                });

                moonOrbit.appendChild(moon);
                planet.appendChild(moonOrbit);
            });
        }

        orbit.appendChild(planet);
        this.root.appendChild(orbit);
    }

    showInfo(bodyConfig) {
        const { nameEl, descEl, typeEl, distanceEl, yearEl, dayEl, gridEl } = this.infoUI;

        nameEl.textContent = bodyConfig.name || bodyConfig.label || "بدون نام";
        descEl.textContent = bodyConfig.description || "";
        typeEl.textContent = bodyConfig.type || "-";
        distanceEl.textContent = bodyConfig.distance || "-";
        yearEl.textContent = bodyConfig.year || "-";
        dayEl.textContent = bodyConfig.day || "-";
        gridEl.style.display = "grid";
    }

    highlight(element) {
        if (this.selectedElement) {
            this.selectedElement.classList.remove("selected-body");
        }
        this.selectedElement = element;
        if (this.selectedElement) {
            this.selectedElement.classList.add("selected-body");
        }
    }
}

// -----------------------------
// ۳. راه‌اندازی
// -----------------------------
const rootEl = document.getElementById("solarRoot");
const infoUI = {
    nameEl: document.getElementById("infoName"),
    descEl: document.getElementById("infoDesc"),
    typeEl: document.getElementById("infoType"),
    distanceEl: document.getElementById("infoDistance"),
    yearEl: document.getElementById("infoYear"),
    dayEl: document.getElementById("infoDay"),
    gridEl: document.getElementById("infoGrid")
};

const solarSystem = new SolarSystem(systemConfig, rootEl, infoUI);
solarSystem.init();