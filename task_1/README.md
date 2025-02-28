"Чтобы что-то продать, нужно что-то купить" (с). Но чтобы на этом еще и заработать, нужно ответить на вопросы *что* и *сколько* купить.

## Определения 

- **Среднедневные продажи (ADS)** — сколько в среднем в день покупают того или иного товара. Например, в один день купили 5 резиновых утят, а в другой — 10, значит, ADS этого товара за два дня будет 7.5.
- **Прогноз продаж (SalesPrediction)** — предположение (основанное на каком-либо расчете), сколько штук заданного товара купят в будущем. Рассчитывается на некоторое количество дней вперед.
- **Потребность к закупке (Demand)** — сколько товара нужно закупить, чтобы удовлетворить будущий спрос.

## Логика расчета

- ADS расcчитывается как отношение суммы продаж за дни, в которые товар был в наличии (!), к количеству этих дней.
- Прогноз продаж — произведение ADS на количество дней (на которое планируется закупка).
- Потребность считается как разность прогноза и количества товара в наличии.

## Основное задание

- Реализовать консольное приложение для расчета среднедневных продаж, прогноза продаж и потребности к закупке.
- Приложение должно принимать команды вида `<что_рассчитать> <ID товара> [количество_дней]` и возвращать рассчитанное количество. Пример команд: 
  - `ads 123`. Раcсчитай среднедневные продажи товара 123 на основе всей имеющейся истории его продаж.
  - `prediction 456 45`. Раcсчитай, сколько товара 465 мы продадим (предположительно) за следующие 45 дней.
  - `demand 678 14`. Раcсчитай, сколько нужно закупить товара 678, чтобы его хватило на следующие 14 дней.
- **Солюшн должен быть структурирован. Должно быть деление на уровни представления, бизнес-логики и доступа к данным.**
- Приложение должно корректно обрабатывать ошибки. 
- Данные для расчета (историю продаж) приложение должно считывать из текстового файла (файл подготовить самостоятельно 🙂). В исходных данных должна быть информация не менее чем по 10-ти товарам с историей продаж не менее чем за 30 дней.
В файле с историей продаж содержится информация сколько какого товара (id) купили (sales) в определенную дату (date) и сколько товара в наличии осталось на конец дня (stock). Пример:

```
id, date, sales, stock
123, 2024-08-01, 10, 50
567, 2024-08-01, 0, 100
678, 2024-08-01, 0, 0
```

## Дополнительное задание
Реализовать ASP.NET сервис (помимо консольного приложения) с методами, аналогичными командам консольки.


