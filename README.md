# Simple RESTful-API ToDo List with JWT-Authorization 
# [Лабораторная №1](#lab1)
# [Лабораторная №5](#lab5)
# [Лабораторная №8](#lab8)
<a name="lab1"></a>
## Лабораторная №1 - Реализация простого Rest API ToDoList на .NET
### Регистрация пользователя
![POSTuser](/screens/Register.jpg)
### Получение списка задач пользователя, которого не существует
![todoerror](/screens/todoError.jpg)
### Получение списка задач пользователя, который существует
![gettodo](/screens/getTodo.jpg)
### Добавить задачу пользователя
![postTodo](/screens/addTodo.jpg)
### Удаление задачи пользователя
![deleteTodo](/screens/deleteTodo.jpg)
<a name="lab5"></a>
## Лабораторная №5 - Использование Case-инструментов для улучшения качества кода(Roslyn, PVS-Studio, ReSharper, Security Code Scan, Roslynator)
### PVS-Studio — проприетарный статический анализатор кода для программ, написанных на С, C++, C++/CLI, C++/CX, C# и на Java. https://pvs-studio.com/ru/
При изменении названия атрибута класса видим одно незначительно замечание
<img src="Code Analyze/PVSbefore.jpg"/>
После исправления ошибки
<img src="Code Analyze/PVSafter.jpg"/>
### Анализатор кода Roslyn. Roslyn – платформа с открытым исходным кодом, разрабатываемая корпорацией Microsoft, и содержащая в себе компиляторы и средства для разбора и анализа кода, написанного на языках программирования C# и Visual Basic. https://github.com/dotnet/roslyn
Та же очепятка, выставляем минимальный порог 
<img src="Code Analyze/RoslynMinimal.jpg"/>
Выставляем максимальный порог
<img src="Code Analyze/RoslynMax.jpg"/>
<img src="Code Analyze/RoslynMax1.jpg"/>
После исправления ошибки
<img src="Code Analyze/RoslynMaxafter.jpg"/>
### ReSharper — дополнение, разработанное компанией JetBrains для повышения продуктивности работы в Microsoft Visual Studio. https://www.jetbrains.com/ru-ru/resharper/
Запускаем анализ из ReSharper
<img src="Code Analyze/Resharperbefore.jpg"/>
<img src="Code Analyze/Resharper1.jpg"/>
<img src="Code Analyze/Resharper2.jpg"/>
<img src="Code Analyze/Resharper3.jpg"/>
<img src="Code Analyze/Resharper4.jpg"/>
<img src="Code Analyze/Resharper5.jpg"/>
Исправляем автоматически ошибки с помощью ReSharper
<img src="Code Analyze/ResharperCorrect.jpg"/>
<img src="Code Analyze/ResharperClean.jpg"/>
Остались только ошибки с именем(забыл, что правильно Rest, а не Reast:D)
<img src="Code Analyze/Resharperafter.jpg"/>
### Security Code Scan - статический анализатор кода для .NET. https://security-code-scan.github.io/
Как видно на скриншоте ниже, выдаётся только одно предупреждение.
<img src="Code Analyze/SCS.jpg"/>
### Roslynator - Коллекция из 500+ анализаторов , рефакторингов и исправлений для C# на платформе Roslyn. https://github.com/JosefPihrt/Roslynator
<img src="Code Analyze/Roslynator.jpg"/>
То самое сообщение после всех исправлений.
<img src="Code Analyze/123.jpg"/>
<a name="lab8"></a>
## Лабораторная №8 - Настройка собственного git-сервера. Использование git-хуков совместно с case-инструментами
