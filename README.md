# Toronto Infrastructure Risk Dashboard — API

A REST API built with ASP.NET Core that serves geospatial data for the Toronto Infrastructure Risk Dashboard. Exposes flood-risk assessments for critical infrastructure (hospitals, schools, and subway stations) across Toronto neighbourhoods, returning data as GeoJSON-compatible responses ready to be consumed by a map frontend.

This is the backend layer of a larger project: the **Toronto Infrastructure Risk Dashboard**, which combines a Python ETL pipeline, this API, and a React frontend to visualize which infrastructure in Toronto falls within flood-risk zones.

## Architecture

```
Python ETL → PostGIS (Supabase) → ASP.NET Core API → React Frontend
```

The ETL pipeline processes raw data from OpenStreetMap and the City of Toronto's open GIS services, calculates spatial risk using PostGIS operations, and loads the results into a PostgreSQL/PostGIS database. This API reads from that database and exposes the data as clean, typed endpoints.

## Tech Stack

- **ASP.NET Core (.NET 10)** — REST API
- **Entity Framework Core** + **Npgsql** — PostgreSQL data access
- **NetTopologySuite** — native spatial geometry types (`Point`, `Polygon`, `Geometry`)
- **NetTopologySuite.IO.GeoJSON4STJ** — GeoJSON serialization for geometry fields
- **PostGIS** (via **Supabase**) — spatial database

## Endpoints

### Hospitals
| Method | Route | Description |
|---|---|---|
| GET | `/api/hospitals` | All hospitals with location and risk status |
| GET | `/api/hospitals/at-risk` | Only hospitals inside flood-risk zones |

### Schools
| Method | Route | Description |
|---|---|---|
| GET | `/api/schools` | All schools with location and risk status |
| GET | `/api/schools/at-risk` | Only schools inside flood-risk zones |

### Subway Stations
| Method | Route | Description |
|---|---|---|
| GET | `/api/subways` | All subway stations with location and risk status |
| GET | `/api/subways/at-risk` | Only stations inside flood-risk zones |

### Flood Zones
| Method | Route | Description |
|---|---|---|
| GET | `/api/flood-zones` | All TRCA flood-risk zone polygons |

### Neighbourhoods
| Method | Route | Description |
|---|---|---|
| GET | `/api/neighborhoods` | All Toronto neighbourhoods with aggregated `risk_count` |
| GET | `/api/neighborhoods/at-risk` | Only neighbourhoods with at least one at-risk asset, ordered by `risk_count` descending |

## Response Format

All geometry fields are serialized as GeoJSON. Example response from `GET /api/hospitals/at-risk`:

```json
[
  {
    "id": 34006717,
    "name": "Runnymede Healthcare Centre",
    "website": null,
    "addrStreet": "Runnymede Road",
    "atRisk": true,
    "geometry": {
      "type": "Point",
      "coordinates": [-79.48096, 43.66455]
    }
  }
]
```

## Project Structure

```
TorontoRiskAPI/
├── Controllers/
│   ├── HospitalsController.cs
│   ├── SchoolsController.cs
│   ├── SubwaysController.cs
│   ├── FloodZonesController.cs
│   └── NeighborhoodsController.cs
├── Data/
│   └── TorontoRiskDbContext.cs
├── Models/
│   ├── Hospital.cs
│   ├── School.cs
│   ├── Subway.cs
│   ├── FloodZone.cs
│   └── Neighborhood.cs
├── Services/
│   ├── Interfaces/
│   │   ├── IHospitalService.cs
│   │   ├── ISchoolService.cs
│   │   ├── ISubwayService.cs
│   │   ├── IFloodZoneService.cs
│   │   └── INeighborhoodService.cs
│   ├── HospitalService.cs
│   ├── SchoolService.cs
│   ├── SubwayService.cs
│   ├── FloodZoneService.cs
│   └── NeighborhoodService.cs
├── appsettings.json
└── Program.cs
```

## Running locally

```bash
# 1. Clone the repository
git clone https://github.com/CleisonPaiva/toronto-risk-api
cd TorontoRiskAPI

# 2. Configure the database connection
# Create appsettings.Development.json (gitignored) with your Supabase credentials:
# {
#   "ConnectionStrings": {
#     "DefaultConnection": "Host=...;Port=5432;Database=postgres;Username=...;Password=...;SSL Mode=Require;Trust Server Certificate=true"
#   }
# }

# 3. Run the API
dotnet run
```

The API will be available at `http://localhost:5048`.

## Notes on geometry types

Infrastructure data (hospitals, schools, subway stations) is stored as `Point` geometry — each record was converted to its centroid during the ETL phase to ensure consistent spatial comparisons against the flood-zone polygons.

Neighbourhood and flood-zone geometries are stored as `Polygon`/`MultiPolygon` and mapped to the base `Geometry` type in the .NET models to handle both variants transparently.

## Roadmap

The next phase connects this API to a **React frontend** (Leaflet/OpenLayers/ArcGIS Maps SDK) that renders an interactive choropleth map of neighbourhood risk alongside at-risk infrastructure markers. A **GeoAI chatbot** powered by the OpenAI API will allow natural-language queries against the spatial data (e.g. "which neighbourhoods have the most hospitals at risk?").
