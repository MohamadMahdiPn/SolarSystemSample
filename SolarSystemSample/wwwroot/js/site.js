// wwwroot/js/solar-system.js

class SolarSystemRenderer {
    /**
     * @param {Object} config - آبجکت منظومه که از سرور اومده
     * @param {HTMLElement} rootElement - div ریشه (مثلاً #solarRoot)
     * @param {Object} infoUI - رفرنس المنت‌های پنل اطلاعات
     */
    constructor(config, rootElement, infoUI) {
        this.config = config;
        this.root = rootElement;
        this.infoUI = infoUI;
        this.selectedElement = null;
    }

    init() {
        if (!this.root || !this.config) {
            console.error("SolarSystemRenderer: root or config missing.");
            return;
        }

        this.root.innerHTML = ""; // پاک کردن هر چی قبلاً بوده

        if (this.config.star) {
            this.createStar(this.config.star);
            // پیش‌فرض اطلاعات خورشید را نشان بده
            this.showInfo(this.config.star);
        }

        if (Array.isArray(this.config.planets)) {
            this.config.planets.forEach(p => this.createPlanet(p));
        }
    }

    // ---------- ساخت ستاره مرکزی ----------
    createStar(starConfig) {
        const star = document.createElement("div");
        star.className = "star";

        const size = starConfig.size ?? 70;
        star.style.width = `${size}px`;
        star.style.height = `${size}px`;
        star.style.background = starConfig.color || "radial-gradient(circle at center, #facc15, #ea580c)";

        const label = document.createElement("div");
        label.className = "star-label";
        label.textContent = starConfig.name || "ستاره";
        star.appendChild(label);

        star.addEventListener("click", () => {
            this.highlight(star);
            this.showInfo({
                name: starConfig.name,
                type: starConfig.type,
                description: starConfig.description,
                distance: "مرکز منظومه",
                year: "--",
                day: "--"
            });
        });

        this.root.appendChild(star);
    }

    // ---------- ساخت سیاره + قمرهایش ----------
    createPlanet(planetConfig) {
        // مدار کلی سیاره
        const orbit = document.createElement("div");
        orbit.className = "orbit";
        orbit.style.width = `${planetConfig.orbitRadius ?? 200}px`;
        orbit.style.height = `${planetConfig.orbitRadius ?? 200}px`;
        orbit.style.animationDuration = `${planetConfig.orbitDuration ?? 20}s`;

        // خود سیاره
        const planet = document.createElement("div");
        planet.className = "planet";
        planet.style.width = `${planetConfig.size ?? 16}px`;
        planet.style.height = `${planetConfig.size ?? 16}px`;
        planet.style.background = planetConfig.color || "#ffffff";

        const label = document.createElement("span");
        label.className = "planet-label";
        label.textContent = planetConfig.label || planetConfig.name || "سیاره";
        planet.appendChild(label);

        planet.addEventListener("click", (e) => {
            e.stopPropagation();
            this.highlight(planet);
            this.showInfo({
                name: planetConfig.name,
                type: planetConfig.type,
                description: planetConfig.description,
                distance: planetConfig.distance,
                year: planetConfig.year,
                day: planetConfig.day
            });
        });

        // قمرها
        if (Array.isArray(planetConfig.moons)) {
            planetConfig.moons.forEach(moonConfig => {
                const moonOrbit = document.createElement("div");
                moonOrbit.className = "moon-orbit";
                moonOrbit.style.width = `${moonConfig.orbitRadius ?? 30}px`;
                moonOrbit.style.height = `${moonConfig.orbitRadius ?? 30}px`;
                moonOrbit.style.animationDuration = `${moonConfig.orbitDuration ?? 5}s`;

                const moon = document.createElement("div");
                moon.className = "moon";
                moon.style.width = `${moonConfig.size ?? 6}px`;
                moon.style.height = `${moonConfig.size ?? 6}px`;
                moon.style.background = moonConfig.color || "#e5e5e5";

                moon.addEventListener("click", (e) => {
                    e.stopPropagation();
                    this.highlight(moon);
                    this.showInfo({
                        name: moonConfig.name,
                        type: moonConfig.type,
                        description: moonConfig.description,
                        distance: moonConfig.distance,
                        year: moonConfig.year,
                        day: moonConfig.day
                    });
                });

                moonOrbit.appendChild(moon);
                planet.appendChild(moonOrbit);
            });
        }

        orbit.appendChild(planet);
        this.root.appendChild(orbit);
    }

    // ---------- نمایش اطلاعات در پنل ----------
    showInfo(bodyConfig) {
        if (!this.infoUI) return;

        const {
            nameEl,
            descEl,
            typeEl,
            distanceEl,
            yearEl,
            dayEl,
            gridEl
        } = this.infoUI;

        if (nameEl) nameEl.textContent = bodyConfig.name || "بدون نام";
        if (descEl) descEl.textContent = bodyConfig.description || "";
        if (typeEl) typeEl.textContent = bodyConfig.type || "-";
        if (distanceEl) distanceEl.textContent = bodyConfig.distance || "-";
        if (yearEl) yearEl.textContent = bodyConfig.year || "-";
        if (dayEl) dayEl.textContent = bodyConfig.day || "-";
        if (gridEl) gridEl.style.display = "grid";
    }

    // ---------- هایلایت جرم انتخاب‌شده ----------
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

// برای دسترسی راحت در اسکریپت‌های دیگه
window.SolarSystemRenderer = SolarSystemRenderer;
