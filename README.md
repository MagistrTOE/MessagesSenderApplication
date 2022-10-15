Project description
--------
- *Web Api application MessagesSenderApplication for sending messages. Sent messages are recorded in the database, reports on sending messages are also recorded*
- *Application is written on the .NET Core 6 Web API platform*
- *Used provider MailKit*
- *To work with the application, a framework with a set of Swagger tools is used*
- *Database: PostgreSQL*

Configuration
------------
- *Database connection:*
  ```yaml
  "ConnectionStrings": {
    "MessagesSenderContext": "User ID=postgres;Password=password;Host=localhost;Port=5432;Database=MessagesSenderDb;"
  }
  ```
- *Smtp client configuration:*
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
- *It is not required to apply manual migrations through the command line, all migrations will be applied and the database will be created automatically when the project is started, this is configured in Program.cs*

Launch project:
---------------
1. Clone all files from the **MessagesSenderApplication** repository 
2. Set the desired Smtp configuration
3. Run the project **MessagesSender.Web.Api**
4. In a browser, go to the link <https://localhost:7114/swagger>
