# UserLoginApiTestTask
Тестовое .NET Core 3.1 REST WebApi. Для хранения данных используется PostgreSQL 12. Для работы с БД используется ORM EntityFramework (строка подключения вынесена в файл конфигурации appsettings.json).
Контроллер MainController имеет 4 следующих endpoint:

**public IActionResult Login(Users user)** - публичный POST endpoint. Производит авторизацию по логину и паролю пользователя. В случае успеха возвращает соответствующий результат со сгенерированным токеном аутентификации, в остальных - специальные ошибки. Параметры генерации токена вынесены в файл конфигурации appsettings.json.

**[Authorize]public IActionResult GetInfo(string username)** - приватный GET endpoint. Позволяет получить данные пользователей по username. Доступен только для авторизованных пользователей, получивших токен в ходе успешного логина. В случае успеха возвращает JSON с данными, иначе соответствующие сообщения об ошибках.

**public IActionResult Unhandled(string username)** - публичный GET endpoint. Получает данные пользователя по username. В случае отсутствия пользователя ломается, возвращая Internal Server Error с NullReferenceException.

**[Authorize]public IActionResult UpdateUser(UserNotes data)** - приватный PUT endpoint. Выполняет обновление данных пользователей с признаком active=true. В случае отсутствия пользователя метод ломается с NullReferenceException, но вследствие отлова исключения генерируется логическая ошибка об отсутствии пользователя. Доступен для авторизованных пользователей с token. Возвращает сообщения, соответствующие результату работы.

Тестирование работоспособности методов контроллера производилось с помощью Telerik Fiddler с отслеживанием возвращаемых кодов, Raw Data и JSON data. В releases находится архив со скоспилированным для развертывания WebApi в переносимом режиме.
