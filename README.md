# Life Notes — Заметки жизни

Персональный дневник впечатлений. Рестораны, кино, аниме, музыка, мысли.

## Стек

- **Backend:** ASP.NET Core Web API (.NET 9), C#
- **База данных:** PostgreSQL + Entity Framework Core
- **Auth:** JWT Bearer tokens
- **Тесты:** xUnit + Moq
- **Деплой:** Docker + docker-compose

## Архитектура

```
src/
├── LifeNotes.Core/           # Доменные модели, интерфейсы, enum-ы
├── LifeNotes.Infrastructure/ # EF Core, репозитории, миграции
├── LifeNotes.API/            # ASP.NET Core Web API, контроллеры
└── LifeNotes.Tests/          # Unit тесты
```

## Быстрый старт

```bash
# Поднять PostgreSQL
docker-compose up -d postgres

# Применить миграции
dotnet ef database update --project src/LifeNotes.Infrastructure --startup-project src/LifeNotes.API

# Запустить API
dotnet run --project src/LifeNotes.API
```

## Документация

- [Дизайн и архитектура](docs/DESIGN.md)
- [Схема базы данных](docs/DATABASE.md)
- [API endpoints](docs/API.md)
- [Роадмап](docs/ROADMAP.md)
