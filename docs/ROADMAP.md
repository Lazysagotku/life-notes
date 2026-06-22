# Life Notes — Roadmap

## Phase 1 — Foundation ✅ (текущий статус)
- [x] Solution structure: API / Core / Infrastructure / Tests
- [x] Domain models (Entities, Enums, Interfaces)
- [x] .gitignore
- [x] docker-compose (PostgreSQL)
- [x] docs: DESIGN, DATABASE, API, ROADMAP
- [x] README

## Phase 2 — Database & Auth
- [ ] Установить NuGet пакеты: EF Core + Npgsql, BCrypt.Net-Next, Microsoft.AspNetCore.Authentication.JwtBearer
- [ ] `AppDbContext` — DbSets + TPH конфигурация
- [ ] `IEntityTypeConfiguration` для каждой сущности
- [ ] `UnitOfWork` + `NoteRepository` + `UserRepository`
- [ ] Первая миграция EF Core
- [ ] `AuthController` — register + login (JWT)
- [ ] JWT middleware в Program.cs

## Phase 3 — Notes CRUD
- [ ] `NotesController` — все 4 типа заметок
- [ ] `DishesController` — добавить/обновить/удалить блюда
- [ ] DTO классы (Request/Response) для каждого типа
- [ ] Маппинг Entity ↔ DTO (без AutoMapper — вручную, чтобы понять)
- [ ] Валидация через DataAnnotations или FluentValidation

## Phase 4 — Tests
- [ ] Unit тесты для сервисного слоя (Moq репозитории)
- [ ] Integration тест для AuthController (реальный DbContext in-memory или testcontainers)
- [ ] Покрытие happy path + основные edge cases

## Phase 5 — Polish & Deploy
- [ ] Swagger/OpenAPI описание (XML comments на контроллерах)
- [ ] Pagination для GET /api/v1/notes
- [ ] Фильтрация по типу заметки
- [ ] Dockerfile для API
- [ ] docker-compose.yml обновить — добавить API сервис
- [ ] GitHub Actions CI: build + test

## Не входит в скоуп (V2 / отдельный проект)
- Нативное мобильное приложение
- Push-уведомления
- Поиск по тексту заметок
- Экспорт данных
