##### Курсовая работа по операциям с базами данных на языке C# с использованием ASP.Net Core.

## Инструкция по установке

1. Клонируйте репозиторий
```bash
git clone https://github.com/VelzDev/teachersWorkload.git
```
Или вытяните его через Visual Studio (ну или скачайте Zip-архивом, как угодно)

2. Установите Microsoft Sql Server (SQL Express)
[SQL Express](https://www.microsoft.com/en-us/download/details.aspx?id=104781)

3. Установите Microsoft SQL Server Management Studio
[SSMS](https://learn.microsoft.com/ru-ru/ssms/download-sql-server-management-studio-ssms?view=sql-server-2016&tabs=command-line)

4. Подключитесь к своей базе данных в Visual Studio через обозреватель серверов
5. Скопируйте строку подключения в свойствах Data Source
6. Замените строку подключения в appsettings.json
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=teacherWorkload;Integrated Security=True"
},
```
8. Откройте консоль диспетчера пакетов NuGet и проведите миграции
```bash
Update-Database
```

### Поздравляю, сервис работает, для отладки можете запускать его через IISExpress или Docker
