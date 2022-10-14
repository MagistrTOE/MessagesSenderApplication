 Описание 
 --------
- *Web Api приложение MessagesSenderApplication для отправки сообщений. Отправленные сообщения записываются в базу данных, также записываются отчеты об отправке сообщения*
- *Приложение написано на платформе .NET Core 6 Web API*
- *Используется провайдер MailKit*
- *Для работы с приложением используется фрэймворк с набором инструментов Swagger*
- *База данных: PostgreSQL*

Конфигурация
------------
- *Подключение к БД:*
  ```yaml
  "ConnectionStrings": {
    "MessagesSenderContext": "User ID=postgres;Password=password;Host=localhost;Port=5432;Database=MessagesSenderDb;"
  }
  ```
- *Конфигурация Smtp клиента:*
  ```yaml
  "SmtpSettings": {
    "Host": " ",
    "Port": " ",
    "SenderName": " ",
    "SenderEmail": " ",
    "Account": " ",
    "Password": " "
  }
  ```
- *Применять миграции вручную через командную строку не требуется, применение всех миграций и создание БД будет выполняться автоматически при запуске проекта, это сконфигурировано в Program.cs*

Запуск проекта:
---------------
1. Склонировать с репозитория **MessagesSenderApplication** все файлы 
2. Установить нужную конфигурацию Smtp
3. Запустить проект **MessagesSender.Web.Api**
4. В браузере перейти по ссылке <https://localhost:7114/swagger>
