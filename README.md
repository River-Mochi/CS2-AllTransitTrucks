# All Transit + Trucks

All Transit + Trucks lets you adjust **public transit**, **passenger capacity**, **industry deliveries and fleets**, and **parks/road maintenance** in *Cities Skylines II*.

Everything is optional—you choose which features to use.

## Features

### Public Transit
- **Depot capacity:** Bus, Ferry, Taxi, Tram, Train, and Subway
- **Passenger capacity:** Bus, Tram, Train, Subway, Ship, Ferry, and Airplane
- Optional **Transit Line slider expansion**
  - Can allow as few as 1 vehicle on tested routes
  - Maximum remains variable and follows the game’s route-time logic

### Industry & Cargo
- **Delivery cargo capacity:** Semi Trucks, Delivery Vans, Raw Material Trucks, and Delivery Motorbikes
  - **100% = vanilla**
  - Up to **500%**
- **Total vehicles per facility:**
  - Cargo stations
  - Extractors
  - Warehouses
  - Industrial processing companies
- Optional compatibility toggle for company trucks
  - OFF restores Extractor, Warehouse, and Industry fleets to vanilla and stops ATT from changing them
  - Cargo-station fleets and delivery capacities remain independent

Supported game delivery paths can use the increased capacities. Live testing confirms above-vanilla loads for Semi Trucks, Delivery Vans, and Raw Material Trucks.

### Parks & Roads
- **Park maintenance:** depot fleet, work-shift capacity, and vehicle work rate
- **Road maintenance:** depot fleet, work-shift capacity, and repair rate
- **Road wear speed** (beta)

### Diagnostics
Available on the About tab:
- **Prefab Scan Report**
- Live delivery cargo snapshot
- Cargo-station resource watch
- Open log/report folders

## Notes
- Remove **Adjust Transit Capacity** before using this mod; its features are included here.
- Settings apply while a city is loaded—no restart is required.
- Avoid other mods that change the same capacities or policies, because one mod may overwrite another.
- Use the Reset buttons before removal when you want to restore vanilla values first.
- No Harmony patches are used.
- Most changes apply only when loading a city or changing Options, then the mod goes idle.

## Languages (14)
English, Français, Deutsch, Español, Italiano, Polski, Português (Brasil), Português (Portugal), Türkçe, 한국어, 日本語, 简体中文, 繁體中文, Tiếng Việt

## Transit Line Slider Notes
The maximum vehicle count is not fixed. The game calculates it from route travel time, stops, traffic, and boarding delays. The same setting can therefore show different maximums in different cities or on different routes.

Adding stops can sometimes raise the maximum because it increases the estimated route cycle time.

## Scan Report Notes
The live delivery cargo section is a **one-time snapshot**, not a long-running average. A small count only means that few matching trucks were active at the exact moment of the scan.

## Credits
- River-Mochi — author and maintainer
- Inspired by Wayz’s original **Depot Capacity Changer**

## Links
- GitHub: https://github.com/River-Mochi/CS2-AllTransitTrucks
- Paradox Mods: https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime
- Support Discord: https://discord.gg/gwXgvtyhjc

## License
MIT
