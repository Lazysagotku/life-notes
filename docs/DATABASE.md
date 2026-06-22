# Life Notes — Database Schema

## Tables

### users
| Column | Type | Constraints |
|---|---|---|
| id | uuid | PK, default gen_random_uuid() |
| email | varchar(320) | NOT NULL, UNIQUE |
| password_hash | varchar(512) | NOT NULL |
| created_at | timestamptz | NOT NULL, default now() |

### notes (TPH — все типы заметок в одной таблице)
| Column | Type | Constraints | Used by |
|---|---|---|---|
| id | uuid | PK | all |
| user_id | uuid | NOT NULL, FK → users.id | all |
| discriminator | varchar(50) | NOT NULL | all — значения: Restaurant, Media, Music, FreeNote |
| created_at | timestamptz | NOT NULL | all |
| updated_at | timestamptz | NOT NULL | all |
| name | varchar(200) | nullable | Restaurant |
| address | varchar(500) | nullable | Restaurant |
| latitude | float8 | nullable | Restaurant |
| longitude | float8 | nullable | Restaurant |
| general_impression | text | nullable | Restaurant |
| rating | int | nullable | Restaurant (1-10) |
| title | varchar(300) | nullable | Media, FreeNote |
| media_type | int | nullable | Media (0=Movie,1=Series,2=Anime) |
| status | int | nullable | Media (0=WantToWatch,1=Watching,2=Completed,3=Dropped) |
| current_season | int | nullable | Media |
| current_episode | int | nullable | Media |
| resource_url | varchar(2000) | nullable | Media |
| impressions | text | nullable | Media |
| artist | varchar(200) | nullable | Music |
| album | varchar(200) | nullable | Music |
| track | varchar(300) | nullable | Music |
| mood_at_moment | varchar(200) | nullable | Music |
| thoughts | text | nullable | Music |
| what_influenced_thoughts | text | nullable | Music |
| who_to_share_with | varchar(200) | nullable | Music |
| text | text | nullable | FreeNote |

### restaurant_dishes
| Column | Type | Constraints |
|---|---|---|
| id | uuid | PK |
| note_id | uuid | NOT NULL, FK → notes.id ON DELETE CASCADE |
| name | varchar(300) | NOT NULL |
| impression | text | nullable |
| rating | int | NOT NULL (1-5) |

### note_tags
| Column | Type | Constraints |
|---|---|---|
| id | uuid | PK |
| note_id | uuid | NOT NULL, FK → notes.id ON DELETE CASCADE |
| value | varchar(100) | NOT NULL |

## Indexes

```sql
-- быстрый поиск всех заметок пользователя
CREATE INDEX ix_notes_user_id ON notes(user_id);

-- быстрый поиск заметок по типу для конкретного пользователя
CREATE INDEX ix_notes_user_discriminator ON notes(user_id, discriminator);

-- блюда по заметке
CREATE INDEX ix_restaurant_dishes_note_id ON restaurant_dishes(note_id);

-- теги по заметке
CREATE INDEX ix_note_tags_note_id ON note_tags(note_id);

-- поиск пользователя по email (для логина)
CREATE UNIQUE INDEX ix_users_email ON users(email);
```

## Connection string (development)

```
Host=localhost;Port=5432;Database=lifenotes;Username=lifenotes;Password=lifenotes123
```

Запускается через `docker-compose up -d`.
