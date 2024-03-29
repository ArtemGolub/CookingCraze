# CookingCraze
### Summary: 

Задачи 1 - 4 реализовывались в соотвествии с существующей реализацией, чтобы не нарушать целостность архитектуры проекта.

### Задача #5: Протестировать работоспособность прототипа и соответствие описанию.

>Меню: Перед началом игры поверх ресторана должно быть окошко с указанием необходимого количества блюд для выигрыша и кнопкой “Играть”.

Не было референса. Решение принято в сторону Игрового варианта.

>Хот-дог и Бургер: После тапа на свободной дощечке или хлебнице появляется булочка для Хот-догов.

В игровом варианте нет возможности выложить на дощечку булочку для Хот-дога тапнув на дощечку.
Решение принято в сторону Игрового варианта.

>Хот-дог и Бургер: После тапа на сковородке или сырой сосиске появляется сырая сосиска.

В игровом варианте нет возможности выложить на сковородку сырую сосиску тапнув на сковородку. 
Решение принято в сторону Игрового варианта.

### Задача #6: Составить небольшой анализ реализации задания

> - Какие недостатки и недоработки вам удалось найти?

Для выполнения этой задачи была сделана [UML диаграмма](https://miro.com/app/board/uXjVNuJMPGI=/?share_link_id=417355954835)


> - Какие решения вы считаете сомнительными или нежелательными в более крупных проектах (и почему)? 

- Менеджеры/контроллеры могут оказаться сомнительным решением для крупного проекта
  - Контроллеры напрямую зависят друг от друга
  - При малом количестве контроллеров будет нарушен принцип единой отвественности
  - При большом количестве контроллеров значительно увеличится сложность кода
- Ссылки на конкретные классы лучше не делать. По возможности обращаться через абстракции или интерфейсы. Это сделает код более гибким и расширяемым. Хоть и увеличит количество скриптов.
- Обновляющиеся и не обновляющиеся UI элементы лучше разделять на отдельные Canvas

> - Как можно было бы доработать прототип, чтобы улучшить его производительность на очень слабых мобильных устройствах, не жертвуя качеством картинки и без кардинальных изменений в коде или устройстве сцены? 

- Там где можно Update реализовать через IEnumerator
- Там где возможно переиспользовать UI элементы.
- Обновляемые в процессе UI элементы выводить в отдельные Canvas
- Убрать у не целевых картинок RaycastTarget
- Там где возможно реализовать Object Pooling
- Кэшировать Синглтоны там где это необходимо
- Провести FrameDebug и Profiling. В текущей реализации есть загрузка GarbageCollector, ее можно уменьшить.

> - Где можно изменить числовые параметры: время ожидания посетителей, время готовки/сгорания блюд, количество посетителей? 

- Стоит рассмотреть возможность хранить дату пресетами ScriptalbeObject и через Addressable их загружать при необходимости 
- Стоит понять принцип разделения этих параметров, будет он зависеть от уровней/от блюда или чего-то еще.

> - Что нужно сделать, если будет необходимость реализовать в рамках этого прототипа еще одно блюдо (луковые кольца, жареные во фритюре) с новой механикой 
> 1) Игрок тапает по фритюрнице, начиная готовку
> 2) Фритюрница запускает таймер на пять секунд
> 3) По истечению таймера на стол автоматически выкладывается три
  порции луковых колец. (максимальное количество порций на столе – 3) (достаточно описать порядок действий, не обязательно реализовывать эту
  механику)

1. При необходимости Принять последние изменения в проекте
2. При необходимости Создать новую ветку с названием задачи
3. Добавляем в Config->Orders луковые кольца жаренные во фритюре
4. Добавляем префабы заказа луковых колец жаренных во фритюре в папку Orders
5. Создаем объект OnionPlacer со скриптом FoodPlacer
6. Создаем объект Place со скриптом FoodPlace.
   
    6.1 Можно создать скрипт который будет дублировать логику из FoodTransfer и AutoFoodFiller и прикрепить его к Place. С точки зрения работы с FoodPlace можно будет реализовать не используемый в текущей реализации метод ExtractFood

    6.2 Если есть время, то лучше создать интерфейс<T> с объявленным методом автоматизации принимающий в себя T где T будет являться скриптом который будет автоматизироваться. Автоматизирующийся скрипт будет находится на том же объекте что и скрипт-Автоматизатор таким образом мы сможем расширить функционал других скриптов не создавая лишних сущностей. В дальнейшем такой интерфейс можно будет использовать для рефакторинга AutoFoodFiller и создания других автоматических инструментов.
7. Создать места куда будут помещаться луковые кольца.
8. Проверяем на баги
9. Проверяем на загрузку в Profiler
10. При необходимости фиксим/оптимизируем
11. Пушим на ветку с описанием задачи
12. При необходимости мерджим с другой веткой