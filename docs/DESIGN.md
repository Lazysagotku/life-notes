# Life Notes — Architecture & Design Decisions

## Overview

REST API for personal notes: restaurants, movies/series/anime, music, and free notes. Multi-user, JWT-authenticated. Designed to support a future mobile app with the same API.

## Architecture: Clean Architecture Light

```
LifeNotes.Core          ← domain models, interfaces, enums (no dependencies)
LifeNotes.Infrastructure ← EF Core, repositories, UnitOfWork (depends on Core)
LifeNotes.API           ← controllers, DTOs, middleware (depends on Core + Infrastructure)
LifeNotes.Tests         ← xUnit tests (depends on Core + Infrastructure)
```

Dependency rule: arrows point inward only. Core knows nothing about EF Core or HTTP.

## Key Decisions

### Multi-user with JWT auth from day one
**Why:** Mobile app in V2 will hit the same API. Building auth retrofitted is painful; JWT is stateless and works for both browser and native clients.

### Note inheritance: TPH (Table Per Hierarchy) + separate detail tables
**Why:** Four note types share common fields (Id, UserId, CreatedAt, UpdatedAt). TPH puts all common fields in one `Notes` table with a `Discriminator` column. EF Core handles this natively with minimal setup.

Child entities that are collections (dishes for restaurants, tags for free notes) get their own tables with FK to the note.

```
Notes (TPH)
├── Id, UserId, CreatedAt, UpdatedAt, Discriminator
├── + RestaurantNote columns (Name, Address, Lat, Lng, Rating, ...)
├── + MediaNote columns (Title, MediaType, Status, Season, Episode, ...)
├── + MusicNote columns (Artist, Album, Track, Mood, Thoughts, ...)
└── + FreeNote columns (Title, Text)

RestaurantDishes  → FK to Notes.Id
NoteTags          → FK to Notes.Id
```

### Repository + Unit of Work pattern
**Why:** Testable — in tests we can swap real repos with in-memory fakes. UnitOfWork wraps the EF Core DbContext to make transaction boundaries explicit.

### Versioned API: /api/v1/...
**Why:** If we break something in V2, old clients still work on V1.

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 9 |
| ORM | Entity Framework Core 9 |
| Database | PostgreSQL 16 |
| Auth | JWT Bearer tokens |
| Password hashing | BCrypt.Net-Next |
| Tests | xUnit + Moq |
| Container | Docker + docker-compose |
