# Life Notes — API Reference

Base URL: `/api/v1`

All endpoints except Auth require header: `Authorization: Bearer <token>`

---

## Auth

### POST /api/v1/auth/register
Регистрация нового пользователя.

**Body:**
```json
{
  "email": "user@example.com",
  "password": "Str0ng!Pass"
}
```

**Response 201:**
```json
{
  "token": "eyJhbGci...",
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

**Errors:** 400 (invalid input), 409 (email already taken)

---

### POST /api/v1/auth/login
Вход в систему.

**Body:**
```json
{
  "email": "user@example.com",
  "password": "Str0ng!Pass"
}
```

**Response 200:**
```json
{
  "token": "eyJhbGci...",
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

**Errors:** 400 (invalid input), 401 (wrong credentials)

---

## Notes

### GET /api/v1/notes
Список всех заметок текущего пользователя.

**Query params:**
- `type` — фильтр: `restaurant` | `media` | `music` | `freenote`

**Response 200:**
```json
[
  {
    "id": "...",
    "type": "restaurant",
    "createdAt": "2026-06-22T10:00:00Z",
    "updatedAt": "2026-06-22T10:00:00Z",
    "name": "Белуга"
  },
  {
    "id": "...",
    "type": "media",
    "createdAt": "2026-06-21T18:30:00Z",
    "updatedAt": "2026-06-21T18:30:00Z",
    "title": "Inception"
  }
]
```

---

### GET /api/v1/notes/{id}
Полная заметка по ID.

**Response 200** (пример — ресторан):
```json
{
  "id": "...",
  "type": "restaurant",
  "createdAt": "2026-06-22T10:00:00Z",
  "updatedAt": "2026-06-22T10:00:00Z",
  "name": "Белуга",
  "address": "Кутузовский пр-т, 2/1",
  "latitude": 55.7454,
  "longitude": 37.5977,
  "generalImpression": "Отличное место, тихо и вкусно",
  "rating": 9,
  "dishes": [
    { "id": "...", "name": "Утиная грудка", "impression": "Нежная, таяла во рту", "rating": 5 }
  ]
}
```

**Errors:** 404 (not found or not owned by user)

---

### POST /api/v1/notes/restaurant
Создать заметку о ресторане.

**Body:**
```json
{
  "name": "Белуга",
  "address": "Кутузовский пр-т, 2/1",
  "latitude": 55.7454,
  "longitude": 37.5977,
  "generalImpression": "Тихо и вкусно",
  "rating": 9
}
```

**Response 201** с Location header и полным объектом заметки.

---

### POST /api/v1/notes/media
Создать заметку о фильме/сериале/аниме.

**Body:**
```json
{
  "title": "Inception",
  "mediaType": "Movie",
  "status": "Completed",
  "currentSeason": null,
  "currentEpisode": null,
  "resourceUrl": "https://www.kinopoisk.ru/film/447301/",
  "impressions": "Блестяще. Смотрел дважды."
}
```

---

### POST /api/v1/notes/music
Создать музыкальную заметку.

**Body:**
```json
{
  "artist": "Radiohead",
  "album": "OK Computer",
  "track": "Exit Music (For a Film)",
  "moodAtMoment": "Меланхолия",
  "thoughts": "Думал о прошлом",
  "whatInfluencedThoughts": "Разговор с другом",
  "whoToShareWith": "Маша"
}
```

---

### POST /api/v1/notes/freenote
Создать свободную заметку.

**Body:**
```json
{
  "title": "Идеи для путешествия",
  "text": "Хочу поехать в Грузию весной...",
  "tags": ["путешествия", "планы"]
}
```

---

### PUT /api/v1/notes/{id}
Обновить заметку. Body — те же поля, что и при создании (без type).

**Response 200** с обновлённым объектом.

**Errors:** 404, 400

---

### DELETE /api/v1/notes/{id}
Удалить заметку.

**Response 204 No Content**

**Errors:** 404

---

## Dishes (только для Restaurant заметок)

### POST /api/v1/notes/{noteId}/dishes
Добавить блюдо к ресторанной заметке.

**Body:**
```json
{
  "name": "Утиная грудка",
  "impression": "Нежная",
  "rating": 5
}
```

**Response 201**

---

### PUT /api/v1/notes/{noteId}/dishes/{dishId}
Обновить блюдо.

---

### DELETE /api/v1/notes/{noteId}/dishes/{dishId}
Удалить блюдо.

**Response 204**

---

## Error format

```json
{
  "error": "NoteNotFound",
  "message": "Note with id '...' was not found"
}
```
